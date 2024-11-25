/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./Components/**/*.razor",
        "./Components/**/*.razor.js",
        "./wwwroot/js/**/*.js",
        "./wwwroot/**/*.js"
    ],
    theme: {
        extend: {
            spacing: {
                '1/5': '20%',
                '1/10': '10%',
            },
            colors: {
            }
        }
    },
    plugins: [],
}

