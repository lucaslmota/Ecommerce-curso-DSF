import React, { useState } from "react"
import { Link} from 'react-router-dom';
import { Container, Form, Col, Row, Button, Navbar } from "react-bootstrap"
import LivrosService from "../../../Services/Category/index";
import "./style.css";

export default function CadastrarLivros(props) {

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

  const saveLivro = () => {
    var data = {
        nome: nome,
        descricao: descricao,
        valor: valor,
        observacao: observacao,
        idCompanhia: idCompanhia
    };

    LivrosService.create(data)
        .then(response => {
            setProduct({
              nome: response.nome,
              descricao: response.descricao,
              valor: response.valor,
              observacao: response.observacao,
              idCompanhia: response.idCompanhia
            });
            props.history.push("/list");
            console.log(response.data);
        })
        .catch(e => {
            console.log(e);
        });
  };



  return (

    <Container fluid="sm" className="Main BoxContainer">

      <Navbar className="Navigation">
        <Navbar.Brand > <h4> Cadastrar livro </h4></Navbar.Brand>
      </Navbar>

      <Form onSubmit={saveLivro} >
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
              <Link to="/categoria"> <Button variant="secondary" > Voltar </Button></Link>
              <Button  type="sumit" style={{ marginLeft: '10px' }}> Cadastrar </Button>
            </div>
          </Navbar.Collapse>
        </Navbar>
      </Form>
    </Container>
  )
}

