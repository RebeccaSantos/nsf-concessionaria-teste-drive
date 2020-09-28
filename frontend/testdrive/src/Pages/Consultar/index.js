
import React, { useState, useEffect, useRef } from 'react'
import { Link } from 'react-router-dom';

import testDriveAPI from "../../Service/TestDriveApi";

const api = new testDriveAPI();


export default function Consultar(props) {
  const [infos, setInfos] = useState(props.location.state);
  const [lista, setLista] = useState([]);

  const consultar = async () => {
    
    const response = await api.consultar(props.location.state.idLogin);
    setLista(response);
    
  }

  useEffect(() => {
    consultar();
  }, [])

  return (
    <div>
        <table className="table">
                <thead>
                    <tr>
                        
                        <th>Nome</th>
                        <th>CPF</th>
                        <th>Carro</th>
                        <th>Data</th>
                        <th>Hora</th>
                        <th>Funcionario</th>
                        <th>Situação</th>
                        <th></th>
                        
                    </tr>
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
                                item.situacao == "Concluido" ? (
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
            <Link to={{pathname:"/menuCliente", state: infos}}>Voltar para o menu</Link>
    </div>
  );
}