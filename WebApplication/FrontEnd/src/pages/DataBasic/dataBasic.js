document.getElementById("btnCadastrar").addEventListener("click", (e) => {
    e.preventDefault();

    localStorage.setItem("name", document.getElementById("name").value);
    localStorage.setItem("cpf", document.getElementById("cpf").value);
    localStorage.setItem("email", document.getElementById("email").value);
    localStorage.setItem("dateOfBirth", document.getElementById("dateOfBirth").value);
    localStorage.setItem("phone", document.getElementById("phone").value);

    window.location.href = "../DataFinancial/financeiro.html";
});