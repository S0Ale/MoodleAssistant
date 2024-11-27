import {query, queryChilds} from "./utils.js";
import {clearForm, createPreviewItem} from "./form.js";

document.addEventListener('DOMContentLoaded', function () {
    let form = query('#snd-form');
    if(!form) return;

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
            console.log(input.files)
            
            const names = [];
            for (const file of input.files) 
                names.push(file.name);
            previewContainer.appendChild(createPreviewItem(names, previewContainer, dropZone));
        });
        input.addEventListener('change', function() {
            dropZone.classList.add('hidden');

            const names = [];
            for (const file of input.files)
                names.push(file.name);
            previewContainer.appendChild(createPreviewItem(names, previewContainer, dropZone));
        });
    }

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