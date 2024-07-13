const { default: axios } = require("axios");

const AxiosJson = axios.create({
	baseURL: process.env.REACT_APP_BACKEND_API,
	headers: {
		"Content-Type": "application/json",
	}
});

export default AxiosJson;