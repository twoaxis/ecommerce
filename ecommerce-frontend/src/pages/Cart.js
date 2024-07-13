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
				"title": "Apple iPhone 15 XS Max fax tax black color glass background one sim totally for losers...",
				"price": 13000,
				"quantity": 5
			},
			{
				"title": "Hello, world",
				"price": 13000,
				"quantity": 5
			}]}/>
		</Container>
	</>
);

export default Cart;