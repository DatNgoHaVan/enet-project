import { alertError } from '../redux/action/AlertAction';
import { history } from '../redux/History';
import { login } from '../services/AuthService';

function parseJwt (token) {
    console.log(token);
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    return JSON.parse(window.atob(base64));
};

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
                            localStorage.setItem('role',parseJwt(token.token).role)
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
