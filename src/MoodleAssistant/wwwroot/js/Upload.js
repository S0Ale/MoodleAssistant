import { query, queryChilds } from "./utils.js";

document.addEventListener('DOMContentLoaded', function () {

    const items = query('.file-input-item', true);
    let data = new FormData();

    // Add
    items.forEach((item) => {
        const input = queryChilds(item, 'input');
        const dropZone = queryChilds(item, '.drop-zone');
        const previewContainer = queryChilds(item, '.preview-container');

       // console.log(input.value);

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
            console.log(file);
        }
    });

    function createPreviewItem(fileSrc, container, dropZone) {
        const previewItem = document.createElement('div');
        previewItem.classList.add('file-item');

        const text = document.createElement('p');
        text.innerHTML = fileSrc.name;

        const removeButton = document.createElement('button');
        removeButton.innerHTML = 'X';
        removeButton.classList.add('absolute', 'top-1', 'right-1', 'text-gray-700', 'border-none', 'px-2', 'py-1', 'transition', 'hover:text-red-500');

        removeButton.addEventListener('click', function () {
            container.removeChild(previewItem);
            dropZone.classList.remove('hidden');
        });

        previewItem.appendChild(text);
        previewItem.appendChild(removeButton);

        return previewItem;
    }

    function clearForm() {
        items.forEach((item) => {
            const previewContainer = queryChilds(item, '.preview-container');
            const input = queryChilds(item, 'input');
            input.value = ''; // clear input

            if (previewContainer.firstChild) {
                // Clear preview item
                previewContainer.removeChild(previewContainer.firstChild);
                const dropZone = queryChilds(item, '.drop-zone');
                dropZone.classList.remove('hidden');
            }
        });
    }

    const clearBtn = query('#clear-files');
    clearBtn.addEventListener('click', (e) => {
        e.preventDefault();
        clearForm();
    });
});