import { userConstants } from '../action/ActionType';

export const ViewUserReducer = (state = {}, action) =>{
    switch (action.type) {
        case userConstants.GET_USER_SUCCESS:
            return {
                user : action.user
            };
        default:
            return state
    }
}