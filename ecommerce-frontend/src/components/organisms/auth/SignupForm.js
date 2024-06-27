import React from "react";
import styled from "styled-components";
import LabeledInputField from "../../molecules/LabeledInputField";
import Button from "../../atoms/Button";

const Form = styled("form")`
	text-align: center;
	margin: 40px auto 0;
	width: 300px;

	@media (max-width: 600px) {
		width: 90%;
	}
`;

const Title = styled("h1")`
	font-size: 30px;
	font-weight: 400;
	margin-bottom: 20px;
`;
const SubmitButton = styled(Button)`
	width: 100%;
	margin-top: 20px;
	
`;
const Notice = styled("p")`
	font-size: 15px;
	margin-top: 15px;
	color: #888;
`;

const SignupForm = () => {

	return (
		<Form>
			<Title>Create an Account</Title>
			<LabeledInputField 
				id="email" 
				type="email" 
				name="email"
				label="E-mail" 
				placeholder="johnsmith@twoaxis.com"
			/>
			<LabeledInputField 
				id="password" 
				type="password" 
				name="password"
				label="Password" 
				placeholder="•••••••••••"
			/>
			<LabeledInputField 
				id="repeatPassword" 
				type="password" 
				name="repeatPassword"
				label="Repeat Password" 
				placeholder="•••••••••••"
			/>
			<SubmitButton>Sign up</SubmitButton>
			<Notice>By signing up, you agree to our terms of service and privacy policy.</Notice>
		</Form>
	)
};

export default SignupForm;