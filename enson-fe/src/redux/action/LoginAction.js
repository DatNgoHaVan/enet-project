import { alertError } from './AlertAction';
import { userConstants } from './ActionType';
import { history } from '../History';
import { login } from '../../services/AuthService'

export const loginAction = (username, password) => {
    return dispatch => {
        dispatch(request(username));

        login(username, password)
            .then(
                user => {
                    dispatch(success(user));
                    history.push('/');
                },
                error => {
                    dispatch(failure(error));
                    dispatch(alertError(error));
                }
            );
    };

    function request(user) { return { type: userConstants.LOGIN_REQUEST, user } }
    function success(user) { return { type: userConstants.LOGIN_SUCCESS, user } }
    function failure(error) { return { type: userConstants.LOGIN_FAILURE, error } }
}