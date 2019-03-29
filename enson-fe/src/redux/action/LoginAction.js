import { alertError } from './AlertAction';
import { userConstants } from './ActionType';
import { history } from '../History';
import { login } from '../../services/AuthService'

export const loginAction = (username, password) => {
    return dispatch => {
        const user = {
            username: username,
            password: password
        }
        login(user)
            .then(
                res => {
                    if (res.status === 200) {
                        res.json().then(token => {
                            localStorage.setItem('token', token);
                        })
                        history.push('/');
                    }
                    if(res.status === 500){
                        dispatch(alertError("Server is not run"));
                    }
                    if(res.status === 401) {
                        dispatch(alertError("Username or password is not correct"));
                    }
                }
            );
    }
};
