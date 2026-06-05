document.getElementById("btnNext").addEventListener("click", function () {

    const data = {
        Road: document.getElementById("rua").value,
        District: document.getElementById("bairro").value,
        City: document.getElementById("cidade").value,
        Stage: document.getElementById("estado").value,
        Cep: parseInt(document.getElementById("cep").value),
        Number: parseInt(document.getElementById("numero").value)
    };

    localStorage.setItem("step3", JSON.stringify(data));

    window.location.href = "../DataSecurity/seguranca.html";
});