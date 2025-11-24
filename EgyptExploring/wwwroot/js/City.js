document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("citySearch");
    if (!searchInput) return;

    const cards = Array.from(document.querySelectorAll(".destination-card"));

    searchInput.addEventListener("input", function () {
        const query = searchInput.value.trim().toLowerCase();

        cards.forEach(card => {
            const titleElement = card.querySelector("h3");
            if (!titleElement) return;

            const cityName = titleElement.textContent.trim().toLowerCase();

            if (query === "" || cityName.includes(query)) {
                card.style.display = "";
            } else {
                card.style.display = "none";
            }
        });
    });
});
