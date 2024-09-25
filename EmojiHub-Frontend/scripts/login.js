async function login() {
    var loginUsername = document.getElementById("loginUsername").value;
    var loginPassword = document.getElementById("loginPassword").value;

    if (loginPassword.trim() === "") {
        document.getElementById("passwordError").innerText =
            "Password is required";
    }
    if (loginUsername.trim() === "") {
        document.getElementById("usernameError").innerText =
            "Username is required";
        return;
    }
    apiUrl = "http://127.0.0.1:5001/Auth/login";

    const request = await fetch(apiUrl, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            email: loginUsername,
            password: loginPassword,
        }),
    });
    let response = await request.json();
    console.log(response);

    localStorage.setItem("token", response.value);

    let tokenArr = response.value.split(".");
    let tokenPayload = JSON.parse(atob(tokenArr[1]));
    localStorage.setItem("loggedInUser", tokenPayload.unique_name);
    window.location.href = "index.html";
    // specail users !
}
