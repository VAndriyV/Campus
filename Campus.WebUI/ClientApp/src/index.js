import 'bootstrap/dist/css/bootstrap.css';
import "react-datepicker/dist/react-datepicker.css"
import React from 'react';
import ReactDOM from 'react-dom';
import App from './components/app';
import registerServiceWorker from './registerServiceWorker';

import './index.css';

const rootElement = document.getElementById('root');

ReactDOM.render(  
    <App />,
  rootElement);

registerServiceWorker();

