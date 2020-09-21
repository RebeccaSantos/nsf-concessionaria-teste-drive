


import React, { useState, useEffect, useRef } from 'react'

import { Link } from 'react-router-dom';

import testDriveAPI from "../../Service/TestDriveApi";
const api = new testDriveAPI();


export default function Consultar(props) {
  console.log(props.location.state)
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
                        </tr>    
                    )}
                </tbody>
            </table>
    </div>
  );
}
