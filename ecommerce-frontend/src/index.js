import React from "react";
import ReactDOM from "react-dom/client";
import { Navigate, RouterProvider, createBrowserRouter } from "react-router-dom";

import "./style.css";

// Pages
import Signup from "./pages/auth/Signup.js";
import Login from "./pages/auth/Login.js";

// Pages with loaders
import ProductLoader from "./loaders/ProductLoader.js";
import CartLoader from "./loaders/CartLoader.js";

const App = () => {

	const router = createBrowserRouter([
		// Authentication
		{
			path: "/auth/signup",
			element: <Signup />
		},
		{
			path: "/auth/login",
			element: <Login />
		},

		// Products
		{
			path: "/product/",
			element: <Navigate to="/" /> // No product id
		},
		{
			path: "/product/:id",
			element: <ProductLoader />
		},

		// Cart
		{
			path: "/cart/",
			element: <CartLoader />
		}
	]);

	return <RouterProvider router={router} />

};

ReactDOM.createRoot(document.getElementById("root")).render(<App />);