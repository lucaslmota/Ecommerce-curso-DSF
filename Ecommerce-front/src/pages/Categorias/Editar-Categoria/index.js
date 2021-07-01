import React, { useState } from "react"
import { Link, useHistory } from 'react-router-dom';
import { Container, Form, Col, Row, Button, Navbar } from "react-bootstrap"
import CategoryService from "../../../Services/Category/index";
import "./style.css";

export default function CadastrarLivros(props) {

  const initialCategoryState =
  {
      id: null,
      nomeFantasia: "",
      razaoSocial: "",
      cnpj: ""
  };

  const [nomeFantasia, setNomeFantasia] = useState('');
  const [razaoSocial, setRazaoSocial] = useState('');
  const [cnpj, setCnpj] = useState('');


  const updateCategoria = () => {

    var data = {
      nomeFantasia,
      razaoSocial,
      cnpj
  };
  
    CategoryService.update( props.match.params.id, data)
        .then(response => {
            console.log(response.data);
            alert("Atualizado com sucesso!");
            props.history.push("/categoria");
        })
        .catch(e => {
            console.log(e);
        });
};

  return (

    <Container fluid="sm" className="Main BoxContainer">

      <Navbar className="Navigation">
        <Navbar.Brand > <h4> Cadastrar Categoria </h4></Navbar.Brand>
      </Navbar>

      <Form onSubmit={updateCategoria}>
        <Row>

        <Col sm={4}>
            <Form.Row>
              <Form.Group as={Col} controlId="curricularStructure">
                <Form.Label>Nome Fantasia</Form.Label>
                <Form.Control type="text" value={nomeFantasia} onChange={(e) => setNomeFantasia(e.target.value)} placeholder="Digite o Nome Fantasia da empresa " required />
              </Form.Group>
            </Form.Row>
          </Col>

          <Col sm={4}>
            <Form.Row>
              <Form.Group as={Col} controlId="CategoryI">
                <Form.Label>Razao Social</Form.Label>
                <Form.Control type="text" value={razaoSocial} onChange={(e) => setRazaoSocial(e.target.value)} placeholder="Digite a Razao Social da empresa  " required />
              </Form.Group>
            </Form.Row>
          </Col>

          <Col sm={4}>
            <Form.Row>
              <Form.Group as={Col} controlId="CategoryII">
                <Form.Label>CNPJ</Form.Label>
                <Form.Control type="number" value={cnpj} onChange={(e) => setCnpj(e.target.value)} placeholder="Digite o CNPJ da empresa " required/>
              </Form.Group>
            </Form.Row>
          </Col>
        </Row>


        <Navbar className="NavigationRegister">

          <Navbar.Collapse className="justify-content-end">
            <div>
              <Link to="/empresa"> <Button variant="secondary" > Voltar </Button></Link>
              <Button  type="sumit" style={{ marginLeft: '10px' }}> Cadastrar </Button>
            </div>
          </Navbar.Collapse>
        </Navbar>
      </Form>
    </Container>
  )
}

