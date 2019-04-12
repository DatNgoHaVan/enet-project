import {getAll} from '../services/UserService';
import { userConstants } from '../redux/action/ActionType';

export const getAllUserAction = () =>{
    return dispatch =>{
        getAll().then(async res =>{
            console.log(res);
            if(res.ok){
                await res.json().then(list =>{
                    console.log(list);
                    dispatch(getAllSuccess(Array.from(list)));
                })
            }
        })
    }
}

export const getAllSuccess = (list) =>{
    return {
        type : userConstants.GETALL_SUCCESS,
        list
    }
}