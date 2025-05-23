from flask import request, jsonify
from flask.views import MethodView
from marshmallow import Schema, fields
from flask_smorest import Blueprint, abort

from schemas import SingleTagSchema, TagSchema
from schemas import TagChainSchema
from services.tag_evaluator import TagEvaluatorService

ROUTE_TAG_GET = "/get"

blp = Blueprint("tags", __name__, url_prefix="/tags")
evaluator = TagEvaluatorService()

@blp.route(ROUTE_TAG_GET)
class Tag(MethodView):
    @blp.response(200, TagSchema)
    def get(self, tag_id):
        return tag_id


@blp.route("/evaluate-chain")
class TagChain(MethodView):
    @blp.arguments(TagChainSchema)
    def post(self, data):
        tags = data["tags"]
        evaluations = evaluator.evaluation_chain(tags)
        return {
            "tags": tags,
            "evaluations": evaluations,
            "axes": [
                "Sacred-Profane",
                "Holy-Secular",
                "Order-Chaos",
                "Creation-Destruction",
                "Unity-Division"
            ]
        }

# --- Single Tag GET ---

@blp.route("/evaluation")
class SingleTagResource(MethodView):
    @blp.arguments(SingleTagSchema, location="query")
    def get(self, args):
        tag = args["tag"]
        evaluation = evaluator.evaluation_tag(tag)
        return {
            "tag": tag,
            "evaluation": evaluation,
            "axes": [
                "Sacred-Profane",
                "Holy-Secular",
                "Order-Chaos",
                "Creation-Destruction",
                "Unity-Division"
            ]
        }

# --- Raw axis names ---

@blp.route("/axes")
class AxesResource(MethodView):
    def get(self):
        return {
            "axes": [
                "Sacred-Profane",
                "Holy-Secular",
                "Order-Chaos",
                "Creation-Destruction",
                "Unity-Division"
            ]
        }

# --- Debug: Get similarity between two tags directly ---

@blp.route("/compare")
class CompareTagsResource(MethodView):
    def get(self):
        tag1 = request.args.get("tag1")
        tag2 = request.args.get("tag2")

        if not tag1 or not tag2:
            abort(400, message="Both tag1 and tag2 must be provided.")

        vecs = evaluator.model.encode([tag1, tag2])
        similarity = float(evaluator.model.similarity_fct(vecs[0], vecs[1]))  # cosine by default

        return {
            "tag1": tag1,
            "tag2": tag2,
            "similarity": round(similarity, 4)
        }
