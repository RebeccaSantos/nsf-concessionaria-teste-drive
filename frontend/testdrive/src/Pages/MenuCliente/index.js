import React from "react";
import './style.css';
import { Link } from "react-router-dom";



export default function MenuCliente(){
    return(
        <div className="Corpo">
            <div className="Container-Cima">
               <h3><Link to="/Consultar">Consultar Agendamentos</Link></h3>

               <h3><Link to="/Cadastrar">Fazer Agendamentos</Link></h3>
            </div>
            <div className="Container-Baixo">
                <h1>"Nome do Cliente"</h1>
            </div>
        </div>

       

        
    )
}