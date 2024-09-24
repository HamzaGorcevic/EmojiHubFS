import { BASE_URL } from "../urls.js";

console.log("QWEWQ");
var token = localStorage.getItem("token");
let emojiListContainer = document.querySelector(".emoji-list");

async function GetAllBlogs() {
    try {
        const request = await fetch(`${BASE_URL}/Blogs/allblogs`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`,
            },
        });

        if (request.ok) {
            let response = await request.json();
            let blogs = response.value;

            emojiListContainer.innerHTML = "";

            blogs.forEach((blog) => {
                let blogItem = document.createElement("div");
                blogItem.classList.add(
                    "emoji-item",
                    "bg-light",
                    "p-4",
                    "mb-4",
                    "rounded",
                    "container"
                );

                let blogOwner = document.createElement("h2");
                blogOwner.textContent = blog.userName;
                blogItem.appendChild(blogOwner);

                let blogDescription = document.createElement("h2");
                blogDescription.textContent = blog.description;
                blogItem.appendChild(blogDescription);

                let blogEmojiList = document.createElement("p");
                blogEmojiList.classList.add("text-secondary");
                blogEmojiList.textContent = blog.emojiList.value;
                blogItem.appendChild(blogEmojiList);

                emojiListContainer.appendChild(blogItem);
            });
        } else {
            console.error("Failed to fetch blogs:", request.status);
        }
    } catch (error) {
        console.error("Error fetching blogs:", error);
    }
}

GetAllBlogs();
