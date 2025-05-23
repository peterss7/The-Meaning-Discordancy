from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
import os

# Load from environment variable or config
DATABASE_URL = os.getenv("DATABASE_URL")

# Create the engine
engine = create_engine(DATABASE_URL, echo=True)

# Create a session factory
SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)

# Optional: create all tables
from tag.models.tag_model import Base
Base.metadata.create_all(bind=engine)
