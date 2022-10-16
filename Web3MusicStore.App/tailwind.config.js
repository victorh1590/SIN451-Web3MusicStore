/** @type {import('tailwindcss').Config} */
module.exports = {
  daisyui: {
    styled: true,
    themes: true,
    base: true,
    utils: true,
    logs: true,
    rtl: false,
    prefix: "",
    darkTheme: "light",
  },
  content: ["./**/*.{razor,html,cshtml}", "./Pages/*.{razor,html,cshtml}"],
  theme: {
    extend: {},
  },
  plugins: [require("daisyui")],
}
