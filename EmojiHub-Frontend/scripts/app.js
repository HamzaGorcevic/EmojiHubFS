//

const currentUser = localStorage.getItem("loggedInUser");
function addToList(selectedList) {
    console.log("ASD", selectedList);
    console.log(JSON.parse(localStorage.getItem(currentUser)));
    let usersInfo = JSON.parse(localStorage.getItem(currentUser));
    console.log("userinfo", usersInfo?.mylist);
    usersInfo.mylist.push(selectedList);

    localStorage.setItem(currentUser, JSON.stringify(usersInfo));
}
//
// editor
let textArea = document.querySelector("textarea");

let editor = document.querySelector(".editor");
let editorToggle = document.querySelector("#editorToggle");
let copyBtn = document.querySelector("#copy");
let copy = document.querySelector("#copy");
let save = document.querySelector(".save");

editorToggle.addEventListener("click", () => {
    editor.classList.toggle("normalWidth");
    copy.classList.toggle("showH3andTextarea");
    save.classList.toggle("showH3andTextarea");
    textArea.classList.toggle("showH3andTextarea");
    editorToggle.classList.toggle("rotateArrow");
});
// editor end
save.addEventListener("click", () => {
    save.textContent = "Saved";

    addToList(textArea.value);
});

copyBtn.onclick = function () {
    copyBtn.innerHTML = "Copied";
    document.execCommand("copy");
};
copyBtn.addEventListener("copy", (event) => {
    event.preventDefault();

    if (event.clipboardData) {
        event.clipboardData.setData("text/plain", textArea.value);
    }
});
// Fetch data from the API

fetch("https://emojihub.yurace.pro/api/all")
    .then((response) => response.json())
    .then((data) => {
        displayEmojis(data);

        let searchBar = document.querySelector(".searchBar");

        searchBar.addEventListener("input", (el) => {
            filterEmojis(data, el.target.value.toLowerCase());
        });
    })
    .catch((error) => {
        console.error("Error fetching data:", error);
    });

function displayEmojis(emojis) {
    const emojisContainer = document.getElementById("emojis-container");

    emojisContainer.innerHTML = "";

    emojis.forEach((emoji) => {
        const emojiElement = document.createElement("span");
        emojiElement.classList.add("emojiElement");
        emojiElement.innerHTML = emoji.htmlCode[0];

        let emojiDiv = document.createElement("div");
        emojiDiv.classList.add("emojiDiv");
        emojiDiv.append(emojiElement);

        emojiDiv.onclick = function (e) {
            save.textContent = "Save";
            copyBtn.innerHTML = "Copy";

            console.log(e.target.classList);
            document.execCommand("copy");
        };

        emojiDiv.addEventListener("copy", (event) => {
            event.preventDefault();
            console.log(textArea);
            if (textArea.value.length >= 0) {
                editor.classList.add("normalWidth");
                save.classList.add("showH3andTextarea");
                copy.classList.add("showH3andTextarea");
                textArea.classList.add("showH3andTextarea");
                editorToggle.classList.add("rotateArrow");
            }
            if (event.clipboardData) {
                event.clipboardData.setData("text/plain", emojiDiv.textContent);
                textArea.value += event.clipboardData.getData("text/plain");
            }
        });
        emojisContainer.appendChild(emojiDiv);
    });
}

function filterEmojis(emojis, searchTerm) {
    const emojisContainer = document.getElementById("emojis-container");
    emojisContainer.innerHTML = ""; // Clear the previous emojis

    const filteredEmojis = emojis.filter((emoji) => {
        return emoji.name.toLowerCase().includes(searchTerm);
    });
    displayEmojis(filteredEmojis);
}

function categoryFetch(category) {
    let categories = document.querySelectorAll(".categ");
    for (let i = 0; i < categories.length; i++) {
        if (
            categories[i].textContent
                .trim()
                .split(" ")
                .join("-")
                .toLowerCase() == category
        ) {
            categories[i].children[0].classList.add("selectedCat");
        } else {
            categories[i].children[0].classList.remove("selectedCat");
        }
    }
    fetch(`https://emojihub.yurace.pro/api/all/category/${category}`)
        .then((response) => response.json())
        .then((data) => {
            displayEmojis(data);
        });
}
