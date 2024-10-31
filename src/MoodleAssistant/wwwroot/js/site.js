// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Navbar
const btn = document.querySelector("button.mobile-menu-button");
const menu = document.querySelector(".mobile-menu");


btn.addEventListener("click", () => {
    menu.classList.toggle("hidden");
});