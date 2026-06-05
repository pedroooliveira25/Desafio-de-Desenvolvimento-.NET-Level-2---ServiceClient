document.getElementById("btnNext").addEventListener("click", async function () {
    try {
        const step1 = JSON.parse(localStorage.getItem("step1"));
        const step2 = JSON.parse(localStorage.getItem("step2"));
        const step3 = JSON.parse(localStorage.getItem("step3"));

        const senha = document.getElementById("senha").value;
        const confirma = document.getElementById("confirma").value;

        if (!step1 || !step2 || !step3) {
            alert("Previous steps are incomplete");
            return;
        }

        if (!senha || !confirma) {
            alert("Please fill in the password fields");
            return;
        }

        if (senha !== confirma) {
            alert("Passwords do not match");
            return;
        }

        const payload = {
            DataBasic: step1,
            Financial: step2,
            Address: step3,
            Security: {
                Password: senha,
                ConfirmPassword: confirma
            }
        };

        const response = await fetch("http://localhost:8080/api/register/full", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(payload)
        });

        if (!response.ok) {
            const msg = await response.text();
            throw new Error(msg);
        }

        localStorage.clear();
        window.location.href = "../Validacao/validacao.html";

    } catch (error) {
        console.error("Flow error:", error);
        alert("Error while submitting registration");
    }
});