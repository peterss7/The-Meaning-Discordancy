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


class SimilarityInputSchema(Schema):
    text1 = fields.Str(required=True)
    text2 = fields.Str(required=True)

class SimilaritySchema(Schema):
    similarity = fields.Str(required=True)