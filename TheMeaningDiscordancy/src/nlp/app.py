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

from flask import Flask
from flask_smorest import Api

from resources import blp as SimilarityBlueprint
from db import db
from seed_db import seed_db_data

def create_app():
    app = Flask(__name__)

    # Config
    app.config["API_TITLE"] = "Similarity Evaluator API"
    app.config["API_VERSION"] = "v1"
    app.config["OPENAPI_VERSION"] = "3.0.3"
    app.config["OPENAPI_URL_PREFIX"] = "/api"
    app.config["OPENAPI_SWAGGER_UI_PATH"] = "/swagger-ui"
    app.config["OPENAPI_SWAGGER_UI_URL"] = "https://cdn.jsdelivr.net/npm/swagger-ui-dist/"

    # Initialize Database
    db.init_app(app)
    
    # Wrap with API
    api = Api(app)
    api.register_blueprint(SimilarityBlueprint)
    
    with app.app_context():
        db.create_all()
        seed_db_data()

    return app

if __name__ == "__main__":
    app = create_app()
    app.run(debug=True)
