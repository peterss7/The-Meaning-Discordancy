from marshmallow import Schema, fields


class TagChainSchema(Schema):
    tags = fields.List(fields.String(), required=True)

class SingleTagSchema(Schema):
    tag = fields.String(required=True)

class TagSchema(Schema):
    name = fields.String(required=True)
