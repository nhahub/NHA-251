document.addEventListener("DOMContentLoaded", function () {
    const modal = document.getElementById("destinationModal");
    const modalImg = document.getElementById("modalImage");
    const modalTitle = document.getElementById("modalTitle");
    const modalDesc = document.getElementById("modalDesc");
    const closeBtns = document.querySelectorAll(".close-modal, .close-btn");

    document.querySelectorAll(".view-details").forEach(btn => {
        btn.addEventListener("click", function (e) {
            e.preventDefault(); 
            const title = this.dataset.title;
            const desc = this.dataset.desc;
            const img = this.dataset.img;

            modalTitle.textContent = title;
            modalDesc.textContent = desc;
            modalImg.src = img;

            modal.classList.add("active");
            modal.removeAttribute("hidden");
        });
    });

    closeBtns.forEach(btn => {
        btn.addEventListener("click", function () {
            modal.classList.remove("active");
            modal.setAttribute("hidden", "hidden");
        });
    });

    modal.addEventListener("click", function (e) {
        if (e.target === modal) {
            modal.classList.remove("active");
            modal.setAttribute("hidden", "hidden");
        }
    });
});
