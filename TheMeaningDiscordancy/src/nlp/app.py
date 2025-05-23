from flask import Flask
from resources.tag_resource import blp as TagBlueprint


app = Flask(__name__)
app.register_blueprint(TagBlueprint)

if __name__ == "__main__":
    app.run(debug=True)
