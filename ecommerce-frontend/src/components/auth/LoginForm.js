import React, { useState } from "react";
import styled from "styled-components";
import LabeledInputField from "../common/LabeledInputField";
import Button from "../common/Button";
import ErrorElement from "../common/Error";
import { Link } from "react-router-dom";

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
const ErrorMessage = styled(ErrorElement)`
	margin-bottom: 10px;
`;
const CustomLink = styled(Link)`
	text-decoration: none;
	width: 100%;
	color: black;
	font-size: 20px;
	border: 2px solid black;
	padding: 7px;
	border-radius: 5px;
	cursor: pointer;
	display: block;
	margin-top: 10px;

	&:disabled {
		cursor: default;
		opacity: 0.5;
	}
`;

const LoginForm = () => {

	const [ pending, setPending ] = useState(false);
	const [ error, setError ] = useState();
	const [ input, setInput ] = useState({
		email: "",
		password: "",
	});

	const handleInput = (e) => {
		setInput({
			...input,
			[e.target.name]: e.target.value
		});
	}
	
	const submit = (e) => {
		e.preventDefault();
		
		setError(null);
		setPending(true);

		try {
			if(input.email.length === 0 ||
			input.password.length === 0 ||
			input.repeatPassword.length === 0) {
				throw new Error("Please fill all fields");
			}
			else if(input.password !== input.repeatPassword) {
				throw new Error("Passwords don't match");
			}
			else {
				// TODO: Login
			}
		}
		catch({ message }) {
			setError(message);
		}
		finally {
			setPending(false);
		}
		
	}

	return (
		<Form onSubmit={submit}>
			<Title>Log into your account</Title>
			{error && <ErrorMessage>{error}</ErrorMessage>}
			<LabeledInputField 
				id="email" 
				type="email" 
				name="email"
				label="E-mail" 
				placeholder="johnsmith@twoaxis.com"
				disabled={pending}
				onChange={handleInput}
			/>
			<LabeledInputField 
				id="password" 
				type="password" 
				name="password"
				label="Password" 
				placeholder="•••••••••••"
				disabled={pending}
				onChange={handleInput}
			/>
			<SubmitButton
				disabled={pending}
				type="submit"
			>Log In</SubmitButton>
			<CustomLink to="/auth/signup" disabled={pending}>Create an account</CustomLink>
			<Notice>By logging in, you agree to our terms of service and privacy policy.</Notice>
		</Form>
	)
};

export default LoginForm;