import React, {useState, useEffect} from 'react';
import axios from 'axios';
import Cabecalho from  '../../Components/Cabecalho';
import {parseJwt} from '../../services/auth';
import Add from '../../assets/imagens/icon/add.png'
import { useNavigate } from "react-router-dom";


import '../../assets/css/Consultas.css';

export default function Consultas(){
	const [listaConsultas, setListarConsultas] = useState ([]);
    const [idtipo, setidtipo] = useState(0);
    let history = useNavigate();

function buscarConsultas(){
    setidtipo(parseJwt().Role)
    
    
    console.log('idTipoUsuario: '+parseJwt().Role)
    console.log('fazendo a chamada para a API.')
    axios('http://localhost:5000/api/Usuario/consultas', {
             headers:{
                 'authorization' : 'Bearer '+ localStorage.getItem('usuario-login')
             }
         })
        .then(response => {
                console.log(response.data)
                setListarConsultas(response.data)
                // console.log(buscarConsultas)
               
        })
  
    }    

         
useEffect( buscarConsultas, []);

	return(
	<div className="bg">
        <Cabecalho/>
        <div  >
    <main className="conteudoPrincipal">
            
            <h2 className="titulo">CONSULTAS</h2>
            <hr/>
        <div className="container" id="listaConsultas">
            <h3 className="subtitulo">Lista de Consultas</h3>
            
        {
        listaConsultas.map(l => {
            return(
                
                <div className="card1" key={l.idProntuario}>
                    <div>
                        <div className="card2">
                            <p>{idtipo === "3" ? "Medico : " : "Paciente : "}</p>
                            <p className="TxtLado">{idtipo === 3 ? l.idMedicoNavigation.idUsuarioNavigation.nomeUsuario : l.idProntuarioNavigation.idUsuarioNavigation.nomeUsuario}</p>
                        </div>

                        <div className="card2">
                            <p>Data :</p>
                            <p className="TxtLado">{Intl.DateTimeFormat("pt-BR").format(new Date(l.dataConsulta))}</p>
                        </div>
                        <div className="card2">
                            <p>Descrição :</p>
                            <p className="TxtLado">{l.descricao}</p>
                            {idtipo === "2" && 
                            //<Link to="/descricao" >
                            <img src={Add} style={{width: 21, height: 21, marginLeft: 5, marginTop: 12,}}/>
                            //</Link>
                            
                            }
                            
                            
                        </div>
                    </div>
                    <div>
                        <div className="card2">
                            <p>Status : </p>
                            <p className="TxtLado">{l.idSituacaoNavigation.descricao}</p>
                        </div>
                        <div className="card2">
                            <p>Especialidade : </p>
                            { <p className="TxtLado">{l.idMedicoNavigation.idEspecialidadeNavigation.tipoEspecialidade}</p> }
                        </div>
                        <div className="card2">
                            {idtipo === "1" && <p>Medico : </p>}
                            {idtipo === "1" && <p className="TxtLado">{l.idMedicoNavigation.idUsuarioNavigation.nomeUsuario}</p>}
                        </div>
                    </div>
                </div> 
                      
            )
        })
        }
        
        </div>
        {idtipo === "1"  &&
        <div className="AgendarConsulta">
            <h3 className="subtitulo"> Agendar Consulta</h3>
            <input className="input-agendar" type="text" placeholder="ID Prontuario"/>
            <input className="input-agendar" type="text" placeholder="ID Médico"/>
            <input className="input-agendar" type="text" placeholder="Data da Consulta"/>
            <input className="input-agendar" type="text" placeholder="Descrição"/>
            <input className="input-agendar" type="text" placeholder="Situação"/>
            <button className="btn">
                Agendar
            </button>
        </div>}

        {/* { export default function Descricao() {
                return ( 
                <body>
                    <Pagetopo />
                
                        <div className="container">
                            <div className="box">
                                <div className="DivDesc">
                                    <p className="Desctxt">Descrição :</p>
                                    <input className="inputDescricao"/>
                                </div>
                                <button className="btn">Salvar</button>
                            </div>
                        </div>
                    
                </body>
  );
}

export default } */}
    </main>
    </div>
</div>
	)
}