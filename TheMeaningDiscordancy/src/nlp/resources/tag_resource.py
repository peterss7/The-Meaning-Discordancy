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

from flask import Blueprint
from flask.views import MethodView

from schemas.tag_schema import TagSchema, TagCreateSchema


blp = Blueprint("tags", __name__, description="Operations on tags")

# Fake example data
TAGS = {
    1: {"id": 1, "name": "order", "description": "Structure and law"},
    2: {"id": 2, "name": "chaos", "description": "Entropy and disruption"},
}
NEXT_ID = 3


@blp.route("/tag/<int:tag_id>")
class TagResource(MethodView):
    @blp.response(200, TagSchema)
    def get(self, tag_id):
        tag = TAGS.get(tag_id)

        print(tag)

        if not tag:
            abort(404, message="Tag not found.")
        return tag


@blp.route("/tag")
class TagListResource(MethodView):
    @blp.response(201, TagSchema)
    @blp.arguments(TagCreateSchema)
    def post(self, data):
        print(data)
        if not input:
            abort(404, message="Input data was empty. Could not create Tag.")

        global NEXT_ID
        tag_id = NEXT_ID
        NEXT_ID += 1

        tag = {"id": tag_id, **data}
        TAGS[tag_id] = tag

        return tag

    @blp.response(200, TagSchema(many=True))
    def get(self):
        return [TAGS[item] for item in TAGS]
