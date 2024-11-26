function closeDialog(form){
    const cont = queryChilds(form, '.error-container');
    if (!cont) return;

    //cont.replaceChildren();
    for (const el of cont.children) {
        el.classList.add('hidden');
    }
}

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

function initReplicator(){
    const form = query("#main-upload");
    if (!form) return;
    let close = queryChilds(form, '#close-error');
    if (!close) return;
    let submit = queryChilds(form, 'button[type="submit"]');
    if (!submit) return;

    close.addEventListener('click', function() {
        closeDialog(form);
    });
}
initReplicator();