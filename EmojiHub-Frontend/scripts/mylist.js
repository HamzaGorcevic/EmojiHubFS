const user = localStorage.getItem("loggedInUser");
let userEl = document.querySelector("h2");
userEl.innerHTML = `${user}'s emoji list`;

let emojiList = JSON.parse(localStorage.getItem(user)).mylist;

const emojiListContainer = document.getElementById("emoji-list");
emojiList.forEach((emojiGroup) => {
    const listItem = document.createElement("li");
    listItem.classList.add("emoji-list-item");
    listItem.innerHTML = `${emojiGroup} <i class="fa-regular fa-clipboard"></i>`;
    emojiListContainer.appendChild(listItem);
});
