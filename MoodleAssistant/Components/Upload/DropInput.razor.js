export function initComponent(id) {
    let item = query(id);
    let dropZones = queryChilds(item, '.drop-zone');
    if(!Array.isArray(dropZones)) dropZones = [dropZones];

    dropZones.forEach(dropZone => {
        const input = queryChilds(dropZone, 'input');
        
        dropZone.addEventListener('dragover', function (e) {
            e.preventDefault();
        });
        dropZone.addEventListener('drop', function (e) {
            e.preventDefault();
            input.files = e.dataTransfer.files;
            input.dispatchEvent(new Event('change'));
        });
    });
}