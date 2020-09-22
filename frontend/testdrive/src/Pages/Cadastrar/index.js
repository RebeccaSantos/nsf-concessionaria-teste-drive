import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import React, { useState, useEffect, useRef } from 'react';
import { Link } from 'react-router-dom';
import './style.css';

import testDriveAPI from "../../Service/TestDriveApi";

const api = new testDriveAPI();

export default function Cadastrar() {
  const [nome, setNome] = useState('');
  const [cpf, setCpf] = useState('');
  const [carro, setCarro] = useState('');
  const [data, setData] = useState(new Date().toISOString().substr(0, 10));
  const [funcionario, setFuncionario] = useState('');
  const [situacao, setSituacao] = useState(true);
  

  const salvar = async () => {
    const response = await api.agendar({
      id   : id,
      nome : nome,
      cpf  : cpf,
      carro : carro,
      data  : data,
      funcionario : funcionario,
      situacao : situacao
    });
    toast.dark('🚀 Agendado, espere a aprovação de um funcionario');

    
  }

    const atualizarEstado = (e) => {
      let novoValor = e.target.value;
      if (e.target.type === 'number') 
        novoValor = Number(novoValor);
      else if (e.target.type === 'checkbox') 
        novoValor = e.target.checked;
  
      switch (e.target.id) {
        case 'nome': setNome(novoValor); break;
        case 'cpf': setCpf(novoValor); break;
        case 'carro': setCarro(novoValor); break;
        case 'data': setData(novoValor); break;
        case 'funcionario': setFuncionario(novoValor); break;
        case 'situacao': setSituacao(novoValor); break;
        default:
          break;
      }
    };


    return (
      <div className="Tela">
          <div className="button-Voltar">
              <Link to="/menu">Voltar para menu</Link>
          </div>
        <div className="Container1">
            
        </div>
  
        <div className="Container2">
        <h1>Faça seu Agendamento</h1>
          <div className="Carross">
            
            <select name="Carros" id="cars">
                <option value="Escolha seu Carro">Escolha seu Carro</option>
                <option value="Sedan">Sedan</option>
                <option value="volvo">Volvo</option>
                <option value="saab">Saab</option>
                <option value="mercedes">Mercedes</option>
                <option value="audi">Audi</option>
            </select>
          </div> 
  
            <br></br>
  
            <div className="Data">
              Dia
              <input type="date"></input>
            </div>
  
            <br></br>
  
            <div className="Hora">
              Hora
              <input type="time"></input>
            </div>
            
  
            

            <div className="button">
                <button type="button" class="btn btn-primary" onClick={salvar}>Agendar!</button>
            </div>

            
        </div>
        
  
        
      </div>
    );
} 