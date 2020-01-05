import React from 'react';

const Greeting = ({ userName, userSurname }) => {
    return (
        <div className="mb-4">
            <h1>Panel użytkownika</h1>
            <strong>{userName} {userSurname}</strong>
        </div>
    )
}

export default Greeting;