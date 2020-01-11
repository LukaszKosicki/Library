export const SET_USER = "SET_USER";
export const NOT_LOGGED = "NOT_LOGGED";

export function set_user(user) {
    return {
        type: "SET_USER",
        user
    };
}

export function isNotLogged() {
    return {
        type: "NOT_LOGGED"
    }
}