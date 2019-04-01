export const register = async (user) => {
    return await fetch('https://enson-project.herokuapp.com/api/register', {
        method: 'post',
        body: JSON.stringify(user),
        headers: { "Content-Type": "application/json" }
    })
        .then(response => {
            return response;
        })
}

export const login = async (user) => {
    return await fetch('https://enson-project.herokuapp.com/api/login', {
        method: 'post',
        body: JSON.stringify(user),
        headers: { "Content-Type": "application/json" }
    })
        .then(response => {
            return response;
        })
}
