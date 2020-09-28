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

  console.log(nota);

  const feed = async () => {
    try {
      const m = {
        Feedback: nota
      };
      console.log(m);
      console.log("id:"+infos.id)
      const response = await api.feedback(infos.id, m);
        navegacao.goBack();
      } catch (e) {
        console.log(e.response)
        toast.error(e);
      }
    };

    return(
        <div className="d-flex flex-column align-items-center justify-content-center" style={{minHeight:"90vh", minWidth:"100vw"}}>
            <div className="text-center">
                <h5>Dê uma nota de 0 a 10 para a sua experiência</h5>
                <input id="nota" type="number" value={nota} onChange={(e) => setNota(Number(e.target.value))}></input>
            </div>
            <button className="btn btn-primary mt-4" onClick={feed}>Dar feedback</button>
            <Link className="mt-4" to={{pathname:"/consultar", state: infos}}>Voltar</Link>
        </div> 
    )
}