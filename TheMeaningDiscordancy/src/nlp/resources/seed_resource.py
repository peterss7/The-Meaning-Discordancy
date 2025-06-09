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

from flask_smorest import Blueprint
from flask.views import MethodView

from models import Seed
from schemas import SeedDtoSchema

blp = Blueprint("Seeds", "seed", url_prefix="/seed")

@blp.route("/<int:id>")
class SeedResource(MethodView):

    @blp.response(200, SeedDtoSchema)
    def get(self, id):
        seed = Seed.query.filter_by(name=seed_id).first_or_404(description=f"The seed {id} could not be found.")
        print(seed.name)
        
        return seed 
