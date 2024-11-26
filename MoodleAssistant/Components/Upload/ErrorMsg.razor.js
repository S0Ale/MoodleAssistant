function closeDialog(formId){
    console.log("closeDialog");
    const form = query(`#${formId}`);
    if (!form) return;
    const cont = queryChilds(form, '.error-container');
    if (!cont) return;

    //cont.replaceChildren();
    for (const el of cont.children) {
        console.log(el);
        el.classList.add('hidden');
    }
}

export function initDialog(formId){
    console.log("initDialog");
    const form = query(`#${formId}`);
    if (!form) return;
    let close = queryChilds(form, '#close-error');
    if (!close) return;
    
    close.addEventListener('click', function() {
        closeDialog(formId);
    });
}

window.initDialog = initDialog;