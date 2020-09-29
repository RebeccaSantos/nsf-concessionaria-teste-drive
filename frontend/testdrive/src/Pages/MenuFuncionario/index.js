import React, { useState } from "react";
import { Link } from "react-router-dom";

export default function MenuFuncionario(props){

    const [infos, setInfos] = useState(props.location.state);

    return(
        <div className="d-flex flex-column align-items-center justify-content-center" style={{minHeight:"90vh", minWidth:"100vw"}}>
            <div className="text-center">
                <h1>Olá {props.location.state.nome}</h1>
            </div>
            <div className="text-center mb-5">
               <h3><Link to={{pathname:"/aprovarAgendamentos", state: infos}}>Aprovar agendamentos</Link></h3>
               <h3><Link to={{pathname:"/agendamentosDoDiaFunc", state: infos}}>Agendamentos do dia</Link></h3>
            </div>
            <div className="mt-5">
                <Link to={{pathname:"/"}}>Sair</Link>
            </div>
        </div> 
    )
}