
const user1 = sessionStorage.getItem("user")
const jsonUser = JSON.parse(user1)
const loadPage = () => {
    const jsonUser = JSON.parse(user1)
    welcome.innerHTML = `hello to ${jsonUser.userName}`
    const userName3 = document.getElementById("userName3")
    userName3.value = jsonUser.userName
    const password3 = document.getElementById("password3")
    password3.value = jsonUser.password

    const firstName3 = document.getElementById("firstName3")
    firstName3.value = jsonUser.firstName

    const lastName3= document.getElementById("lastName3")
    lastName3.value = jsonUser.lastName
}



const update = async () => {
    var userId = jsonUser.userId
    alert(userId)
    var userName = document.getElementById("userName3").value
    var password = document.getElementById("password3").valu
    var firstName = document.getElementById("firstName3").value
    var lastName = document.getElementById("lastName3").value
    var User = { userId, userName, password, firstName, lastName }
    console.log(User)
    var url = 'api/user' + "/" + userId
    const res = await fetch(url, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(User)

    });

    const dataPost = await res.json();


}