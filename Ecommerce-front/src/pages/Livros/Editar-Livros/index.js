import React, { useState } from "react"
import { Link } from 'react-router-dom';
import { Container, Form, Col, Row, Button, Navbar } from "react-bootstrap"
import "./style.css";
//import api from '../../../Services/Api'

export default function CadastrarLivros() {

  const initialProductState =
    {
        id: null,
        name: "",
        quantityInPackage: "",
        price: "",
        categoryId: ""
    };
  
  const [nome, setNome] = useState('');
  const [descricao, setDescricao] = useState('');
  const [valor, setValor] = useState(0);
  const [observacao, setObservacao] = useState('');
  const [idCompanhia, setIdCompanhia] = useState(0);
  
  const [product, setProduct] = useState(initialProductState);

  return (

    <Container fluid="sm" className="Main BoxContainer">

      <Navbar className="Navigation">
        <Navbar.Brand > <h4> Cadastrar livro </h4></Navbar.Brand>
      </Navbar>

      <Form >
      <Row>

        <Col sm={4}>
          <Form.Row>
            <Form.Group as={Col} controlId="curricularStructure">
              <Form.Label>Nome</Form.Label>
              <Form.Control type="text" value={nome} onChange={(e) => setNome(e.target.value)} placeholder="Digite o nome do livro " required />
            </Form.Group>
          </Form.Row>
        </Col>

        <Col sm={4}>
          <Form.Row>
            <Form.Group as={Col} controlId="CategoryI">
              <Form.Label>Descrição</Form.Label>
              <Form.Control type="text" value={descricao} onChange={(e) => setDescricao(e.target.value)} placeholder="Digite a descrição do livro " required />
            </Form.Group>
          </Form.Row>
        </Col>

        <Col sm={4}>
          <Form.Row>
            <Form.Group as={Col} controlId="CategoryII">
              <Form.Label>Valor da obra</Form.Label>
              <Form.Control type="number" value={valor} onChange={(e) => setValor(e.target.value)} placeholder="Digite o valor da obra " required/>
            </Form.Group>
          </Form.Row>
        </Col>
        </Row>
        <Row>
        <Col sm={4}>
          <Form.Row>
            <Form.Group as={Col} controlId="CategoryII">
              <Form.Label>Observacao</Form.Label>
              <Form.Control type="number" value={observacao} onChange={(e) => setObservacao(e.target.value)} placeholder="Digite o valor da obra " required/>
            </Form.Group>
          </Form.Row>
        </Col>

        <Col sm={4}>
          <Form.Row>
            <Form.Group as={Col} controlId="CategoryII">
              <Form.Label>Id Companhia</Form.Label>
              <Form.Control type="number" value={idCompanhia} onChange={(e) => setIdCompanhia(e.target.value)} placeholder="Digite o valor da obra " required/>
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

