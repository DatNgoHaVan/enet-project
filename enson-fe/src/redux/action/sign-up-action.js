import { register } from '../../services/AuthService';
import { history } from '../history';
import { alertSuccess, alertError } from './AlertAction';
import { userConstants } from './ActionType';

export const registerAction = (user) => {
    return dispatch => {
        register(user).then(res => {
            if (res.status === 201) {
                dispatch(success())
                history.push('/login')
                dispatch(alertSuccess('Registration successful'));
            }
            if(res.status === 500){
                dispatch(alertError("Server isn't running"));
            }
            if(res.status ===400){
                return res.text().then(text =>{
                    dispatch(alertError(text));
                });
            }
        })
    }
    function success(user) { return { type: userConstants.REGISTER_SUCCESS, user } }
}