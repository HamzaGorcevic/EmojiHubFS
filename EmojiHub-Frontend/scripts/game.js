let gameEmojiContainer = document.querySelector(".gameEmojiContainer");

const emojiCategories = [
    "body",
    "cat-face",
    "clothing",
    "creature-face",
    "emotion",
    "face-negative",
    "face-neutral",
    "face-positive",
    "face-role",
    "face-sick",
    "family",
    "monkey-face",
    "person",
    "person-activity",
    "person-gesture",
    "person-role",
    "skin-tone",
];

const randomIndex = Math.floor(Math.random() * emojiCategories.length);
let counterEl = document.querySelector(".counter");

let counter = 0;

let group;
async function getRandomEmoji() {
    try {
        await fetch("https://emojihub.yurace.pro/api/random")
            .then((resolve) => resolve.json())
            .then((data) => {
                group = data.group;
                let randomEmoji = document.createElement("h1");
                randomEmoji.innerHTML = data.htmlCode[0];
                gameEmojiContainer.innerHTML = "";
                gameEmojiContainer.append(randomEmoji);
                let answers = new Set();
                while (answers.size != 3) {
                    answers.add(
                        emojiCategories[
                            Math.floor(Math.random() * emojiCategories.length)
                        ]
                    );
                }
                answers.add(data.group);
                answers = Array.from(answers);
                answers.sort(() => 0.5 - Math.random());

                answers.map((el) => {
                    let answer = document.querySelector(".answer");
                    answer.innerHTML = el;
                    let answerEl = document.querySelector(".answers");
                    answerEl.append(answer);
                });
            });
    } catch (error) {
        console.error("Error fetching random emoji:", error);

        throw error;
    }
}

getRandomEmoji();

// current score
let usersInfo = JSON.parse(
    localStorage.getItem(localStorage.getItem("loggedInUser"))
);
currentHighScore = usersInfo.score;
console.log("SAD", currentHighScore);

let highScore = document.querySelector(".highScore");
highScore.innerHTML = `${currentHighScore}`;

//current score
document.querySelectorAll(".answer").forEach((button) => {
    button.addEventListener("click", (e) => {
        if (e.target.innerHTML == group) {
            counter++;
        } else {
            alert("Correct answer was:" + group);
            if (counter > currentHighScore) {
                usersInfo.score = counter;
                localStorage.setItem(
                    usersInfo.username,
                    JSON.stringify(usersInfo)
                );
                highScore.innerHTML = counter;
            }

            counter = 0;
        }
        counterEl.innerHTML = counter;
        getRandomEmoji();
    });
});

// save highscore
