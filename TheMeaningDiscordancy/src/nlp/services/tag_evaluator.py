from sentence_transformers import SentenceTransformer
from sklearn.metrics.pairwise import cosine_similarity
import numpy as np


class TagEvaluatorService:
    def __init__(self):
        self.model = SentenceTransformer("all-MiniLM-L6-v2")
        self.axes = self._define_axes()

    def _avg_vector(self, terms):
        return self.model.encode(terms).mean(axis=0)

    def _define_axes(self):
        # Each axis is a tuple: (positive_pole_vector, negative_pole_vector)
        return [
            (
                self._avg_vector(["sacred", "divine", "blessed"]),
                self._avg_vector(["profane", "blasphemous", "vulgar"]),
            ),
            (
                self._avg_vector(["holy", "saintly", "pure"]),
                self._avg_vector(["secular", "worldly", "rational"]),
            ),
            (
                self._avg_vector(["order", "law", "structure"]),
                self._avg_vector(["chaos", "anarchy", "wildness"]),
            ),
            (
                self._avg_vector(["create", "birth", "build"]),
                self._avg_vector(["destroy", "collapse", "annihilate"]),
            ),
            (
                self._avg_vector(["unity", "harmony", "solidarity"]),
                self._avg_vector(["division", "conflict", "fragmentation"]),
            ),
        ]

    def _score_vector_on_axes(self, vec):
        scores = []
        for pos_vec, neg_vec in self.axes:
            sim_pos = cosine_similarity([vec], [pos_vec])[0][0]
            sim_neg = cosine_similarity([vec], [neg_vec])[0][0]
            scores.append(round(sim_pos - sim_neg, 4))
        return scores

    def score_tag(self, tag: str):
        vec = self.model.encode([tag])[0]
        return self._score_vector_on_axes(vec)

    def score_chain(self, tags: list[str]):
        vectors = self.model.encode(tags)
        return [self._score_vector_on_axes(vec) for vec in vectors]
