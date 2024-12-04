export function initComponent(id) {
    let item = query(`#${id}`);
    const input = queryChilds(item, 'input');
    const dropZone = queryChilds(item, '.drop-zone');

    dropZone.addEventListener('dragover', function (e) {
        e.preventDefault();
    });
    dropZone.addEventListener('drop', function (e) {
        e.preventDefault();
        input.files = e.dataTransfer.files;
        input.dispatchEvent(new Event('change'));
    });
}