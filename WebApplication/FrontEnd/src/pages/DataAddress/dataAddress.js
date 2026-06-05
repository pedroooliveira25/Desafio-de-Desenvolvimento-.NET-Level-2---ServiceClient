document.getElementById("btnNext").addEventListener("click", function () {

    const data = {
        rua: document.getElementById("rua").value,
        numero: document.getElementById("numero").value,
        bairro: document.getElementById("bairro").value,
        cidade: document.getElementById("cidade").value,
        estado: document.getElementById("estado").value,
        cep: document.getElementById("cep").value
    };

    localStorage.setItem("step3", JSON.stringify(data));

    window.location.href = "../DataSecurity/seguranca.html";
});