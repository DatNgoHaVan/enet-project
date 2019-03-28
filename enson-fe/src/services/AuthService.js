export const register = async (user) => {
    return await fetch('http://localhost:5000/api/register/', {
        method: 'post',
        body: JSON.stringify(user),
        headers: { "Content-Type": "application/json" }
    })
        .then(response => {
            return response;
        })
}

export const login = async (user) => {
    return await fetch('http://localhost:5000/api/login/', {
        method: 'post',
        body: JSON.stringify(user),
        headers: { "Content-Type": "application/json" }
    })
        .then(response => {
            return response;
        })
}
