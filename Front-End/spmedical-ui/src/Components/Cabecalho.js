import React, { useEffect, useState } from 'react';
import { useNavigate } from "react-router-dom";
// import { Link } from 'react-router-dom';
import {userAuth, parseJwt} from '../../src/services/auth';
import './Cabecalho.css'

import Logo from '../../src/assets/imagens/logo.png'
import local from '../../src/assets/imagens/icon/icon_local.png';
import phone from '../../src/assets/imagens/icon/icon_phone.png';
import mail from '../../src/assets/imagens/icon/icon_mail.png';
import facebook from '../../src/assets/imagens/icon/icons8-facebook-novo.svg';
import instagram from '../../src/assets/imagens/icon/icons8-instagram.svg';
import linkedin from '../../src/assets/imagens/icon/icons8-linkedin.svg';


export default function Cabecalho() {
    const [btnLoad, sebtnLoad] = useState(false);
    const [idTipo, setIdTipo] = useState(0)
  
    let history = useNavigate()

    function ValidarLoginbtn(){

        if(userAuth()){
          console.log('entrou')
          sebtnLoad(true)
          
          setIdTipo(parseJwt().Role)
          console.log(idTipo)
    
        }else{
          sebtnLoad(false)
          console.log('não está logado')
        }
    
      }
    
      function removerToken(){
        localStorage.removeItem('usuario-login')
    
        history('/')
    
      }
    
     useEffect(() => {
        ValidarLoginbtn()
      }, [btnLoad])

      return(
        <header>
        <nav className="informacoes">
                <div className="text_img">
                    <img src={local} alt="endereço" className="img_cabecalho"/>
                    <p className="cabeçalho_text">Av. Barão Limeira, 532, São Paulo, SP</p>
                </div>
                <div className="text_img">
                    <img src={phone} alt="telefone" className="img_cabecalho"/>
                    <p className="cabeçalho_text">(11) 2055-4477 | (11) 2055-7744</p>
                </div>
                <div className="text_img">
                <img src={mail} alt="email" className="img_cabecalho"/>
                    <p className="cabeçalho_text">spmedicalgroup@gmail.com</p>
                </div>
                <div id="redes">
                    <img src={facebook} alt="facebook" className="img_redes"/>
                    <img src={instagram} alt="instagram" className="img_redes"/>
                    <img src={linkedin} alt="linkedin" className="img_redes"/>
                </div>
            </nav>
        <div class="cabecalhoPrincipal">
            <div class="container">
                <img src={Logo} alt="logo Sp-Medical Group"/>
                <h1> MEDICAL GROUP</h1>
                <nav class="cabecalho-nav">
                    <a>Home</a>
                    <a>Médicos</a>
                    <a>Prontuários</a>
                    <a>Especialidades</a>
                    <a>Consultas</a>
                    { btnLoad === false &&  <button className = "btn_login" >Login</button>}
                    { btnLoad === true &&  <div>
                      {<button className = "btn_login" onClick={removerToken}>Sair</button>}   
                    </div>}
                </nav>
            </div>
        </div>
    </header>
      )
}
