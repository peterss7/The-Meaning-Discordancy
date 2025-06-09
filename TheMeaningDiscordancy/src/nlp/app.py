# Copyright © 2025 Steven Peterson
# All rights reserved.
#
# No part of this code may be copied, modified, distributed, or used
# without explicit written permission from the author.
#
# For licensing inquiries or collaboration opportunities:
#
# GitHub: https://github.com/peterss7
# LinkedIn: https://www.linkedin.com/in/steven-peterson7405926/

import sys
import os


sys.path.append(os.path.dirname(__file__))

from sqlalchemy import create_engine, text
from dotenv import load_dotenv
from flask import Flask
from flask_smorest import Api
from urllib.parse import quote_plus

from resources import SimilarityBlueprint
from resources import SeedBlueprint
from db import db
from seed_db import seed_db_data

def create_database_if_not_exists():

    password = quote_plus(os.getenv("SA_PASSWORD"))
    driver = quote_plus(os.getenv("SQL_DRIVER"))
    
    db_name = os.getenv("DB_NAME")
    db_user = os.getenv("DB_USER")
    db_host = os.getenv("DB_HOST")
    db_port = os.getenv("DB_PORT")

    # Connect to the master DB first
    master_uri = (
        f"mssql+pyodbc://{db_user}:{password}@{db_host}:{db_port}/master"
        f"?driver={driver}"
    )

    engine = create_engine(master_uri)
    
    # Check and create DB if not exists
    with engine.connect() as conn:
        conn.execution_options(isolation_level="AUTOCOMMIT")
        result = conn.execute(
            text(f"IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = '{db_name}') CREATE DATABASE [{db_name}];")
        )
        conn.commit()


def create_app():

    load_dotenv()

    app = Flask(__name__)

    # Config
    app.config["API_TITLE"] = "Similarity Evaluator API"
    app.config["API_VERSION"] = "v1"
    app.config["OPENAPI_VERSION"] = "3.0.3"
    app.config["OPENAPI_URL_PREFIX"] = "/api"
    app.config["OPENAPI_SWAGGER_UI_PATH"] = "/swagger-ui"
    app.config["OPENAPI_SWAGGER_UI_URL"] = "https://cdn.jsdelivr.net/npm/swagger-ui-dist/"

    app.config["SQLALCHEMY_DATABASE_URI"] = os.getenv("SQLALCHEMY_DATABASE_URI")

    # Build the SQLAlchemy DB URI from .env vars
    password = quote_plus(os.getenv("SA_PASSWORD"))
    driver = quote_plus(os.getenv("SQL_DRIVER"))

    # Initialize Database
    db_uri = (
        f"mssql+pyodbc://{os.getenv('DB_USER')}:{password}@{os.getenv('DB_HOST')}:{os.getenv('DB_PORT')}/"
        f"{os.getenv('DB_NAME')}?driver={driver}"
    )
    app.config["SQLALCHEMY_DATABASE_URI"] = db_uri

      # Init database
    db.init_app(app)
    
    # Wrap with API
    api = Api(app)
    api.register_blueprint(SimilarityBlueprint)
    api.register_blueprint(SeedBlueprint)    

    with app.app_context():
        create_database_if_not_exists()
        db.create_all()
        seed_db_data()

    return app

if __name__ == "__main__":
    app = create_app()
    app.run(debug=True)
