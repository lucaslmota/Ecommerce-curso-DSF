import api from "../shared/api";

const getAll = () => {
  return api.get("/v1/companhia/get-all");
};

const get = id => {
  return api.get(`/category/${id}`);
};

const create = data => {
  return api.post("/category", data);
};

const update = (id, data) => {
  return api.put(`/category/${id}`, data);
};

const remove = id => {
  return api.delete(`/category/${id}`);
};

const LivrosService = {
  getAll,
  get,
  create,
  update,
  remove,
};

export default LivrosService;