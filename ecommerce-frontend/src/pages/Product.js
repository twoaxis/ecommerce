import styled from "styled-components";
import ProductInfo from "../components/product/ProductInfo";
import Header from "../components/common/header/Header";

const Container = styled("div")`
	width: 900px;
	margin: 20px auto;

	@media (max-width: 1000px) {
		width: 90%;
	}
`;

const Product = () => (
	<>
		<Header />
		<Container>
			<ProductInfo />
		</Container>
	</>
);

export default Product;