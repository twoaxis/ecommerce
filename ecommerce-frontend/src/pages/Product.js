import styled from "styled-components";
import ProductInfo from "../components/product/ProductInfo";

const Container = styled("div")`
	width: 900px;
	margin: 20px auto;

	@media (max-width: 1000px) {
		width: 1000px;
	}
`;

const Product = () => (
	<Container>
		<ProductInfo />
	</Container>
);

export default Product;