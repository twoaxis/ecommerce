import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import styled from "styled-components";
import { faStar } from "@fortawesome/free-solid-svg-icons";

const Container = styled("div")`
	display: flex;
	gap: 2px;
`;
const Star = styled(FontAwesomeIcon)`
	color: ${props => props.toggled ? "orange" : "gray"};
	font-size: 20px;
`;

const Ratings = ({ stars }) => (
	<Container>
		<Star icon={faStar} toggled={stars >= 1} />
		<Star icon={faStar} toggled={stars >= 2} />
		<Star icon={faStar} toggled={stars >= 3} />
		<Star icon={faStar} toggled={stars >= 4} />
		<Star icon={faStar} toggled={stars >= 5} />
	</Container>
);

export default Ratings;