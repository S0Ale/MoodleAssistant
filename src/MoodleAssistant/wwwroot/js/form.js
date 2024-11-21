import { query, queryChilds } from "./utils.js";

function clearForm(form) {
    const items = queryChilds(form, '.file-input-item', true);

    items.forEach((item) => {
        const previewContainer = queryChilds(item, '.preview-container');
        const input = queryChilds(item, 'input');
        input.value = ''; // clear input
        form.reset();

        // Clear preview item
        if (previewContainer.firstChild) {
            previewContainer.removeChild(previewContainer.firstChild);
            const dropZone = queryChilds(item, '.drop-zone');
            dropZone.classList.remove('hidden');
        }
    });
}

function createPreviewItem(fileSrc, container, dropZone) {
    const previewItem = document.createElement('div');
    previewItem.classList.add('file-item');

    const text = document.createElement('p');
    text.innerHTML = fileSrc.name;

    const removeButton = document.createElement('button');
    removeButton.classList.add('absolute', 'top-0', 'right-0', 'p-1');
    const icon = document.createElement('span');
    icon.classList.add('material-symbols-outlined', 'text-lg');
    icon.innerHTML = 'close';
    removeButton.appendChild(icon);

    removeButton.addEventListener('click', function () {
        container.removeChild(previewItem);
        dropZone.classList.remove('hidden');
        queryChilds(dropZone, 'input').value = ''; // clear input
    });

    previewItem.appendChild(text);
    previewItem.appendChild(removeButton);

    return previewItem;
}

function initDropFileForm(form){
    if(!form) return;
    
    // Prepare inputs and drop zones
    const items = queryChilds(form, '.file-input-item', true);
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

    // Close and clear buttons
    let clear = queryChilds(form, '#clear-files');
    clear.addEventListener('click', (e) => {
        e.preventDefault();
        clearForm(form);
    });
}

export { initDropFileForm };