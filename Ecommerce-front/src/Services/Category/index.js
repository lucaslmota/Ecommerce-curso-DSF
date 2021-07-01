import api from "../shared/api";

const getAll = () => {
  return api.get("/v1/companhia/get-all");
};

const get = id => {
  return api.get(`​/api​/v1​/companhia​/get​/${id}`);
};

const create = data => {
  return api.post("/api/v1/companhia/create", data);
};

const update = (id, data) => {
  return api.put(`/api/v1/companhia/update`, data);
};

const remove = id => {
  return api.delete(`/api/v1/companhia/remove/${id}`);
};


const CategoryDataService = {
  getAll,
  get,
  create,
  update,
  remove,
};

export default CategoryDataService;