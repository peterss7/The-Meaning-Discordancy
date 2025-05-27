from marshmallow import Schema, fields


class TagSchema(Schema):
    id = fields.Int(required=True)
    name = fields.Str(required=True)
    description = fields.Str()


class TagCreateSchema(Schema):
    name = fields.Str(required=True)
    description = fields.Str()
