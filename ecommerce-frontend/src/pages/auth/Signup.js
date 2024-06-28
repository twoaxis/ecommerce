import React from "react";
import styled from "styled-components";

// Logo
import Logo from "../../assets/logo.png";
import SignupForm from "../../components/auth/SignupForm";

const Main = styled("main")`
	text-align: center;
`;

const Img = styled("img")`
	width: 250px;
	margin-top: 40px;
`;

const Signup = () => (
	<Main>
		<Img src={Logo} alt="Logo"/>
		<SignupForm />
	</Main>
);

export default Signup;