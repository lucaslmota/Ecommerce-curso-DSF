import React, { useState, useEffect } from 'react';
import { Container, Navbar,Table,Button } from "react-bootstrap";
import CategoryService from "../../../Services/Category/index";
import {Link} from "react-router-dom";

import "./style.css";

export default function Empresa() {

    const [categorys, setCategorys] = useState([]);

    useEffect(() => {
        getCategorias();
    }, []);


    const getCategorias = () => {
        CategoryService.getAll()
        .then(response => {
            setCategorys(response.data);
            console.log(response.data);
        })
        .catch(e => {
            console.log(e);
        });
    };

    const deleteCategoria = (id) => {
        CategoryService.remove(id)
            .then(response => {
                console.log(response.data);
                 alert("Produto excluído com sucesso!");
                 getCategorias();
            })
            .catch(e => {
                console.log(e);
        });
    }


    return (

        <Container fluid="sm" className="Main">

        <Navbar className="justify-content-between">
            <Navbar.Brand > <h4> Categorias disponiveis </h4></Navbar.Brand>
            <Navbar.Toggle />
            
          <Link to="/cadastrarEmpresa">  <Button variant="dark">Cadastrar Categoria</Button> </Link>
        </Navbar>


        <Table striped hover >
           {categorys && categorys.map((category, index) => (
             <div key={index}>
            <thead>
                
                <tr className="text-center">
                    <th>#</th>
                    <th>nomeFantasia</th>
                    <th>razaoSocial</th>
                    <th>CNPJ</th>
                    <th></th>
                    
                </tr>
            </thead>
            <tbody>
                <tr className="text-center">
                    <td>1</td>
                    <td>{category.nomeFantasia}</td>
                    <td>{category.razaoSocial}</td>
                    <td>{category.cnpj}</td>
                    <td> <Link to={"/category/"}> <Button variant="danger">Edit </Button></Link>
                    <Button variant="danger" onClick={() => deleteCategoria(category.index)}>Excluir</Button>
                    <Link to="/cadastrarLivro"> <Button variant="info">Cadastrar Livro</Button></Link>
                    </td> 
                </tr>
            </tbody>
           </div>
            ))}
        </Table>

    </Container >
)
}
