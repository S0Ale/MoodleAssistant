window.clearForm = (formId) => {
    const form = query(`#${formId}`);
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