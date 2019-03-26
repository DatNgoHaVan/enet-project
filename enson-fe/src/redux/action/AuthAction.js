import AuthService from '../../services/AuthService'
import { alertActions } from './AlertAction';

class AuthAction{

    register = (user) =>{
        return dispatch =>{
            AuthService.register(user)
            .then(user =>{
                dispatch(alertActions.success('Registration successful'));
            })
            .then(error =>{
                dispatch(alertActions.error(error));
            })
        }
    }
}

export default AuthAction