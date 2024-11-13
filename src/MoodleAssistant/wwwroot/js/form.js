import { query, queryChilds } from "./utils.js";

function clearForm() {
    const items = query('.file-input-item', true);

    items.forEach((item) => {
        const previewContainer = queryChilds(item, '.preview-container');
        const input = queryChilds(item, 'input');
        input.value = ''; // clear input
        query('#first-form').reset();

        // Clear preview item
        if (previewContainer.firstChild) {
            previewContainer.removeChild(previewContainer.firstChild);
            const dropZone = queryChilds(item, '.drop-zone');
            dropZone.classList.remove('hidden');
        }
    });
}

/*
function isEmptyForm(form) {
    let inputs = queryChilds(form, 'input', true);
    inputs.forEach((input) => {
        if (input.value == "") return true;
    });
    return false;
}
*/

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
        queryChilds(container, 'input').value = ''; // clear input
    });

    previewItem.appendChild(text);
    previewItem.appendChild(removeButton);

    return previewItem;
}

/*
async function submit(data, callback) {
    const response = await fetch('/Main/UploadFiles', {
        method: 'POST',
        body: data,
    });

    if (response.ok) {
        callback();
    } else showError(query('form'), await response.text());
}

function showError(form, msg) {
    let cont = queryChilds(form, '#error-container');
    let text = queryChilds(cont, 'p');
    text.classList.add('error-dialog');
    text.innerHTML = msg;
    cont.classList.remove('hidden');
}
*/

export { createPreviewItem, clearForm };