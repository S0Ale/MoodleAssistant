/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./Components/**/*.razor",
        "./Components/**/*.razor.js",
        "./wwwroot/js/**/*.js",
        "./wwwroot/**/*.js",
        "./wwwroot/**/*.html",
    ],
    theme: {
        extend: {
            spacing: {
                '100': '28rem',
                '1/5': '20%',
                '1/10': '10%',
            },
            colors: {
            }
        }
    },
    plugins: [],
}

