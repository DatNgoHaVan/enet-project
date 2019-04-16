import {userConstants} from './ActionType';
import { getUserById } from '../../services/UserService';

export const getUser = (id) =>{
    return dispatch =>{
        getUserById(id).then(async res =>{
            if(res.ok){
                await res.json().then(user =>{
                    dispatch(getUserSuccess(user));
                })
            }
        })
    }
}

export const getUserSuccess = (user) =>{
    return {
        type : userConstants.GET_USER_SUCCESS,
        user
    }
}