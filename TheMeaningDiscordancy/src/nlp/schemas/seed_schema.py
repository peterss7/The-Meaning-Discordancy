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

from marshmallow import Schema, fields


class SeedSchema(Schema):
    object_key = fields.Str(required=True)
    seed_id = fields.Number(required=True)
    name = fields.Str(required=True)
    order_axis_pos = fields.Float(required=True)
    creation_axis_pos = fields.Float(required=True)
    divine_axis_pos = fields.Float(required=True)
    unity_axis_pos = fields.Float(required=True)

class SeedDtoSchema(Schema):
    seed_id = fields.Number(required=True)
    name = fields.Str(required=True)
    order_axis_pos = fields.Float(required=True)
    creation_axis_pos = fields.Float(required=True)
    divine_axis_pos = fields.Float(required=True)
    unity_axis_pos = fields.Float(required=True)