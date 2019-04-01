import { combineReducers } from 'redux';

import {registration} from '../../SingUp/SignUpReduce';
import { alert } from './AlertReduce';
import {LoginReducer} from '../../Login/LoginReducer';

const rootReducer = combineReducers({
    alert,
    registration,
    LoginReducer
});

export default rootReducer;