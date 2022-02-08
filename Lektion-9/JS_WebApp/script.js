document.getElementById("btnGetProducts").addEventListener("click", function(e) {
    fetch("https://localhost:7136/api/products?code=M2I5MTdkZTctMWQ2Ny00NzU1LTg3MmEtZTk3MzQ0MTIyN2Rm")
    .then(res => res.json())
    .then(data => console.log(data))
});

document.getElementById("productForm").addEventListener("submit", function(e) {
    e.preventDefault();

    if(e.target["name"].value != "" && e.target["description"].value != "" && e.target["price"].value != "") {
        let product = {
            name: e.target["name"].value,
            description: e.target["description"].value,
            price: Number(e.target["price"].value)
        }
    
        e.target["name"].value = ""
        e.target["description"].value = ""
        e.target["price"].value = ""
    
        fetch("https://localhost:7136/api/products", {
            method: 'post',
            body: JSON.stringify(product),
            headers: {
                "Content-Type": "application/json",
                "Code": "ZjFkOTI3OTUtMjZiZS00NDIwLWJjMTMtYTA3YTZlYzI3N2Q5"
            }
        })
        .then(res => res.json())
        .then(data => console.log(data))
    }
})

