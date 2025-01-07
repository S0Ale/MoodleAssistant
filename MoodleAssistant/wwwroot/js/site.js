window.initMobileMenu = () => {
    let btn = document.querySelector("button.mobile-menu-button");
    let menu = document.querySelector(".mobile-menu");

    btn.addEventListener("click", () => {
        menu.classList.toggle("hidden");
    });
};