import React from "react";
import { useParams } from "react-router-dom"
import ProductTemplate from "../pages/Product";

const Product = () => {
	const { id } = useParams();

	return (
		<>
			<ProductTemplate />
		</>
	)
}

export default Product;