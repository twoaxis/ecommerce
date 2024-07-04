import styled from "styled-components";
import CartSection from "../components/cart/CartSection";
import Header from "../components/common/header/Header";

const Container = styled("div")`
	width: 900px;
	margin: 20px auto;

	@media (max-width: 1000px) {
		width: 90%;
	}
`;

const Cart = () => (
	<>
		<Header />
		<Container>
			<CartSection items={[{
				"title": "Hello, world",
				"price": 13000,
				"quantity": 5
			}]}/>
		</Container>
	</>
);

export default Cart;