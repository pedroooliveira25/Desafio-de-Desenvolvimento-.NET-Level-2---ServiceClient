document.getElementById("btnNext").addEventListener("click", () => {

    const patrimonioEl = document.getElementById("patrimonio");
    const rendaEl = document.getElementById("renda");

    if (!patrimonioEl || !rendaEl) {
        console.error("Inputs não encontrados");
        return;
    }

    const patrimony = parseFloat(
        patrimonioEl.value.replace(/\./g, "").replace(",", ".")
    );

    const finance = parseFloat(
        rendaEl.value.replace(/\./g, "").replace(",", ".")
    );

    if (isNaN(patrimony) || isNaN(finance)) {
        alert("Valores financeiros inválidos");
        return;
    }

   const step2 = {
    Finance: finance,
    Patrimony: patrimony
};

    localStorage.setItem("step2", JSON.stringify(step2));

    window.location.href = "../DataAddress/address.html";
});