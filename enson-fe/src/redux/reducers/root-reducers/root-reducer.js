import { combineReducers } from 'redux';

import {registration} from '../../reducers/sign-up-reducer';
import { alert } from '../alert-reducer';
import {LoginReducer} from '../../reducers/login-reducer';
import {ManageUserReducer} from '../../reducers/manage-user-reducer';
import {ViewUserReducer} from '../../reducers/view-user-reduce';

const rootReducer = combineReducers({
    alert,
    registration,
    LoginReducer,
    ManageUserReducer,
    ViewUserReducer
});

export default rootReducer;