// console.log('HOISTING');

let parentDiv = document.getElementById('parentDiv');
let childDiv = document.getElementById('childDiv');
let childChildDiv = document.getElementById('childChildDiv');

let p1 = document.getElementById('p1');




myOnclick = (e) => {
    // return
    // console.log(e);
    let target = e.target;
    let currentTarget = e.currentTarget

    if (target == currentTarget) {
        target.style.background = target.style.background == 'lightgreen' ? 'white' : 'lightgreen'
    } else {
        currentTarget.style.background = currentTarget.style.background == 'lightblue' ? 'white' : 'lightblue'

    };

    // currentTarget.style.background = currentTarget.style.background == 'grey' ? 'white' : 'grey'

    console.log(`target: ${target.id}, currentTarget: ${currentTarget.id}`);
    // e.stopPropagation()
}



for(let elem of document.querySelectorAll('*')) {
    elem.addEventListener("click", () => console.log(`Погружение: ${elem.tagName}`), true);
    elem.addEventListener("click", () => console.log(`Всплытие: ${elem.tagName}`));
  }


const myStopProp = function (e) {
    e.stopPropagation()
};



const catchEvent = (e) => {
    console.log('---catchEvent---', e.currentTarget);
    // e.stopPropagation()
}



parentDiv.onclick = myOnclick;
childDiv.onclick = myOnclick;
childChildDiv.onclick = myOnclick;

// p1.onclick = myStopProp;

childDiv.addEventListener('click', catchEvent, { capture: true })


