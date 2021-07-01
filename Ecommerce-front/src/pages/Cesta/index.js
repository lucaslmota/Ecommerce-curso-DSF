import React, { useState, useEffect } from 'react';
import { Container, Navbar,Table,Button } from "react-bootstrap";
import CompraService from "../../Services/Compra/index";

import "./style.css";

export default function Cesta() {

    const [compra, setCompra] = useState([]);

    useEffect(() => {
        getCompra();
    }, []);


    const getCompra = () => {
        CompraService.getAll()
        .then(response => {
            setCompra(response.data);
            console.log(response.data);
        })
        .catch(e => {
            console.log(e);
        });
    };


    const deleteCompra = (id) => {
        CompraService.remove(id)
            .then(response => {
                console.log(response.data);
                 setCompra(compra => compra.filter(x => x.id !== id));
                 alert("Produto excluído com sucesso!");
            })
            .catch(e => {
                console.log(e);
        });
    }


    return (

        <Container fluid="sm" className="Main">

            <Navbar className="Navigation">
                <Navbar.Brand > <h4> Livros disponiveis </h4></Navbar.Brand>
                <Navbar.Toggle />
            </Navbar>

            <Table striped hover >
            {compra &&  compra.map((compra, index) => (
             <div key={index}>
                <thead>
                    <tr className="text-center">
                        <th>Valor</th>
                        <th>Data</th>
                        <th>Observacao</th>
                        <th>Forma De Pagamento</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr className="text-center">
                        <td>{compra.valor}</td>
                        <td>{compra.data}</td>
                        <td>{compra.observacao}</td>
                        <td>{compra.formaDePagamento}</td>
                        <td><Button variant="danger" onClick={() => deleteCompra(compra.index)}>Excluir</Button></td>
                    </tr>
                </tbody>

                </div>
            ))}
            </Table>

            <Navbar className="justify-content-between" >
            <Navbar.Brand > Valor Total:  </Navbar.Brand>
                <Button variant="primary">Finalizar Compra</Button>
                <Navbar.Toggle />
            </Navbar>

        </Container >
    )
}

