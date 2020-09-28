import React, { useState } from "react";
import { Link } from "react-router-dom";

export default function AgendamentosDoDiaFuncionario(props){

    const [infos, setInfos] = useState(props.location.state);
    

    return(
        <div className="d-flex flex-column align-items-center justify-content-center" style={{minHeight:"90vh", minWidth:"100vw"}}>
            <table>
                <thead>
                    <th>Nome cliente</th>
                    <th>CPF</th>
                    <th>Carro</th>
                    <th>Data</th>
                    <th>Hora</th>
                    <th>Funcionario</th>
                    <th>Situação</th>
                </thead>
                <tbody>

                </tbody>
            </table>
        </div> 
    )
}