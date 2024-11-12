import { query, queryChilds, loadPartialView } from "./utils.js";
import { createPreviewItem } from "./form.js";

document.addEventListener('DOMContentLoaded', function () {

    const items = query('.file-input-item', true);

    items.forEach((item) => {
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
            previewContainer.appendChild(createPreviewItem(input.files[0], previewContainer, dropZone));
        });

        input.addEventListener('change', function() {
            dropZone.classList.add('hidden');
            previewContainer.appendChild(createPreviewItem(input.files[0], previewContainer, dropZone));
        });

    });

    let btn = query('#error-container button');
    if (btn) btn.addEventListener('click', (e) => {
        e.preventDefault();
        let cont = query('#error-container');
        cont.classList.add('hidden');
    });

    query('#clear-files').addEventListener('click', (e) => {
        e.preventDefault();
        clearForm();
    });

    /*
    let form = query('#first-form');
    form.addEventListener('submit', (e) => {
        //if (isEmptyForm()) { // NON FUNGE
            //showError(query('#first-form'), 'No files selected. Please fill all fields.');
            //return false;
        //}
    });

    query('#upload-files').addEventListener('click', (e) => {
        e.preventDefault();
        if (isEmptyForm(data)) {
            showError(query('#first-form'), 'No files selected. Please fill all fields.');
            return false;
        }

        submit(data, async () => {
            //let view = await loadPartialView('/Main/Analysis');
            //view.forEach((element) => {
                //query('#content').append(element);
            //});
        });
        data = new FormData();
        clearForm();
    });
    */
});

