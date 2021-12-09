import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';

import Login from './Screen/Login/login'
import Listar from './Screen/Listar/listar'

const AuthStack = createStackNavigator();


export default function App() {
  return (
    <NavigationContainer >
        <AuthStack.Navigator
          headerMode = 'none'
        >

        <AuthStack.Screen name = 'Login' component={Login} />

        <AuthStack.Screen name = 'Listar' component={Listar} />

    </AuthStack.Navigator>
  </NavigationContainer>
  );
}