import React, { useState, useEffect } from 'react'
import { Link } from "react-router-dom";

import testDriveAPI from "../../Service/TestDriveApi";

const api = new testDriveAPI();

export default function AprovarAgendamentosFuncionario(props){

    const [infos, setInfos] = useState(props.location.state);
    const [lista, setLista] = useState([]);


    return(
        <div className="d-flex flex-column align-items-center justify-content-center" style={{minHeight:"90vh", minWidth:"100vw"}}>
            AprovarAgendamentosFuncionario
        </div> 
    )
}