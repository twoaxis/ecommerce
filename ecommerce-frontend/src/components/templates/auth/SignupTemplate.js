import React from "react";
import styled from "styled-components";

// Logo
import Logo from "../../../assets/logo.png";
import SignupForm from "../../organisms/auth/SignupForm";

const Main = styled("main")`
	text-align: center;
`;

const Img = styled("img")`
	width: 250px;
	margin-top: 40px;
`;

const SignupTemplate = () => (
	<Main>
		<Img src={Logo} alt="Logo"/>
		<SignupForm />
	</Main>
);

export default SignupTemplate;