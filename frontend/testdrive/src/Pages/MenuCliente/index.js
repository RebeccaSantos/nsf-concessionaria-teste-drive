import React from "react";
import { Link } from "react-router-dom";



export default function MenuCliente(props){
    return(
        <div className="d-flex flex-column align-items-center justify-content-center" style={{minHeight:"90vh", minWidth:"100vw"}}>
            <div className="text-center">
               <h3><Link to="/Consultar">Consultar Agendamentos</Link></h3>

               <h3><Link to="/Cadastrar">Fazer Agendamentos</Link></h3>
            </div>
            <div className="text-center">
                <h1>Olá {props.location.state.nome}</h1>
            </div>
        </div>

       

        
    )
}