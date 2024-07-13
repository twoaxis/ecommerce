import React, { useState } from "react";
import styled from "styled-components";
import LabeledInputField from "../common/input/LabeledInputField";
import Button from "../common/input/Button";
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

const SignupForm = () => {

	const [ pending, setPending ] = useState(false);
	const [ error, setError ] = useState();
	const [ input, setInput ] = useState({
		name: "",
		email: "",
		phone: "",
		password: "",
		repeatPassword: ""
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
			<Title>Create an Account</Title>
			{error && <ErrorMessage>{error}</ErrorMessage>}
			<LabeledInputField 
				id="name" 
				type="text" 
				name="name"
				label="Name" 
				placeholder="John Smith"
				disabled={pending}
				onChange={handleInput}
			/>
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
				id="phone" 
				type="tel" 
				name="phone"
				label="Phone Number" 
				placeholder="+1 234 5678"
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
			<LabeledInputField 
				id="repeatPassword" 
				type="password" 
				name="repeatPassword"
				label="Repeat Password" 
				placeholder="•••••••••••"
				disabled={pending}
				onChange={handleInput}
			/>
			<SubmitButton
				disabled={pending}
				type="submit"
			>Sign up</SubmitButton>
			<CustomLink to="/auth/login" disabled={pending}>Log in</CustomLink>
			<Notice>By signing up, you agree to our terms of service and privacy policy.</Notice>
		</Form>
	)
};

export default SignupForm;