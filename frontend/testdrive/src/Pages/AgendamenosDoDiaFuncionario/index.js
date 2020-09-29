import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

import testDriveAPI from "../../Service/TestDriveApi";

const api = new testDriveAPI();

export default function AgendamentosDoDiaFuncionario(props){
    
    const [infos, setInfos] = useState(props.location.state);
    const [lista, setLista] = useState([]);

    console.log(infos)
    
    const consultarAgendamentosDoDia = async () => {
        const response = await api.agendamentosDoDia();
        setLista(response);
        
      }
    
      useEffect(() => {
        consultarAgendamentosDoDia();
      }, [])

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
                    {lista.map(item => 
                        <tr key={item.id}>
                            <td>{item.nome}</td>
                            <td>{item.cpf}</td>
                            <td>{item.carro}</td>
                            <td>{item.dia.substring(0, 10)}</td>
                            <td>{item.dia.substring(11)}</td>
                            <td>{item.funcionario }</td>
                            <td>{item.situacao}</td>
                            <td>
                              {
                                item.situacao == "Comparecido"|| item.situacao == "Concluido" ? (
                                  item.feedback == false ? (
                                    <Link to={{pathname:"/feedback", state: item}}>Dar feedback</Link>
                                  ) : (
                                    <p>Feedback já enviado</p>
                                  )
                                ) : (
                                  <p>Ainda não é possivel dar feedback</p>
                                )
                              }
                            </td>
                        </tr>    
                    )}
                </tbody>
            </table>
        </div> 
    )
}