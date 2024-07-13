import React, { useState } from "react";
import { Link } from "react-router-dom";
import styled from "styled-components";
import CartItemQuantity from "./CartItemQuantity";
import Button from "../common/input/Button";

const Container = styled("div")`
	display: flex;
	padding: 20px 0;
	height: 180px;

	+ div {
		border-top: 1px solid rgba(0, 0, 0, 0.1);
	}
`;
const ImageContainer = styled(Link)`
	width: 150px;
`;
const Image = styled("img")`
	height: 100%;
`;
const ItemInfo = styled("div")`
	position: relative;
	text-decoration: none;
	color: black;
	padding: 0 20px;
	flex: 1;
`;
const Title = styled(Link)`
	font-weight: 400;
	font-size: 20px;
	height: 50px;
	text-decoration: none;
	display: block;
	color: black;
`;
const RemoveBtn = styled(Button)`
	position: absolute;
	bottom: 0px;
	padding: 5px;
	font-size: 15px;
	width: 105px;
`;


const CartItem = ({ item, index }) => {
	const { id, title, quantity } = item; // TODO: Price
	const [ newQty, setNewQty ] = useState(quantity);

	return (
		<Container>
			<ImageContainer to={"/product/" + id}>
				<Image src="https://placeholder.com/150x150" />
			</ImageContainer>
			<ItemInfo>
				<Title to={"/product/" + id}>{title}</Title>
				<CartItemQuantity quantity={newQty} setQuantity={setNewQty} />
				<RemoveBtn>Remove</RemoveBtn>
			</ItemInfo>
		</Container>
	)
}

export default CartItem;