import React from "react";
import "./style.css";

export default function Cadastrar() {

  return (
    <div className="Tela">

      <div className="Container1">
          
      </div>

      <div className="Container2">
      <h1>Fazer Agendamento</h1>
        <div className="Carross">
          Carro   
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

          <div>
            Dia
            <input type="date"></input>
          </div>

          <br></br>

          <div>
            Hora
            <input type="time"></input>
          </div>
          <div className="button">
              <button type="button" class="btn btn-primary">Primary</button>
          </div>
      </div>
      

      
    </div>
  );
}
