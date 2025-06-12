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

from models import SimilarityDataModel
from schemas import SimilaritySchema, SimilarityInputSchema
from services import SimilarityService

blp = Blueprint("Similarity", "similarity", url_prefix="/similarity")
similarity_service = SimilarityService()

@blp.route("/")
class SimilarityResource(MethodView):

    @blp.arguments(SimilarityInputSchema)
    @blp.response(200, SimilaritySchema)
    def post(self, input_data):
        similarity_data = SimilarityDataModel(**input_data)
        similarity_data.similarity = similarity_service.compute_similarity(similarity_data.text1, similarity_data.text2)

        print(similarity_data)


        return similarity_data
