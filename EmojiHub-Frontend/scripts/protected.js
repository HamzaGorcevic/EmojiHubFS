let loggedInUser = localStorage.getItem("loggedInUser");

console.log("will it log something", loggedInUser);
if (!loggedInUser) {
    window.location.href = "lostpage.html";
}
