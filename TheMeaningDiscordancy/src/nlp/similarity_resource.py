from flask.views import MethodView
from flask_smorest import Blueprint

blp = Blueprint("items", __name__)

@blp.route("/similarity/<int:concept_id")
class Similarity(MethodView):
    @blp.response(200, SimilarityDataSchema)
    def get(self, concept_id):
        concept = ConceptModel.query.get_or_404(concept_id)


        
# @blp.route("/item/<int:item_id>")
# class ItemResource:
#     @blp.response(200, ItemSchema)
#     def get(self, item_id):
#         item = ItemModel.query.get(item_id)
#         if not item:
#             abort(404, message="Item not found.")
#         return item

# @blp.route("/item")
# class ItemListResource:
#     @blp.response(200, ItemSchema(many=True))
#     def get(self):
#         return ItemModel.query.all()

#     @blp.arguments(ItemSchema)
#     @blp.response(201, ItemSchema)
#     def post(self, item_data):
#         item = ItemModel(**item_data)
#         db.session.add(item)
#         db.session.commit()
#         return item

