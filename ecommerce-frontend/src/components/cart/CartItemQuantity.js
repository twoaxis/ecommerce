import { faLeftLong, faRightLong } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import React from "react";
import styled from "styled-components";

const Container = styled("div")`
	position: absolute;
	bottom: 35px;
	display: flex;
	width: 105px;
	height: 35px;
	align-items: center;
`;
const Button = styled("button")`
	flex: 1;
	height: 35px;
	border: none;
	background: var(--color-primary);
	color: white;
	cursor: pointer;
`;
const Value = styled("div")`
	flex: 1;
	background: #ddd;
	height: 100%;
	display: flex;
	align-items: center;
	justify-content: center;
`;

const CartItemQuantity = ({ quantity, setQuantity }) => (
	<Container>
		<Button onClick={() => setQuantity(quantity - 1)}><FontAwesomeIcon icon={faLeftLong} /></Button>
		<Value>{quantity}</Value>
		<Button onClick={() => setQuantity(quantity + 1)}><FontAwesomeIcon icon={faRightLong} /></Button>
	</Container>
);

export default CartItemQuantity