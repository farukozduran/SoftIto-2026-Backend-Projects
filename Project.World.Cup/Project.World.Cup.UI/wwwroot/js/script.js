const searchInput = document.getElementById("teamSearch");
const teamCards = document.querySelectorAll(".team-card");

searchInput?.addEventListener("input", function () {
    const searchValue = this.value.toLowerCase().trim();

    teamCards.forEach(card => {
        const teamName = card.getAttribute("data-team-name") || "";
        const teamCode = card.getAttribute("data-team-code") || "";

        const isVisible =
            teamName.includes(searchValue) ||
            teamCode.includes(searchValue);

        card.style.display = isVisible ? "block" : "none";

    });
});

document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.querySelector(".entity-search");
    const cards = document.querySelectorAll(".entity-card");

    if (!searchInput || cards.length === 0) {
        return;
    }

    searchInput.addEventListener("input", function () {
        const searchValue = this.value.toLowerCase().trim();

        cards.forEach(card => {
            const searchText = card.getAttribute("data-search") || "";
            card.style.display = searchText.includes(searchValue) ? "block" : "none";
        });
    });
});