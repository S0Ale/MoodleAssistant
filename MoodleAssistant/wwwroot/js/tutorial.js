let index = 0;
const select = document.querySelector('#tutorial-format');
console.log(select);
select.addEventListener('change', (event) => {
    //reset all sections
    let sections = document.querySelectorAll('.format-section');
    sections.forEach(section => {
        section.classList.add('hidden');
    });

    //parse vlue to int
    index = parseInt(event.target.value);
    
    let toDisplay = document.querySelector(`.format-${index}`);
    toDisplay.classList.remove('hidden');
    console.log(toDisplay);
});