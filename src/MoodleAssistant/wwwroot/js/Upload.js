import { query, queryChilds } from "./utils.js";
import { submit, clearForm, isEmptyForm, createPreviewItem, showError } from "./form.js";

document.addEventListener('DOMContentLoaded', function () {

    const items = query('.file-input-item', true);
    let data = new FormData();

    items.forEach((item) => {
        const input = queryChilds(item, 'input');
        const dropZone = queryChilds(item, '.drop-zone');
        const previewContainer = queryChilds(item, '.preview-container');

        dropZone.addEventListener('dragover', function (e) {
            e.preventDefault();
        });
        dropZone.addEventListener('drop', function (e) {
            e.preventDefault();

            let file;
            if (e.dataTransfer.items) {
                file = e.dataTransfer.items[0].getAsFile();
            } else {
                file = e.dataTransfer.file[0];
            }
            handleFiles(file);
            dropZone.classList.add('hidden');
            previewContainer.appendChild(createPreviewItem(file, previewContainer, dropZone));
        });

        input.addEventListener('change', function() {
            const file = input.files[0];
            handleFiles(file);
            dropZone.classList.add('hidden');
            previewContainer.appendChild(createPreviewItem(file, previewContainer, dropZone));
        });

        function handleFiles(file) {
            data.append(input.name, file);
        }
    });

    query('#error-container button').addEventListener('click', (e) => {
        e.preventDefault();
        let cont = query('#error-container');
        cont.classList.add('hidden');
    });

    query('#clear-files').addEventListener('click', (e) => {
        e.preventDefault();
        data = new FormData();
        clearForm();
    });

    query('#upload-files').addEventListener('click', (e) => {
        e.preventDefault();
        if (isEmptyForm(data)) {
            showError(query('#first-form'), 'No files selected. Please fill all fields.');
            return false;
        }

        submit(data);
        data = new FormData();
        clearForm();
    });
});