export const getAll = async () => {
    const token = localStorage.getItem('token');
    return await fetch('https://enson-project.herokuapp.com/api/user', {
        method: 'get',
        headers: { "Authorization": token }
    })
        .then(response => {
            return response;
        })
}