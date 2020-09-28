import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

import testDriveAPI from "../../Service/TestDriveApi";
const api = new testDriveAPI();

export default function Logar() {
  const navegacao = useHistory();

  const [username, setUsername] = useState("");
  const [senha, setSenha] = useState("");

  const logar = async (e) => {
    e.preventDefault();
    try {
      const m = {
        username:username,
        senha:senha
      };
      const a = await api.login(m);
      console.log(a)
      if(a.data.clienteFuncionario == "Cliente"){
        navegacao.push("/menuCliente",a.data);
      } else{
        navegacao.push("/menuFuncionario",a.data)
      }
    } catch (e) {
      toast.error("Verifique os campos username e senha.");
    }
  }

  return (
    <div>
      <form>
      <div className="d-flex flex-column align-items-center justify-content-center" style={{minHeight:"90vh", minWidth:"100vw"}}>

        <div className="display-4 text-center mb-5">Fazer login</div>

        <div className="d-flex flex-column justify-content-center align-items-center">

          <div className="form-group row" style={{minWidth:"500px"}}>
            <label className="col-sm-2 col-form-label"> Username: </label>
            <div className="col-sm-8">
              <input id="Username" type="text" value={username} onChange={(e) => setUsername(e.target.value)} className="form-control"/>
            </div>
          </div>
          <div className="form-group row" style={{minWidth:"500px"}}>
            <label className="col-sm-2 col-form-label"> Senha: </label>
            <div className="col-sm-8">
              <input id="Senha" type="password" value={senha} onChange={(e) => setSenha(e.target.value)} className="form-control"/>
            </div>
          </div>
          <div>
            <button type="submit" className="btn btn-primary" onClick={logar}>Logar</button>
          </div>
        </div>

      </div>
      </form>
      <ToastContainer />
    </div>
  );
}