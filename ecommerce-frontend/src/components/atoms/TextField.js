import styled from "styled-components";

const TextField = styled("input")`
	width: 100%;
	font-size: 16px;
	border: 1px solid #ccc;
	padding: 10px 15px;
	border-radius: 5px;
	outline: none;

	&:focus {
		outline: 2px solid black;
	}
`;

export default TextField;