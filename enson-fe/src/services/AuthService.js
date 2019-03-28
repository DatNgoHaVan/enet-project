export const register = async (user) => {
    await fetch('http://localhost:5000/api/register/', {
        method: 'post',
        body: JSON.stringify(user),
        headers: { "Content-Type": "application/json" , "Access-Control-Allow-Origin" : "*"}
    })
        .then(response => {
            console.log(response.json());
            return response.json();
        })
}

