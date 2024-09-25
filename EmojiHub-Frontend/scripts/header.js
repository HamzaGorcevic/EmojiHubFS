let loginUser = document.querySelector(".loginUser");
let registerUser = document.querySelector(".registerUser");
let menuH = document.querySelector(".menu");
let loggedInUser = localStorage.getItem("loggedInUser");
let linkToLostPage = document.querySelectorAll(".linkToLostPage");

menuH.childNodes.forEach((element) => {
    if (element.nodeType == Node.ELEMENT_NODE) {
        element.addEventListener("click", () => {
            menuH.childNodes.forEach((el) => {
                if (el.nodeType === Node.ELEMENT_NODE) {
                    el.classList.remove("active");
                }
            });
            console.log("Class adedd");
            element.classList.add("active");
        });
    }
    console.log(element.innerText);
});

if (loggedInUser) {
    var logout = document.createElement("li");
    let logoutA = document.createElement("a");
    logoutA.innerHTML = "Log out";
    logout.appendChild(logoutA);
    loginUser.style.display = "none";
    registerUser.style.display = "none";
    menuH.append(logout);
    logout.addEventListener("click", () => {
        window.location.href = "login.html";
        localStorage.removeItem("loggedInUser");
        localStorage.removeItem("token");
        localStorage.removeItem("user");
        localStorage.removeItem("token");
    });
} else {
    for (i of linkToLostPage) {
        i.href = "lostpage.html";
    }
}
