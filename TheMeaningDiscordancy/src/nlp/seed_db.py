from models import Seed
from uuid import uuid4
from db import db



def seed_db_data():
    if Seed.query.count() >= 8:
        return  # Already seeded

    print("Seeding initial seed ideas...")

    seeds = [
        Seed(
            object_key=str(uuid4()),
            seed_id=1,
            name="Fire",
            order_axis_pos=-0.5,
            creation_axis_pos=-.75,
            divine_axis_pos=0.5,
            unity_axis_pos=0.0,
        ),
         Seed(
            object_key=str(uuid4()),
            seed_id=2,
            name="Planet",
            order_axis_pos=0.5,
            creation_axis_pos=.75,
            divine_axis_pos=0.85,
            unity_axis_pos=0.25,
        ),
        Seed(
            object_key=str(uuid4()),
            seed_id=3,
            name="Water",
            order_axis_pos=0.46,
            creation_axis_pos=.55,
            divine_axis_pos=0.4,
            unity_axis_pos=0.10,
        ),
        Seed(
            object_key=str(uuid4()),
            seed_id=4,
            name="Tree",
            order_axis_pos=0.2,
            creation_axis_pos=.65,
            divine_axis_pos=0.6,
            unity_axis_pos=0.30,
        ),
        Seed(
            object_key=str(uuid4()),
            seed_id=5,
            name="Skull",
            order_axis_pos=0.0,
            creation_axis_pos=-.45,
            divine_axis_pos=0.75,
            unity_axis_pos=0.30,
        ),
        Seed(
            object_key=str(uuid4()),
            seed_id=6,
            name="Sword",
            order_axis_pos=0.6,
            creation_axis_pos=-.65,
            divine_axis_pos=0.8,
            unity_axis_pos=0.70,
        ),
        Seed(
            object_key=str(uuid4()),
            seed_id=7,
            name="Snake",
            order_axis_pos=0.0,
            creation_axis_pos=-.15,
            divine_axis_pos=-0.6,
            unity_axis_pos=-0.30,
        ),
        Seed(
            object_key=str(uuid4()),
            seed_id=8,
            name="Eagle",
            order_axis_pos=0.52,
            creation_axis_pos=.25,
            divine_axis_pos=0.8,
            unity_axis_pos=0.67,
        ),            
    ]

    db.session.bulk_save_objects(seeds)
    db.session.commit()
    print("Seeding complete.")
