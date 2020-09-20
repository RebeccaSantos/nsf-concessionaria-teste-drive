import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';

import Login from './Pages/Login';
import Consultar from './Pages/Consultar';
import Cadastrar from './Pages/Cadastrar';
import MenuCliente from './Pages/MenuCliente';

function Rotas(){
    return(
      <BrowserRouter>
        <Switch>
          <Route path="/" exact={true} component={Login}/>
          <Route path="/menu" component={MenuCliente}/>
          <Route path="/consultar" component={Consultar}/>
          <Route path="/cadastrar" component={Cadastrar}/>
        </Switch>
      </BrowserRouter>
    )
}

export default Rotas;