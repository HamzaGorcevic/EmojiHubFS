async function register() {
    var regUsername = document.getElementById("regUsername").value;
    var regPassword = document.getElementById("regPassword").value;

    if (regUsername.trim() === "") {
        document.getElementById("usernameError").innerText =
            "Username is required";
        return;
    } else {
        document.getElementById("usernameError").innerText = "";
    }

    if (regPassword.trim() === "") {
        document.getElementById("passwordError").innerText =
            "Password is required";
        return;
    } else {
        document.getElementById("passwordError").innerText = "";
    }

    if (localStorage.getItem(regUsername)) {
        document.getElementById("usernameError").innerText =
            "User already exists";
    } else {
        document.getElementById("usernameError").innerText = "";
    }

    if (regPassword.length < 5) {
        document.getElementById("passwordError").innerText =
            "Password must be above 5 characters";
        return;
    } else {
        document.getElementById("passwordError").innerText = "";
    }

    var passwordRegex = /^(?=.*[A-Z])(?=.*\d).{5,}$/;
    if (!passwordRegex.test(regPassword)) {
        document.getElementById("passwordError").innerText =
            "Password must be at least 5 characters long, contain at least one uppercase letter, and at least one digit.";
        return;
    } else {
        document.getElementById("passwordError").innerText = "";
    }

    // const apiUrl = "https://emojihubusers.wiremockapi.cloud/users";
    const apiUrl = "http://localhost:5001/Auth/register";
    await postData(apiUrl, {
        email: regUsername,
        name: regUsername,
        password: regPassword,
    })
        .then((res) => {
            return res.json();
        })
        .then((response) => {
            console.log("Response:", response);
        });
    window.location.href = "login.html";
}

async function postData(url = "", data = {}) {
    try {
        const response = await fetch(url, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },

            body: JSON.stringify(data),
        });

        return response;
    } catch (error) {
        console.error("Error during POST request:", error);
        throw error;
    }
}
