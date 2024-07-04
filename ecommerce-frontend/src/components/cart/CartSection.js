import React from "react";	
import CartItem from "./CartItem";

const CartSection = ({ items }) => (
	<section id="cart">
		{items.map(item => <CartItem item={item} key={item.title} />)}
	</section>	
);

export default CartSection;