import React from 'react';
import { TouchableOpacity, Image } from 'react-native';

export const DeleteIcon = ({onClick}) => {

    return(
        <TouchableOpacity onPress={onClick} >
            <Image source={require('../../assets/tabIcons/delete.png')} style={{ height: 20, width: 20}}/>
        </TouchableOpacity>
    )
}