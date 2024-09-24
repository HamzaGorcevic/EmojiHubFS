import { BASE_URL } from "../urls.js";
const user = localStorage.getItem("loggedInUser");
let userEl = document.querySelector("h2");
userEl.innerHTML = `${user}'s emoji list`;

let token = localStorage.getItem("token");

async function GetLists() {
    console.log("DASDA");
    const request = await fetch(
        `${BASE_URL}/EmojiList/alluseremojilists`,

        {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`,
            },
        }
    );

    let response = await request.json();
    console.log(response.value);
    let emojiList = response.value;
    const emojiListContainer = document.getElementById("emoji-list");

    emojiList.forEach((emojiGroup) => {
        const listItem = document.createElement("li");
        listItem.classList.add("emoji-list-item");
        listItem.innerHTML = `${emojiGroup.value} <i class="fa-regular fa-clipboard"></i>`;
        emojiListContainer.appendChild(listItem);
    });
}

GetLists();
