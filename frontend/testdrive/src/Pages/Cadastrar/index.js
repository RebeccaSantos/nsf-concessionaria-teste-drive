import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import React, { useState, useEffect, useRef } from 'react';
import { Link } from 'react-router-dom';
import './style.css';

import testDriveAPI from "../../Service/TestDriveApi";

const api = new testDriveAPI();

export default function Cadastrar(props) {

  const [infos, setInfos] = useState(props.location.state);

  console.log(infos)

  const [carro, setCarro] = useState('');
  const [data, setData] = useState('');
  const [hora, setHora] = useState('');
  const [carros, setCarros] = useState([]);

  let a = new Date(Number(data.substring(0,4)),Number(data.substring(5,7))-1,Number(data.substring(8,10)),Number(hora.substring(0,2))-3,Number(hora.substring(3,6)));

  let b = a.toISOString().replace("T"," ").substring(0,19);
  

  const agendar = async () => {
    try {
      const m = {
        Carro : carro,
        Agendamento  : b
      };
      const response = await api.agendar(m, infos.idCliente);
      toast.dark('🚀 Agendado, espere a aprovação');
    } catch (e) {
      toast.error(e.response.data.msg);
    }
  };

  const consultarCarros = async () => {
    const response = await api.carros();
    setCarros(response.data);
  };

  useEffect(() => {
    consultarCarros();
  }, []);


    return (
      <div className="Tela">
  
        <div className="Container1"></div>
  
        <div className="Container2">
          <h1>Faça seu Agendamento</h1>
          <div className="Carross">
            <select name="Carros" id="cars" onChange={(e) => setCarro(e.target.value)}>
              <option value="Escolha seu Carro">Escolha seu Carro</option>
              {carros.map((item)=>(
                <option value={item.modelo}>{item.modelo}</option>
              ))}
            </select>
          </div> 
  
          <br></br>
  
          <div className="Data">
            Dia: 
            <input id="Dia" type="date" value={data} onChange={(e) => setData(e.target.value)}></input>
          </div>
  
          <br></br>
  
          <div className="Hora">
            Hora: 
            <input id="Hora" type="time" value={hora} onChange={(e) => setHora(e.target.value)}></input>
          </div>
            
  
          <div className="mt-4 mb-3">
            <button type="button" class="btn btn-primary" onClick={agendar}>Agendar!</button>
          </div>

          <Link to={{pathname:"/menuCliente", state: infos}}>Voltar para o menu</Link>
        </div>  
        <ToastContainer />
      </div>
    );
}