import { BASE_URL } from "../urls.js";

let name = document.getElementById("name");
let email = document.getElementById("email");
let message = document.getElementById("message");
let token = localStorage.getItem("token");
let btnSubmit = document.getElementsByClassName("btnSubmit")[0];

let check = true;

email.addEventListener("change", (e) => {
    console.log("sad");
    let regexEmail = /^[A-Za-z]+([._+-][A-Za-z]+)*\d*@[a-zA-Z]+\.[a-zA-Z]{2,}$/;

    let emailVal = "";
    if (!regexEmail.test(email.value)) {
        emailVal = "Uneli ste neispravan email.";
        check = false;
    } else {
        emailVal = "";
    }
    document.getElementById("emailError").innerHTML = emailVal;
});
btnSubmit.addEventListener("click", (e) => {
    e.preventDefault();
    console.log("submitted", check);

    if (check) {
        ContactMe(email.value, name.value, message.value).then((res) => {
            console.log(res);
        });
    }
});

async function ContactMe(email, name, message) {
    const request = await fetch(`${BASE_URL}/Email/sendemail`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            EmailFrom: email,
            Name: name,
            EmailBody: message,
        }),
    });
    const response = await request.json();
    return response;
}
