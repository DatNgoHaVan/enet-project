import { combineReducers } from 'redux';

import { registration } from './AuthReducer';
import { alert } from './AlertReducer'

export const rootReducer = combineReducers({
    registration,
    alert
});
