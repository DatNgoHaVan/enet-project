import {register} from '../../services/AuthService'
import { alertActions } from './AlertAction';
import { userConstants } from './ActionType';

    export const registerAction = (user) => {
        console.log(user);
        return async dispatch => {
            dispatch(request(user));
            console.log(123);
            await register(user)
                .then(user => {
                    dispatch(success());
                    console(user);
                    dispatch(alertActions.success('Registration successful'));
                })
                .then(error => {
                    console.log(error);
                    dispatch(alertActions.error(error));
                })
        }
        function request(user) { return { type: userConstants.REGISTER_REQUEST, user } }
        function success(user) { return { type: userConstants.REGISTER_SUCCESS, user } }
        function failure(error) { return { type: userConstants.REGISTER_FAILURE, error } }
    }

    

    export const registerSuccess = (user) => ({
        type: userConstants.REGISTER_SUCCESS,
        user
    })
