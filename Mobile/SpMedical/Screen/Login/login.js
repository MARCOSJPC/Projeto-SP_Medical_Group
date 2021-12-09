import { StatusBar } from 'expo-status-bar';
import React, { useState, useEffect } from 'react';
import { StyleSheet, Text, View, ImageBackground, Image, TextInput, TouchableOpacity} from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import api from '../../services/api';


export default function App( { navigation }) {

  const [OpenV] = useState(true)

  const [dataLogin, setDataLogin] = useState({
    Email: '',
    Senha: ''
});
  const [statusResponse, setStatusResponse] = useState('200')

  async function fazerLogin() {
    try {

      const response = await api.post('/Login', dataLogin)
      console.log(response.data.token)

      setStatusResponse('200')

      await AsyncStorage.setItem('@jwt', response.data.token);
      

      navigation.navigate("Listar") 

    } catch (error) {
      setStatusResponse('404')
    }

      
}
// useEffect(() =>{
//   fazerLogin()

// }, [])



  return (
    <View>
      <ImageBackground
        source={require('../Login/img/fundoLogin.png')}
        style={styles.BackGImage}
      > 
        {/* <View>
            <Image
              source={require('../Login/image/Grupo_de_mascara1.png')}
              style={styles.IconeMed}
            ></Image>
        </View>    */}
    <View style={styles.loginForm}>
        <TextInput
          placeholderTextColor="#1F76DB"
          style={styles.BorderInput}
          placeholder='Email '
          value={dataLogin.email}
          onChangeText={text => setDataLogin({
            ...dataLogin,
            Email: text
        })}        />

        <TextInput
          placeholderTextColor="#1F76DB"
          style={styles.BorderInput}
          placeholder='Senha '
          secureTextEntry={true} //proteje a senha.
          value={dataLogin.senha}
          onChangeText={text => setDataLogin({
            ...dataLogin,
            Senha: text
        })}
        />
        
      </View>  
      <TouchableOpacity 
      onPress={() => fazerLogin()}
      style={
        {width:'50%',
        backgroundColor:'#1F76DB', 
        height: 45 ,  
        alignItems:'center', 
        justifyContent:'center',
        marginTop: 30,}}>
        <Text style={{ color: '#FFFFFF', fontWeight: 'bold', fontSize:17}}>Login</Text>
      </TouchableOpacity>    
                
     </ImageBackground>   
      
    <StatusBar hidden={OpenV}/>
    </View>
  );
}
      


  

const styles = StyleSheet.create({
  BackGImage: {
    width:'100%',
    height: '100%',
    alignItems: 'center',
    justifyContent: 'center',
  },
  
    BorderInput:{
      borderWidth:2,
      width: 300,
      height: 45,
      marginTop: 30,
      marginBottom: 0,
      borderColor: '#1F76DB',
      paddingLeft: 15,
      backgroundColor:'#FFFFFF',
      fontWeight: 'bold',

    }



});