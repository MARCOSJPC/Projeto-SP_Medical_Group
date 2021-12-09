import React, { useState, useEffect } from 'react';
import { StyleSheet, Text, View, ImageBackground, ScrollView, Mdal, TouchableOpacity} from 'react-native';
// import { Ionicons } from '@expo/vector-icons';
import api from '../../services/api';
import AsyncStorage from '@react-native-async-storage/async-storage';
import jwtDecode from 'jwt-decode';

export default function App({navigation}) {

  const [Lista, SetLista] = useState([]);

  const [idTipo, setIdTipo] = useState('');




  async function deslogar() {
    AsyncStorage.removeItem('@jwt')

    navigation.navigate('Login')
  }

  async function fazerLogin() {
    const TokenValor =  await AsyncStorage.getItem('@jwt')
        setIdTipo(jwtDecode(TokenValor).Role);
        
        const resposta = await api.get('/Usuario/consultas', {
        headers: {
            'Authorization': `Bearer  ${TokenValor}`
        }
        })

        console.log(resposta.data)
        SetLista(resposta.data);
    
    }

    

  useEffect(() =>{
    fazerLogin()
    // deslogar()

  }, [idTipo])




  return (
    <View>
    
      <View style={styles.Header}>  
        <TouchableOpacity
        onPress={() => deslogar()}
        >
          <Text style={{fontSize: 22, color: '#1F76DB'}}>Sair</Text>

        </TouchableOpacity>

      </View>

      
      <ImageBackground
        source={require('../Listar/img/fundoConsultas.png')}
        style={styles.BackGImage}
      > 
          <View style={{marginTop:30, marginBottom:40, paddingBottom:40 }}>
            <Text style={{fontSize:30, fontWeight: 'bold'}}>
              Consultas
            </Text> 
          </View>

          <ScrollView>
          {
            Lista.map(i =>{
              return(
              <View style={{width:350, height:140, backgroundColor:'#FFFF', borderRadius:8, justifyContent:'center',  marginTop:30}}>
                
                <View>
                  <Text style={{marginLeft: 12}}>
                    <Text style={{color: '#1F76DB', fontWeight: 'bold'}}> {idTipo === "3" ? 'Medico : ' : 'Paciente : '}</Text> 
                    {idTipo === "3" ? i.idMedicoNavigation.idUsuarioNavigation.nomeUsuario : i.idProntuarioNavigation.idUsuarioNavigation.nomeUsuario}
                  </Text>              
                </View>

                <View style={{ marginTop:8}}>
                  <Text style={{fontSize:14,marginLeft: 12,}}><Text style={{color: '#1F76DB', fontWeight: 'bold'}}>Data da Consulta: </Text>
                     {Intl.DateTimeFormat('pt-BR').format(new Date(i.dataConsulta))}
                  </Text>            
                </View>

                <View style={{ marginTop:8}}> 
                  <Text style={{fontSize:14,marginLeft: 12,}}><Text style={{color: '#1F76DB', fontWeight: 'bold'}}>Situação: </Text><Text style={i.idSituacaoNavigation.descricao === "Realizada" ? {color: '#3CB371', fontWeight: 'bold', fontSize:16} : i.idSituacaoNavigation.descricao === "Agendada" ? {color: '#E6D433', fontWeight: 'bold', fontSize:16} : {color: 'red', fontWeight: 'bold', fontSize:16}}>
                    {i.idSituacaoNavigation.descricao}</Text>
                  </Text>
                </View>
                 

                <View style={{marginTop: 8}}> 
                  <Text style={{fontSize:14,marginLeft: 12,}}><Text style={{color: '#1F76DB', fontWeight: 'bold'}}>Descrição: </Text><Text style={{fontSize:12}}>
                    {i.descricao}</Text>
                  </Text>
                </View>

            </View> 
              )
            }    
            )
          }
          </ScrollView>
       </ImageBackground>
          
          
      </View>
  );
}

    


const styles = StyleSheet.create({
  Header: {
    height: 80,
    justifyContent:'space-between',
    flexDirection: 'row',
    marginLeft:35,
    marginRight:90,
    alignItems:'center'
  },
  BackGImage: {
    width:'100%',
    height: '100%',
    alignItems: 'center',
    
  }
});