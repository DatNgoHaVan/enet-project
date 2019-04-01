import { alertError } from './AlertAction';
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
                    if (res.ok) {
                        res.json().then(token => {
                            localStorage.setItem('token', token);
                            history.push('/');
                        })
                    }
                    if (res.status === 500) {
                        dispatch(alertError("Server isn't running"));
                    }
                    if (res.status === 401) {
                        dispatch(alertError("Username or password is not correct"));
                    }
                }
            );
    }
};
