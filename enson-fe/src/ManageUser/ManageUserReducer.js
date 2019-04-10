import { userConstants } from '../redux/action/ActionType';

export const ManageUserReducer = (state = {getAll : false}, action) =>{
    switch (action.type) {
        case userConstants.GETALL_SUCCESS:
            return {
                getAll: true,
                listUser : action.list
            };
        default:
            return state
    }
}