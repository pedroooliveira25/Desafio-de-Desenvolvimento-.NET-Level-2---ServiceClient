document.getElementById("btnSalvarSenha").addEventListener("click", async () => {

    const password = {
        password: document.getElementById("password").value
    };

    const response = await fetch(
        "https://localhost:8080/api/password",
        {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(password)
        }
    );

    const result = await response.json();

    console.log(result);
});