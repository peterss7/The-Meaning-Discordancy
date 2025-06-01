from db import db

class SimilarityDataModel(db.Model):
    __tablename__ = "similarity_data"

    id = db.Column(db.Integer, primary_key=True)
    text1 = db.Column(db.String(80), unique=False, nullable=False)
    text2 = db.Column(db.String(80), unique=False, nullable=False)
    similarity = db.Column(db.Float)
