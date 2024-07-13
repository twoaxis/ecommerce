const { default: axios } = require("axios");

const AxiosAuthorizedJson = axios.create({
	baseURL: process.env.REACT_APP_BACKEND_API,
	headers: {
		"Content-Type": "application/json",
		"Authorization": "Bearer " + localStorage.getItem("access_token")
	}
});

export default AxiosAuthorizedJson;