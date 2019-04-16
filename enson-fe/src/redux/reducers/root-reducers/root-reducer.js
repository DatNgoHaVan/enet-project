import { combineReducers } from 'redux';

import {registration} from '../../SingUp/SignUpReduce';
import { alert } from '../alert-reducer';
import {LoginReducer} from '../../Login/LoginReducer';
import {ManageUserReducer} from '../../ManageUser/ManageUserReducer';
import {ViewUserReducer} from '../../ManageUser/ViewUser/ViewUserReducer';

const rootReducer = combineReducers({
    alert,
    registration,
    LoginReducer,
    ManageUserReducer,
    ViewUserReducer
});

export default rootReducer;