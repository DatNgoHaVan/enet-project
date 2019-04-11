import { combineReducers } from 'redux';

import {registration} from '../../SingUp/SignUpReduce';
import { alert } from './AlertReduce';
import {LoginReducer} from '../../Login/LoginReducer';
import {ManageUserReducer} from '../../ManageUser/ManageUserReducer';

const rootReducer = combineReducers({
    alert,
    registration,
    LoginReducer,
    ManageUserReducer,
});

export default rootReducer;