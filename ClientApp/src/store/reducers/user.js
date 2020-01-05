import * as actions from '../actions/user';

export default (state = {
    user: {
        userName: '',
        email: '',
        role: ''
    }
}, action) => {
    switch (action.type) {
        case actions.SET_USER:
            return {
                ...state,
                user: action.user
            };
        default:
            return state;
    }
}