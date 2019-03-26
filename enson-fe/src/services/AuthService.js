class AuthService{
    register = async (user) =>{
        await fetch('http://localhost:5000/api/register/',{
            method :'post',
            body : JSON.stringify(user),
            headers: {"Content-Type" : "application/json"}})
        .then(response =>{
            return response.json();
        })
    }
}

export default AuthService;
