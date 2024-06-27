import React from "react";
import ReactDOM from "react-dom/client";
import { RouterProvider, createBrowserRouter } from "react-router-dom";

import "./style.css";

// Pages
import Signup from "./pages/auth/Signup";

const App = () => {

	const router = createBrowserRouter([
		{
			path: "/auth/signup",
			element: <Signup />
		}
	]);

	return <RouterProvider router={router} />

};

ReactDOM.createRoot(document.getElementById("root")).render(<App />);