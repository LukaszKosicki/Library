import * as actions from '../actions/user';

export default (state = {
    user: {
        userName: '',
        email: '',
        role: '',
        id: '',
        isLogged: false
    }
}, action) => {
    switch (action.type) {
        case actions.SET_USER:
            return {
                ...state,
                user: action.user
            };
        case actions.NOT_LOGGED:
            return {
                ...state,
                user: {
                    user: {
                        isLogged: false
                    }
                }
            }
        default:
            return state;
    }
}