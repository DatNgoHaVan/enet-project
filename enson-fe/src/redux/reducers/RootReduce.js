import { combineReducers } from 'redux';

import {registration} from './SignUpReduce';
import { alert } from './AlertReduce';
import {LoginReducer} from './LoginReducer';

const rootReducer = combineReducers({
    alert,
    registration,
    LoginReducer
});

export default rootReducer;