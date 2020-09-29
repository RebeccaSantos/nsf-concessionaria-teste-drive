import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import { toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import { Link } from "react-router-dom";

import testDriveAPI from "../../Service/TestDriveApi";
const api = new testDriveAPI();

export default function MudarSituacaoDoAgendamento(props){

  console.log(props.location.state)

  const navegacao = useHistory();

  const [infos, setInfos] = useState(props.location.state);
  const [nota,setNota] = useState();

  console.log(nota);

  const mudarSituacao = async () => {
    try {
      const m = {
        Feedback: nota
      };
      console.log(m);
      console.log("id:"+infos.id)
      const response = await api.agendamentosDoDia();
      navegacao.goBack();
      } catch (e) {
        console.log(e.response)
        toast.error(e);
      }
    };

    return(
        <div className="d-flex flex-column align-items-center justify-content-center" style={{minHeight:"90vh", minWidth:"100vw"}}>
            <div className="text-center">
                <select>
                    <option value="Escolha uma sitacao" disabled selected>Escolha uma sitacao</option>
                    <option>Cancelado</option>
                    <option>Não comparecido</option>
                    <option>Comparecido</option>
                </select>
            </div>
            <button className="btn btn-primary mt-4" onClick={mudarSituacao}>Mudar Situacao</button>
            <Link className="mt-4" to={{pathname:"/consultar", state: infos}}>Voltar</Link>
        </div> 
    )
}