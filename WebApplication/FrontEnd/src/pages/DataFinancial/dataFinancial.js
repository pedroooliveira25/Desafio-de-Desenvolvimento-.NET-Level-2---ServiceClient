document.getElementById("btnNext").addEventListener("click", () => {

    localStorage.setItem("patrimonio", document.getElementById("patrimonio").value);
    localStorage.setItem("renda", document.getElementById("renda").value);

    window.location.href = "../DataAddress/address.html"; 
});