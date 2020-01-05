export const SET_USER = "SET_USER";

export function set_user(user) {
    return {
        type: "SET_USER",
        user
    };
}