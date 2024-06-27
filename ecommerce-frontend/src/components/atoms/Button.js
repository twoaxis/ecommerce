import styled from "styled-components";

const Button = styled("button")`
	background: var(--color-primary);
	color: white;
	font-size: 20px;
	border: none;
	padding: 10px;
	border-radius: 5px;
	cursor: pointer;

	&:disabled {
		cursor: default;
		opacity: 0.5;
	}
`;

export default Button;