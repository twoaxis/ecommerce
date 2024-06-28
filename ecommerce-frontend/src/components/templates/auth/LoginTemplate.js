import React from "react";
import styled from "styled-components";

// Logo
import Logo from "../../../assets/logo.png";
import LoginForm from "../../organisms/auth/LoginForm";

const Main = styled("main")`
	text-align: center;
`;

const Img = styled("img")`
	width: 250px;
	margin-top: 40px;
`;

const LoginTemplate = () => (
	<Main>
		<Img src={Logo} alt="Logo"/>
		<LoginForm />
	</Main>
);

export default LoginTemplate;