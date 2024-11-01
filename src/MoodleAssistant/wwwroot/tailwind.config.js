/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "../Views/**/*.cshtml",
        "./js/**/*.js"
    ],
    theme: {
        extend: {
            spacing: {
                '1/5': '20%',
                '1/10': '10%',
            },
            colors: {
                'btn_primary': '#0366d6'
            }
        }
    },
    plugins: [],
}

