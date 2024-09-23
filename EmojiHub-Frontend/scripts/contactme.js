let name = document.getElementById("name");
let email = document.getElementById("email");
let message = document.getElementById("message");

let btnSubmit = document.getElementsByClassName("btnSubmit")[0];

console.log("btn", btnSubmit);
btnSubmit.addEventListener("click", (e) => {
    console.log("Name:", name.value);
    console.log("Email:", email.value);
    console.log("Message:", message.value);

    let regexName = /^[A-Z]+ [A-Z]+(-[A-Z]+)*$/;
    let regexEmail = /^[A-Za-z]+([+_-][A-Za-z]+)*\d*@[a-z]+(\.[a-z]+)*\.rs$/;
    let regexMessage = /^[A-Z][a-z, ]+(\s*[, ][A-Za-z]+)*[\.?!]$/;
    let nizRecenica = message.value.split(/(?<=[.?!])/);
    let check = false;
    let duzina = 0;
    for (let i of nizRecenica) {
        if (i != "") {
            duzina += i.length;
            i = i.trim();
            check = regexMessage.test(i);

            console.log(i, check);
        }
    }
    if (duzina > 250) {
        check = false;
        msgVal = "Tekst je predugacak.";
    }
    console.log(check);

    if (!regexName.test(name.value)) {
        nameVal = "Uneli ste neispravno ime i prezime.";
    } else {
        nameVal = "";
    }
    if (!check) {
        msgVal = "Poruka mora biti sintasticki ispravna.";
    } else {
        msgVal = "";
    }
    if (!regexEmail.test(email.value)) {
        emailVal = "Uneli ste neispravan email.";
    } else {
        emailVal = "";
    }
    document.getElementById("nameError").innerHTML = nameVal;
    document.getElementById("messageError").innerHTML = msgVal;
    document.getElementById("emailError").innerHTML = emailVal;

    e.preventDefault();
    console.log("submitted");
});
