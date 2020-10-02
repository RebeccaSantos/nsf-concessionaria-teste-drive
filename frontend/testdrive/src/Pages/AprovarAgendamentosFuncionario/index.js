import React, { useState, useEffect } from 'react'
import { Link } from "react-router-dom";
import { toast } from 'react-toastify';

import testDriveAPI from "../../Service/TestDriveApi";

const api = new testDriveAPI();

export default function AprovarAgendamentosFuncionario(props){
    const [infos, setInfos] = useState(props.location.state);
    const [lista, setLista] = useState([]);
    console.log(infos)
    console.log(lista)

    const aprovar = async (idAgendamento) => {
        try{
            const resp = await api.aprovarAgendamentos(idAgendamento,infos.idFuncionario);
            listarAgendamentos();
        }
        catch(e){
            console.log(e.response);
            toast.error(e.response.data.msg);
        }   
    };

    const listarAgendamentos = async () => {
        try {
            const response = await api.listarAgendamentosParaAprovar();
            setLista(response.data);
        } catch (e) {
            console.log(e.response);
        }
      }

      useEffect(() => {
        listarAgendamentos();
      }, [])

    return(
        <div className="d-flex flex-column align-items-center" style={{minHeight:"90vh", minWidth:"100vw", maxWidth:"100vw"}}>
        
            <table className="table">
                <thead>
                    <tr>
                        <th>NomeCliente</th>
                        <th>CPF</th>
                        <th>Carro</th>
                        <th>Data</th>
                        <th>Hora</th>
                        <th>Situação</th>
                        <th>Aprovar</th>
                    </tr>
                </thead>

                <tbody>
                    {lista.map(item => 
                        <tr key={item.idAgendamento}>
                            <td>{item.nomeCliente}</td>
                            <td>{item.cpf}</td>
                            <td>{item.carro}</td>
                            <td>{item.dia.substring(0, 10)}</td>
                            <td>{item.dia.substring(11)}</td>
                            <td>{item.situacao}</td>
                            <td>{item.situacao == "Aguardando" ?
                                    <div></div>
                                    : <button type="button" className="btn btn-warning" onClick={() => aprovar(item.idAgendamento)}>Aprovar</button>}
                            </td>
                            
                            
                        </tr>    
                    )}
                </tbody>
            </table>
            
            <div><button className="btn btn-primary mt-4" onClick={listarAgendamentos}>Consultar</button></div>
            <div>
                <Link to={{pathname:"/menuFuncionario", state: infos}}>Voltar para menu</Link>
            </div>
        </div>    
    )
}