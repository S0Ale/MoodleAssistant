import {query, queryChilds} from "./utils.js";
import { initDropFileForm } from "./form.js";

document.addEventListener('DOMContentLoaded', function () {
    let form = query('#first-form');
    initDropFileForm(form);

    let btn = queryChilds(form, '#error-container button');
    if (btn) btn.addEventListener('click', (e) => {
        e.preventDefault();
        let cont = query('#error-container');
        cont.classList.add('hidden');
    });
});

