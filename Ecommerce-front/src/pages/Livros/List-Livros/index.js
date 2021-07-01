import React, { useState, useEffect } from 'react';
import { Container, Navbar, Card, Button,CardColumns } from "react-bootstrap";
import LivrosService from "../../../Services/Category/index";

import "./style.css";

export default function List(props) {

    const [category, setCategory] = useState([]);

    useEffect(() => {
        getProdutosId(props.match.params.id);
    }, [props.match.params.id]);


    const getProdutosId = id => {
        LivrosService.get(id)
            .then(response => {
                setCategory(response.data);
                console.log(response.data);
            })
            .catch(e => {
                console.log(e);
            });
    };
    

    return (

        <Container fluid="sm" className="Main">

            <Navbar className="Navigation">
                <Navbar.Brand > <h4> Livros disponiveis </h4></Navbar.Brand>
                <Navbar.Toggle />
            </Navbar>

            <CardColumns>
           
            {category.produto && category.produto.map((produto,index) => (
                <Card style={{ width: '18rem' }} className="text-center">
                <Card.Header>{produto.nome}</Card.Header>
                    <Card.Body>
                    <Card.Text>{produto.descricao}</Card.Text>
                    <Card.Text>
                    {produto.valor}
                    </Card.Text>
                    <Button variant="primary">Comprar</Button>
                    </Card.Body>
                </Card>
            ))}
    
            </CardColumns>

        </Container>
    )
}

