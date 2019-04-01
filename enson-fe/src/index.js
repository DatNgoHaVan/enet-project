import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';

import './index.css';
import {App} from './App';
import * as serviceWorker from './serviceWorker';
import {store} from './redux/Store';
import DashBoard from './DashBoard/DashBoard';

ReactDOM.render(
    <Provider store={store}>
        <DashBoard />
    </Provider>,
    document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();