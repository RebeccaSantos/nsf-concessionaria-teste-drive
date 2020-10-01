import React, { useState, useEffect } from 'react'
import { Link } from "react-router-dom";
import { toast } from 'react-toastify';

import testDriveAPI from "../../Service/TestDriveApi";

const api = new testDriveAPI();

export default function AprovarAgendamentosFuncionario(props){
    console.log(props.location.state)
    const [infos, setInfos] = useState(props.location.state);
    const [lista, setLista] = useState([]);

   

    const aprovar = async () => {
        
        try{
            const aprov = {
                Lista : lista
            };
            console.log(response);
        const response = await api.aprovarAgendamentos(infos.id, aprov);
        }
        catch(e){
            toast.error(e);
        }   

        
    };

   
    
    const listarAgendamentos = async () => {
    
        const response = await api.listarAgendamentosParaAprovar(props.location.state.idAgendamento);
        setLista(response);
        console.log();
        
      }
      useEffect(() => {
        listarAgendamentos();
      }, [])


    return(
        
        <div>
            
            <table className="table">
                <thead>
                    <tr>
                        <th>Nome</th>
                        <th>Carro</th>
                        <th>Data</th>
                        <th>Hora</th>
                        <th>Aprovar</th>
                    </tr>
                </thead>

                <tbody>
                    {lista.map(item => 
                        <tr key={item.id}>
                            <td>{item.nome}</td>
                            <td>{item.carro}</td>
                            <td>{item.dia.substring(0, 10)}</td>
                            <td>{item.dia.substring(11)}</td>
                            <td>{item.aprovar}</td>
                            
                            
                        </tr>    
                    )}
                </tbody>
            </table>
            
            <div><button className="btn btn-primary mt-4" onClick={aprovar}> teste</button></div>
            <div>
                <Link to={{pathname:"/menuFuncionario", state: infos}}>Voltar para menu</Link>
            </div>
        </div>    
    )
}