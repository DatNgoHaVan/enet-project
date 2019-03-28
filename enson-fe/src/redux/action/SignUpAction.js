import { register } from '../../services/AuthService';
import { history } from '../History';
import { alertSuccess, alertError } from './AlertAction';
import { userConstants } from '../action/ActionType';

export const registerAction = (user) => {
    return dispatch => {
        register(user).then(res => {
            if (res.status === 201) {
                dispatch(success())
                history.push('/login')
                dispatch(alertSuccess('Registration successful'));
            }
            else {
                return res.text().then(text =>{
                    dispatch(alertError(text));
                });
            }
        })
    }
    function success(user) { return { type: userConstants.REGISTER_SUCCESS, user } }
}