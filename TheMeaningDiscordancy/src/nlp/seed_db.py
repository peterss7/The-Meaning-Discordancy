from models import Seed
from uuid import uuid4
from db import db


def seed_db_data():
    if Seed.query.count() >= 20:
        return  # Already seeded

    print("Seeding initial seed ideas...")

    seeds = [
        Seed(
            id=str(uuid4()),
            theme_id=1,
            image_path="/images/chaos1.jpg",
            description="Fractal of disorder",
        ),
    ]

    db.session.bulk_save_objects(seeds)
    db.session.commit()
    print("Seeding complete.")
