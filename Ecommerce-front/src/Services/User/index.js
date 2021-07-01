import api from "../shared/api";

const login = data => {
  return api.post("/v1/auth/login", data);
  
};

const UserDataService = {
  login
};

export default UserDataService;