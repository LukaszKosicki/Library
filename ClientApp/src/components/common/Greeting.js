import React from 'react';

const Greeting = ({ userName }) => {
    return (
        <div className="mb-4">
            <h1>Panel użytkownika</h1>
            <strong>{userName}</strong>
        </div>
    )
}

export default Greeting;