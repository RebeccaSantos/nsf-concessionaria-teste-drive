import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';

import Login from './Pages/Login';
import Consultar from './Pages/Consultar';
import Cadastrar from './Pages/Cadastrar';

function Rotas(){
    return(
        <BrowserRouter>
      <Switch>
        <Route exact path="/" component={Login}/>
        <Route exact path="/consultar" component={Consultar}/>
        <Route exact path="/cadastrar" component={Cadastrar}/>
        
       </Switch>
    </BrowserRouter>
    )
}
export default Rotas;

