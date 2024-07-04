import React from "react";
import { useParams } from "react-router-dom"
import Product from "../pages/Product";

const ProductLoader = () => {
	const { id } = useParams();

	return (
		<>
			<Product />
		</>
	)
}

export default ProductLoader;