if(sessionStorage.getItem('accessToken') == null) {
    location.href = 'login.html';
}
else {
    fetch("https://localhost:7145/api/products", {
        headers: {
            "authorization": `bearer ${sessionStorage.getItem('accessToken')}`
        }
    })
    .then(res => res.json())
    .then(data => {
        data.forEach(p => {
            document.getElementById('result').innerHTML += `<p>${p.name}</p>`
        })
    })
}

function signOut() {
    sessionStorage.removeItem("accessToken");
    location.href = 'products.html';
}