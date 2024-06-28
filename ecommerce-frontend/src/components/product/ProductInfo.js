import React from "react";
import styled from "styled-components";
import Ratings from "../common/Ratings";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCartArrowDown, faCartShopping } from "@fortawesome/free-solid-svg-icons";
import Button from "../common/Button";

const Container = styled("section")`
	display: flex;
	gap: 50px;
	
`;

const FlexItem = styled("div")`
	flex: 1
`;
const ProductImage = styled("img")`
	width: 100%;
`;
const Intro = styled("div")`
	border-bottom: 1px solid rgba(0, 0, 0, 0.2);
	padding-bottom: 10px;
`;
const Title = styled("h1")`
	font-size: 35px;
`;
const Price = styled("p")`
	font-size: 20px;
	margin-top: 20px;
	background: var(--color-primary);
	width: fit-content;
	color: white;
	padding: 10px 15px;
	border-radius: 10px;
`;
const Description = styled("p")`
	font-size: 15px;
	margin: 20px 0
`;
const AddToCart = styled(Button)`
	font-size: 15px;
	padding: 15px 20px;
`;

const ProductInfo = () => (
	<Container>
		<FlexItem>
			<ProductImage src={"https://placeholder.com/500x500"} alt="Product"></ProductImage> 
		</FlexItem>
		<FlexItem>
			<Intro>
				<Title>iPhone 14 Pro Max Fax Tax</Title>
				<Ratings stars={3} />
				<Price>50,000 LE</Price>
			</Intro>
			<Description>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi a nibh egestas, vestibulum felis sit amet, sollicitudin augue. Etiam aliquam a orci vulputate malesuada. Donec nec nulla vitae dui tristique condimentum id aliquam purus. Quisque eleifend ac lectus vitae condimentum. Donec sed nibh augue. Nam mollis erat eget nulla posuere euismod. Integer consequat sapien ligula, et porttitor magna tincidunt ac. In at ornare est. Vestibulum ullamcorper neque lobortis gravida vestibulum. Sed eu maximus dui, vel tempus enim. Duis vitae nulla et odio eleifend ullamcorper. Proin non enim sit amet odio sodales vestibulum at laoreet ligula. Aenean tristique lacus ac ante fermentum tempus. Proin vitae laoreet dolor. Nulla nec tincidunt enim, et porttitor neque.</Description>
			<AddToCart><FontAwesomeIcon icon={faCartShopping} /> Add to Cart</AddToCart>
		</FlexItem>
	</Container>
)

export default ProductInfo;