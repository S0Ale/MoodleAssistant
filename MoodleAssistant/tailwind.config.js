/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ["./Components/**/*.razor"],
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

