import React, { useState } from 'react';
import { useNavigate } from "react-router-dom";
import axios from 'axios';

import { parseJwt} from '../../services/auth';
import { Link } from 'react-router-dom';
//import { useNavigate } from "react-router-dom";

import '../../assets/css/login.css';
import '../../Components/Cabecalho.css';


import logo from '../../assets/imagens/logo.png';
import local from '../../assets/imagens/icon/icon_local.png';
import phone from '../../assets/imagens/icon/icon_phone.png';
import mail from '../../assets/imagens/icon/icon_mail.png';
import facebook from '../../assets/imagens/icon/icons8-facebook-novo.svg';
import instagram from '../../assets/imagens/icon/icons8-instagram.svg';
import linkedin from '../../assets/imagens/icon/icons8-linkedin.svg';
import username from '../../assets/imagens/icon/person_white.png';
import cadeado from '../../assets/imagens/icon/lock_white.png';

export default function Login() {

  const [email, setEmail] = useState('');
  const [pwd, setPwd] = useState('');
  const [isLoading]=useState(false);

  const [error, setError] = useState('')

  let history = useNavigate();


  function fazerlogin(event) {

    event.preventDefault();
      
    setError('')

    axios.post('http://localhost:5000/api/Login', {
      Email: email,
      Senha : pwd
    })
    .then(rs =>
      { 
        localStorage.setItem('usuario-login', rs.data.token);
        history('/Consultas')
        
      })
      .catch(() => {
        setError( 'E-mail ou senha inválidos.')
      })

      console.log(email)
      console.log(pwd)
    }

    return (
    <div >
      <header>
          <nav className="informacoes">
            <div className="text_img">
              <img src={local} alt="endereço" className="img_cabecalho" />
              <p className="cabeçalho_text">Av. Barão Limeira, 532, São Paulo, SP</p>
            </div>
            <div className="text_img">
              <img src={phone} alt="telefone" className="img_cabecalho" />
              <p className="cabeçalho_text">(11) 2055-4477 | (11) 2055-7744</p>
            </div>
            <div className="text_img">
              <img src={mail} alt="email" className="img_cabecalho" />
              <p className="cabeçalho_text">spmedicalgroup@gmail.com</p>
            </div>
            <div id="redes">
              <img src={facebook} alt="facebook" className="img_redes" />
              <img src={instagram} alt="instagram" className="img_redes" />
              <img src={linkedin} alt="linkedin" className="img_redes" />
            </div>
          </nav>
      </header>
        
      <main className ="main_L">
        <div className="bg-login">
          <div className="form-login">
              <div className="item">
                <Link to="/">
                  <img
                    src={logo}
                    className="icone_login"
                    alt="logo spmedical"
                  />{' '}
                </Link>
              </div>

              <form onSubmit={fazerlogin}>
                <div className="item">
                  <img src={username} alt="username" class="img_form" />
                  <input
                    className="input_login"
                    type="text"
                    name="email"
                    // define que o input email recebe o valor do state email
                    value={email}
                    // faz a chamada para a função que atualiza o state, conforme o usuário altera o valor do input
                    onChange={event => setEmail(event.target.value)}
                    placeholder="Email"
                  />
                </div>
                <div className="item">
                  <img src={cadeado} alt="password" class="img_form" />
                  <input
                    className="input_login"
                    // senha
                    type="password"
                    name="senha"
                    // define que o input senha recebe o valor do state senha
                    value={pwd}
                    // faz a chamada para a função que atualiza o state, conforme o usuário altera o valor do input
                    onChange={event => setPwd(event.target.value)}
                    placeholder="Senha"
                  />
                </div>
                <div className="item">
                  {/* Exibe a mensagem de erro ao tentar logar com credenciais inválidas */}
                  <p className="msgErro">{error}</p>

                  {/* 
                                            Verifica se a requisição está em andamento
                                            Se estiver, desabilita o click do botão
                                        */}

                  {
                    // Caso seja true, renderiza o botão desabilitado com o texto 'Loading...'
                    isLoading === true && (
                      <button
                        type="submit"
                        disabled
                        className="btn ativado"
                      >
                        Loading...
                      </button>
                    )
                  }

                  {
                    // Caso seja false, renderiza o botão habilitado com o texto 'Login'
                    isLoading === false && (
                      <button
                        className="btn btn_ativado"
                        type="submit"
                        disabled={
                          email === '' || pwd === ''
                            ? 'none'
                            : ''
                        }
                      >
                        Login
                      </button>
                    )
                  }
                </div>
              </form>
            </div>
          </div>
      </main>
    </div>
    );
  }
