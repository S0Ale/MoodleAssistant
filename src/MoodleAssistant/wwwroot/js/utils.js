
function queryChilds(parent = document, selector, asArray = false) {
    let list = parent.querySelectorAll(selector);

    if (asArray || list.length > 1) return Array.from(list);
    if (list.length == 0) return null;
    return list[0];
}

function query(selector, asArray = false) {
    return queryChilds(document, selector, asArray);
}

function range(size, startAt = 0) {
    return [...Array(size).keys()].map(i => i + startAt);
}

function elementChildren(element) {
    var childNodes = element.childNodes,
        children = [],
        i = childNodes.length;

    while (i--) {
        if (childNodes[i].nodeType == 1) {
            children.unshift(childNodes[i]);
        }
    }
    return children;
}

export { queryChilds, query, range, elementChildren };