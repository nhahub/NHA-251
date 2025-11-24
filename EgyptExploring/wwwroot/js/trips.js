(function () {
    document.addEventListener("DOMContentLoaded", () => {

        const searchInput = document.getElementById("tripSearch");
        const minPriceInput = document.getElementById("minPrice");
        const maxPriceInput = document.getElementById("maxPrice");
        const rows = document.querySelectorAll(".trips-table tbody tr");

        function applyFilters() {
            const searchValue = (searchInput?.value || "").toLowerCase().trim();

            const minPriceVal = minPriceInput?.value;
            const maxPriceVal = maxPriceInput?.value;

            const minPrice = minPriceVal ? parseFloat(minPriceVal) : null;
            const maxPrice = maxPriceVal ? parseFloat(maxPriceVal) : null;

            rows.forEach(row => {
                const name = (row.dataset.name || "").toLowerCase().trim();
                const rowPrice = parseFloat(row.dataset.price || "0");

                const matchesSearch = !searchValue || name.includes(searchValue);

                let matchesPrice = true;
                if (minPrice !== null && !isNaN(minPrice)) {
                    matchesPrice = matchesPrice && rowPrice >= minPrice;
                }
                if (maxPrice !== null && !isNaN(maxPrice)) {
                    matchesPrice = matchesPrice && rowPrice <= maxPrice;
                }

                if (matchesSearch && matchesPrice) {
                    row.style.display = "";
                } else {
                    row.style.display = "none";
                }
            });
        }

        if (searchInput) searchInput.addEventListener("input", applyFilters);
        if (minPriceInput) minPriceInput.addEventListener("input", applyFilters);
        if (maxPriceInput) maxPriceInput.addEventListener("input", applyFilters);

        const modal = document.getElementById("tripModal");
        if (!modal) return;

        const modalContent = modal.querySelector(".trip-modal-content");
        const titleEl = document.getElementById("tripModalTitle");
        const cityEl = document.getElementById("tripModalCity");
        const descEl = document.getElementById("tripModalDesc");
        const priceEl = document.getElementById("tripModalPrice");
        const closeX = modal.querySelector(".trip-modal-close");
        const backBtn = document.getElementById("tripModalBack");
        const bookLink = document.getElementById("tripModalBook");

        let lastFocused = null;

        function openModal({ title, city, desc, price, bookUrl }) {
            lastFocused = document.activeElement;

            if (titleEl) titleEl.textContent = title || "";
            if (cityEl) cityEl.textContent = city || "";
            if (descEl) descEl.textContent = desc || "";
            if (priceEl) priceEl.textContent = price || "";
            if (bookLink && bookUrl) bookLink.href = bookUrl;

            modal.removeAttribute("hidden");
            modal.classList.add("active");
            setTimeout(() => modalContent && modalContent.focus(), 0);
        }

        function closeModal() {
            modal.classList.remove("active");
            modal.setAttribute("hidden", "");
            if (lastFocused) lastFocused.focus();
        }

        document.querySelectorAll(".view-trip-details").forEach(btn => {
            btn.addEventListener("click", (e) => {
                e.preventDefault();

                openModal({
                    title: btn.dataset.title,
                    city: btn.dataset.city,
                    desc: btn.dataset.desc,
                    price: btn.dataset.price,
                    bookUrl: btn.dataset.bookUrl
                });
            });
        });

        [closeX, backBtn].forEach(el => el && el.addEventListener("click", closeModal));

        modal.addEventListener("click", (e) => {
            if (e.target === modal) closeModal();
        });

        document.addEventListener("keydown", (e) => {
            if (e.key === "Escape") closeModal();
        });
    });
})();
