import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import { Link } from "react-router-dom";

import testDriveAPI from "../../Service/TestDriveApi";
const api = new testDriveAPI();

export default function Feedback(props){

  console.log(props.location.state)

  const navegacao = useHistory();

  const [infos, setInfos] = useState(props.location.state);
  const [nota,setNota] = useState();

  console.log(infos.id);
  console.log(nota);

  const feed = async () => {
    try {
      const m = {
        feedback: Number(nota)
      };
      const response = await api.feed(m, infos.id);
        navegacao.push("/feedback")
      } catch (e) {
        toast.error(e);
      }
    };

    return(
        <div className="d-flex flex-column align-items-center justify-content-center" style={{minHeight:"90vh", minWidth:"100vw"}}>
            <div className="text-center">
                Nota:(de 0 a 10 para o atendimento)
                <input id="nota" type="number" value={nota} onChange={(e) => setNota(e.target.value)}></input>
            </div>
            <button className="btn btn-primary" onClick={feed}>Dar feedback</button>
        </div> 
    )
}