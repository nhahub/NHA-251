document.getElementById("signupForm").addEventListener("submit", (e) => {
    e.preventDefault();

    const password = document.getElementById("password").value;
    const confirmPassword = document.getElementById("confirmPassword").value;

    if (password !== confirmPassword) {
        alert("Passwords do not match!");
        return;
    }

    alert("Account created successfully!");
    window.location.href = "login.html";
});

window.addEventListener("DOMContentLoaded", () => {
    const nav = document.querySelector("nav");
    if (nav) {
        const themeButton = document.createElement("button");
        themeButton.className = "theme-toggle";
        themeButton.textContent = "🌙";
        nav.appendChild(themeButton);

        const savedTheme = localStorage.getItem("theme");
        if (savedTheme === "dark") {
            document.body.classList.add("dark-mode");
            themeButton.textContent = "☀️";
        }

        themeButton.addEventListener("click", () => {
            document.body.classList.toggle("dark-mode");
            const isDark = document.body.classList.contains("dark-mode");
            localStorage.setItem("theme", isDark ? "dark" : "light");
            themeButton.textContent = isDark ? "☀️" : "🌙";
        });
    }
});
