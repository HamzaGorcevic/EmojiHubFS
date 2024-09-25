import { BASE_URL } from "../urls.js";
let selectEmoji = document.getElementById("select-emoji");

document
    .getElementById("blogForm")
    .addEventListener("submit", function (event) {
        event.preventDefault();
        const description = document.getElementById("description").value;
        const selectedEmojis = selectEmoji.value;
        PostBlog(description, selectedEmojis);
    });

let token = localStorage.getItem("token");

async function PostBlog(description, selectedEmojilist) {
    const request = await fetch(`${BASE_URL}/Blogs/createblog`, {
        method: "POST",
        headers: {
            Authorization: `Bearer ${token}`,
            "Content-Type": "application/json",
        },

        body: JSON.stringify({
            description: description,
            emojiList: { value: selectedEmojilist },
        }),
    });
    let res = await request.json();
    console.log(res);
}
async function GetLists() {
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
    response.value.forEach((element) => {
        let option = document.createElement("option");
        option.value = element.value;
        option.innerText = element.value;
        selectEmoji.appendChild(option);
    });
}
GetLists();
