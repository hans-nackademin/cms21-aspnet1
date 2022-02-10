document.getElementById('signInForm').addEventListener('submit', function(e) {
    e.preventDefault()

    let user = {
         email: e.target['email'].value,
         password: e.target['password'].value
    }

    fetch('https://localhost:7145/api/Authentication/SignIn', {
        method: 'post',
        body: JSON.stringify(user),
        headers: {
            "Content-Type": "application/json"
        }
    })
    .then(res => res.text())
    .then(data => {
        if(data == "email address and password must be provided" || data == "incorrect email address or password")
            document.getElementById('errorMessage').innerText = data 
        else {
            sessionStorage.setItem('accessToken', data)
            location.href = 'products.html';
        }          
    })
})