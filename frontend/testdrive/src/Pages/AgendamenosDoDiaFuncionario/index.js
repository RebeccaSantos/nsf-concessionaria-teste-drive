import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

import testDriveAPI from "../../Service/TestDriveApi";

const api = new testDriveAPI();

export default function AgendamentosDoDiaFuncionario(props){
    
    const [infos, setInfos] = useState(props.location.state);
    const [lista, setLista] = useState([]);

    console.log(lista)
    
    const consultarAgendamentosDoDia = async () => {
        const response = await api.agendamentosDoDia(infos.idFuncionario);
        console.log(response)
        setLista(response.data);
        
      }

    const data = () => {
        let d = new Date();
        let n = d.toISOString();
        let ano = n.substring(0,4);
        let mes = n.substring(5,7);
        let dia = n.substring(8,10);
        return `Olá ${infos.nome} hoje é dia: ${dia}/${mes}/${ano}`
    }

    useEffect(() => {
        consultarAgendamentosDoDia();
      }, [])

    return(
        <div className="d-flex flex-column align-items-center" style={{minHeight:"90vh", minWidth:"100vw"}}>
            <div className="mb-4 mt-5">
                <h5>{data()}</h5>
            </div>
            <div className="d-flex flex-column align-items-center justify-content-center" style={{width:"100%"}}>
                <table className="table">
                    <thead>
                        <th>Nome cliente</th>
                        <th>CPF</th>
                        <th>Carro</th>
                        <th>Hora</th>
                        <th>Situação</th>
                        <th>Feedback</th>
                        <th></th>
                    </thead>
                    <tbody>
                        {lista.map(item => 
                            <tr key={item.id}>
                                <td>{item.nome}</td>
                                <td>{item.cpf}</td>
                                <td>{item.carro}</td>
                                <td>{item.dia.substring(11)}</td>
                                <td>{item.situacao}</td>
                                <td>{item.feedback == false ?
                                "Ainda sem feedback."
                                : item.valorDoFeed}</td>
                                <td>
                                    {item.situacao == "Concluido" ?
                                    <div></div>
                                    : <Link to={{pathname:"/mudarSituacaoDoAgendamentoDoDia", state:item}}>Mudar Situação</Link>}
                                </td>
                            </tr>    
                        )}
                    </tbody>
                </table>
            </div>
            <div>
                <Link to={{pathname:"/menuFuncionario", state: infos}}>Voltar para menu</Link>
            </div>
        </div> 
    )
}