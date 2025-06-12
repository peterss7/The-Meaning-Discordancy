import uuid
from db import db


class Seed(db.Model):
    __tablename__ = "seed"

    object_key = db.Column(db.String(36), primary_key=True, default=lambda: str(uuid.uuid4()))
    seed_id = db.Column(db.Integer, nullable=False, name="seed_id")
    name = db.Column(db.String, nullable=False)
    order_axis_pos =  db.Column(db.Float, nullable=False)
    creation_axis_pos =  db.Column(db.Float, nullable=False)
    divine_axis_pos =  db.Column(db.Float, nullable=False)
    unity_axis_pos =  db.Column(db.Float, nullable=False)
