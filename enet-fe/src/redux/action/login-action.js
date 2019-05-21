import { alertError } from './alert-action';
import { history } from '../history';
import { login } from '../../services/AuthService';
import { parseJwt } from '../../components/comment';

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
                            localStorage.setItem('token',"Bearer " + token.token);
                            localStorage.setItem('tokenB', token.token);
                            localStorage.setItem('role',parseJwt(token.token).role);
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
