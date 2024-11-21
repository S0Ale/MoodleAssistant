import {query, queryChilds} from "./utils.js";
import { createPreviewItem, clearForm } from "./form.js";

document.addEventListener('DOMContentLoaded', function () {
    let form = query('#first-form');
    if(!form) return;

    // Prepare inputs and drop zones
    const items = queryChilds(form, '.file-input-item', true);
    for (const item of items) {
        const input = queryChilds(item, 'input');
        const dropZone = queryChilds(item, '.drop-zone');
        const previewContainer = queryChilds(item, '.preview-container');

        dropZone.addEventListener('dragover', function (e) {
            e.preventDefault();
        });
        dropZone.addEventListener('drop', function (e) {
            e.preventDefault();
            input.files = e.dataTransfer.files;
            dropZone.classList.add('hidden');
            previewContainer.appendChild(createPreviewItem(input.files[0].name, previewContainer, dropZone));
        });
        input.addEventListener('change', function() {
            dropZone.classList.add('hidden');
            previewContainer.appendChild(createPreviewItem(input.files[0].name, previewContainer, dropZone));
        });
    }

    // Close and clear buttons
    let clear = queryChilds(form, '#clear-files');
    clear.addEventListener('click', (e) => {
        e.preventDefault();
        clearForm(form);
    });

    let btn = queryChilds(form, '#error-container button');
    if(btn) btn.addEventListener('click', (e) => {
        e.preventDefault();
        let cont = queryChilds(form, '#error-container');
        cont.classList.add('hidden');
    });
});

