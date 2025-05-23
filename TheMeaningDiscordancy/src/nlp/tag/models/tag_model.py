from sqlalchemy import Column, Integer, String
from sqlalchemy.ext.declarative import declarative_base

Base = declarative_base()

class TagModel(Base):
    __tablename__ = "tags"

    id = Column(Integer, primary_key=True, autoincrement=True)
    name = Column(String(255), nullable=False)

    def __repr__(self):
        return f"<Tag(id={self.id}, name='{self.name}')>"
