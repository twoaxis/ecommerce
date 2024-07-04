import React from "react"
import styled from "styled-components"
import Logo from "../../../assets/logo.png";
import { Link } from "react-router-dom";
import TextField from "../input/TextField";
import Button from "../input/Button";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCartShopping, faMagnifyingGlass, faUser } from "@fortawesome/free-solid-svg-icons";

const Container = styled("header")`
	height: 60px;
	display: flex;
	align-items: center;
	border-bottom: 1px solid rgba(0, 0, 0, 0.1);
	padding: 0 20px;
	gap: 20px;
`;
const ImageContainer = styled("div")`
	flex: 1;

	@media (max-width: 700px) {
		display: none;
	}
`;
const Image = styled("img")`
	height: 30px;
`;
const SearchBarContainer = styled("div")`
	flex: 2;
	display: flex;
	
`;
const SearchBar = styled(TextField)`
	padding: 5px 10px;
	font-size: 15px;
`;
const SearchButton = styled(Button)`
	padding: 5px 10px;
	font-size: 15px;
	margin-left: 10px;
`;
const UserContainer = styled("div")`
	flex: 1;
	display: flex;
	justify-content: flex-end;
	align-items: center;
	gap: 15px;
	
	@media (max-width: 800px) {
		flex: initial;
	}
`;
const Action = styled(Link)`
	color: gray;
	font-size: 22px;
`;


const Header = () => {
	return (
		<Container>
			<ImageContainer>
			<Link to="/"><Image src={Logo} /></Link>
			</ImageContainer>
			<SearchBarContainer>
				<SearchBar 
					type="text"
					placeholder="Search TwoAxis Shop for electronics, furniture, tools, etc..."
				/>
				<SearchButton><FontAwesomeIcon icon={faMagnifyingGlass} /></SearchButton>
			</SearchBarContainer>
			<UserContainer>
				<Action to="/"><FontAwesomeIcon icon={faCartShopping} /></Action>
				<Action to="/"><FontAwesomeIcon icon={faUser} /></Action>
			</UserContainer>
		</Container>
	)
};

export default Header