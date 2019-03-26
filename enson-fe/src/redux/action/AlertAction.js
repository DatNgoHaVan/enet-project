import { alertConstants } from './ActionType';

export class alertActions {
    
    success(message) {
        return { type: alertConstants.SUCCESS, message };
    }

    error(message) {
        return { type: alertConstants.ERROR, message };
    }

    clear() {
        return { type: alertConstants.CLEAR };
    }
}