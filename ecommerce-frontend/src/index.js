import React from "react";
import ReactDOM from "react-dom/client";
import { RouterProvider, createBrowserRouter } from "react-router-dom";

import "./style.css";

const App = () => {

	const router = createBrowserRouter([
		{
			path: "/auth/signup",
			element: <h1>Hello, world</h1>
		}
	]);

	return <RouterProvider router={router} />

};

ReactDOM.createRoot(document.getElementById("root")).render(<App />);