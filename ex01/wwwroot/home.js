//I recommend to change the project name to webApiShopSite etc.
const register = async () => {
    ///Use const if you don't change the variable
    var userName = document.getElementById("userNameRegister").value
    var password = document.getElementById("passwordRegister").value

    var firstName = document.getElementById("firstName").value
    var lastName = document.getElementById("lastName").value
    var user = { userName, password, firstName, lastName }
     //const User = { UserName:userName, Password:password, FirstName:firstName, LastName:lastName }, Prefix -UpperCase 
    try {
        const res = await fetch('api/User', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        //Check response status code- if response is 400- validation errors, if status==200  alert a suitable message...-registration succeeded etc. 
        const dataPost = await res.json();
    }
    catch (er) {
       //Alerting errors to the user is not recommended, log them to the console.
       alert(er.message)
    }
}
var users;
const login = async () => {
    try {
        var userNameLogin = document.getElementById("userNameLogin").value
        var passwordLogin = document.getElementById("passwordLogin").value
        //use `` for js strings with variables ex:userName=`${userNameLogin}`
        var url = 'api/User' + "?" + "userName=" + userNameLogin
            + "&password=" + passwordLogin;
        const res = await fetch(url,);
        console.log(res)
        if (!res.ok) {
            throw new Error("eror!!!")
            //Alert: userName or password incorrect try again....
        }
        else {
            var data = await res.json()
            sessionStorage.setItem("user", JSON.stringify(data))

            window.location.href = "./update.html"

        }
    }
    catch (er) {
        alert(er.message)
    }
    


}
const checkCode = async () => {
    var strength = {
        0: "Worst",
        1: "Bad",
        2: "Weak",
        3: "Good",
        4: "Strong"
    }
    var meter = document.getElementById('password-strength-meter');
    var text = document.getElementById('password-strength-text');
    const Code = document.getElementById("passwordRegister").value;
    const res = await fetch('api/User/check', {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(Code)
    })
    if (!res.ok)
        throw new Error("error in adding your details to our site")
    const data = await res.json();
    if (data <= 2) alert("your password is weak!! try again")
    meter.value = data;

    if (Code !== "") {
        text.innerHTML = "Strength: " + strength[data.score];
    } else {
        text.innerHTML = "";
    }

}
