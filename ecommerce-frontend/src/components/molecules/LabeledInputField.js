import styled from "styled-components";
import TextField from "../atoms/TextField";

const Container = styled("div")`
	text-align: left;

	+ div {
		margin-top: 15px;
	}
`;
const Label = styled("label")`
	display: block;
	font-size: 14px;
	margin-bottom: 2px;
	color: #666;
`;

const LabeledInputField = (props) => (
	<Container>
		<Label for={props.id}>{props.label}:</Label>
		<TextField {...props} />
	</Container>
);

export default LabeledInputField;