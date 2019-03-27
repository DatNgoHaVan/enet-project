import { createStore, applyMiddleware } from 'redux';
import thunkMiddleware from 'redux-thunk';
import { createLogger } from 'redux-logger';

import {rootReducer} from '../reducers/RootReducer';

const loggerMiddleware = createLogger();

export const store = createStore(
    rootReducer
);
