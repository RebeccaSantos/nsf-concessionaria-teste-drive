import React from 'react'
import { BrowserRouter, Switch, Route } from 'react-router-dom'

import Login from './Pages/Login';
import Consultar from './Pages/Consultar';
import Cadastrar from './Pages/Cadastrar';
import MenuCliente from './Pages/MenuCliente';
import MenuFuncionario from './Pages/MenuFuncionario';
import AprovarAgendamentosFuncionario from './Pages/AprovarAgendamentosFuncionario';
import AgendamentosDoDiaFuncionario from './Pages/AgendamenosDoDiaFuncionario';
import Feedback from './Pages/Feedback'

function Rotas(){
    return(
      <BrowserRouter>
        <Switch>
          <Route path="/" exact={true} component={Login}/>
          <Route path="/menuCliente" component={MenuCliente}/>
          <Route path="/consultar" component={Consultar}/>
          <Route path="/cadastrar" component={Cadastrar}/>
          <Route path="/menuFuncionario" component={MenuFuncionario}/>
          <Route path="/aprovarAgendamentos" component={AprovarAgendamentosFuncionario}/>
          <Route path="/agendamentosDoDiaFunc" component={AgendamentosDoDiaFuncionario}/>
          <Route path="/feedback" component={Feedback}/>
        </Switch>
      </BrowserRouter>
    )
}

export default Rotas;