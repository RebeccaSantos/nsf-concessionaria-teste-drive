import React from 'react';
import "./style.css";
import { Link } from 'react-router-dom';


export default function Login(){
    return(
        <div className="Login">

            <div>
                <input type="text"> Login: </input>
            </div>
            <div>
                <input type="text"> Senha: </input>
            </div>

        </div>
    )
}