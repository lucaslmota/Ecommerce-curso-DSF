import React from 'react';
import {BrowserRouter, Switch,Route } from "react-router-dom";

import Header from "../components/Header/index";
import Login from "../pages/Login/index";
import List from "../pages/Livros/List-Livros";
import Categoria from "../pages/Categorias/Categoria- list"
import Cesta from "../pages/Cesta/index";
import CadastrarLivros from "../pages/Livros/Cadastrar-Livros";
import CadastrarCategoria from "../pages/Categorias/Cadastrar-Categoria";



function Routes () {
    return (

    <BrowserRouter>
            
            <Header/>
            <Switch>
                  <Route  path="/" component={Login} exact />
                  <Route  path="/list" component={List} exact />
                  <Route  path="/categoria" component={Categoria} exact />
                  <Route  path="/cesta" component={Cesta} exact />

                  <Route  path="/cadastrarLivro" component={CadastrarLivros} exact />
                  <Route  path="/cadastrarEmpresa" component={CadastrarCategoria} exact />
            </Switch>
    </BrowserRouter>
    );
}

export default Routes;




