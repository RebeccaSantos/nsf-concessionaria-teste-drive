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
  const [situacao,setSituacao] = useState("");

  console.log(infos)
  console.log(situacao)
  console.log(infos.id)

  const mudarSituacao = async () => {
    try {
      const m = {
        Situacao: situacao
      };
      const response = await api.mudarSituacaoDogendamentoDoDia(infos.id,m);
      navegacao.goBack();
      } catch (e) {
        console.log(e.response)
        toast.error(e);
      }
    };

    return(
        <div className="d-flex flex-column align-items-center justify-content-center" style={{minHeight:"90vh", minWidth:"100vw"}}>
            <div className="text-center">
                <select name="siatuacao" id="situa" onChange={(e) => setSituacao(String(e.target.value))}>
                    <option disabled selected>Escolha uma sitacao</option>
                    <option value="Cancelado">Cancelado</option>
                    <option value="Não comparecido">Não comparecido</option>
                    <option value="Comparecido">Comparecido</option>
                    <option value="Concluido">Concluido</option>
                </select>
            </div>
            <button className="btn btn-primary mt-4" onClick={mudarSituacao}>Mudar Situacao</button>
        </div> 
    )
}