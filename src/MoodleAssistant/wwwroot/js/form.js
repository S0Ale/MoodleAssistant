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

function createPreviewItem(fileNames, container, dropZone) {
    const previewItem = document.createElement('div');
    previewItem.classList.add('file-item');
    
    if(!Array.isArray(fileNames)) fileNames = [fileNames];
    for (const name of fileNames) {
        let text = document.createElement('p');
        text.innerHTML = name;
        previewItem.appendChild(text);
    }

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
    
    previewItem.appendChild(removeButton);

    return previewItem;
}

export { createPreviewItem, clearForm };