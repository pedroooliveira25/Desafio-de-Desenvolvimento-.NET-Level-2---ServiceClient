document.getElementById("btnCadastrar").addEventListener("click", (e) => {
    e.preventDefault();

    const step1 = {
        name: document.getElementById("name").value,
        cpf: document.getElementById("cpf").value,
        email: document.getElementById("email").value,
        dateOfBirth: document.getElementById("dateOfBirth").value,
        phone: document.getElementById("phone").value
    };

    localStorage.setItem("step1", JSON.stringify(step1));

    window.location.href = "../DataFinancial/financeiro.html";
});