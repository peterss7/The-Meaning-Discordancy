from sentence_transformers import SentenceTransformer, util

class SimilarityService:
    def __init__(self, model_name: str = "all-MiniLM-L6-v2"):
        self.model = SentenceTransformer(model_name)
        
    def compute_similarity(self, text1: str, text2: str) -> float:
        embeddings = self.model.encode([text1, text2], convert_to_tensor=True)
        return float(util.cos_sim(embeddings[0], embeddings[1]).item())
