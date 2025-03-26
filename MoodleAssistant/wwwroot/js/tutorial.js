let index1 = 0;
let index2 = 0;
document.querySelector('#tutorial-format').addEventListener('change', (event) => {
    //reset all sections
    document.querySelectorAll('.format-section').forEach(section => {
        section.classList.add('hidden');
    });
    document.querySelectorAll('.format-csv-section').forEach(section => {
        section.classList.add('hidden');
    });

    //parse value to int
    index1 = parseInt(event.target.value);
    index2 = parseInt(event.target.value);
    
    document.querySelector(`.format-${index1}`).classList.remove('hidden');
    document.querySelector(`.csv-${index2}`).classList.remove('hidden');
});