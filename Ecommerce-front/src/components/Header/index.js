import React from 'react';
import { Navbar, Button,Nav } from "react-bootstrap";
import { Link } from 'react-router-dom';

import "./styles.css";

export default function Header(){

   {/*
    const history = useHistory();
    const [user,setUser] = useState("usuario");
    const [id, setId] = useState(null);

    const [toggle, setToggle] = useState("student");

    useEffect(() => {

    let userStorage = localStorage.getItem('@ufc:user');
   
    if(userStorage !== null){
        let userLogged = JSON.parse(userStorage);
        setId(userLogged.registration);
        setUser(userLogged.name);
        setToggle(userLogged.privileges)
    }

    },[user]);

    
    const Logout = () => {
        
        localStorage.clear();
        history.push('/login');
       
     };

    */}

    return(
    <Navbar className="mainHeader" collapseOnSelect expand="lg" variant="dark">
        <Navbar.Brand > Livraria Cultura </Navbar.Brand>
        <Navbar.Toggle />    
        <Navbar.Collapse className="justify-content-end">
            
            <Nav >
                <Link to = "/categoria"> <Navbar.Text> Categorias</Navbar.Text></Link>
                <Link to = "/list"> <Navbar.Text> Livros</Navbar.Text></Link>
                <Link to = "/Cesta">  <Button variant="outline-light"><i class="fas fa-cash-register"></i> Cesta</Button> </Link>
                <Link to = "/"> <Navbar.Text >Sair</Navbar.Text> </Link>
            </Nav> 
        </Navbar.Collapse>
    </Navbar>
    );
}