import api from "../shared/api";

const getAll = () => {
  return api.get("/api/v1/compra/get-all");
};


const create = data => {
  return api.post("/api/v1/compra/create", data);
};

const remove = id => {
  return api.delete(`/api/v1/compra/remove/${id}`);
};


const CompraService = {
  getAll,
  create,
  remove,
};

export default CompraService;