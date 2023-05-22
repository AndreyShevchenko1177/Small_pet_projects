const MIDDLE_BOTTOM_SRC = './img/middleBottom_Photo.png';
// const MIDDLE_TOP_SRC = './img/middleTop.png';
const MIDDLE_TOP_SRC = '';
const LEFT_SRC = './img/leftImg_Photo.png';
const RIGHT_SRC = './img/rightImg_Photo.png';
const PARENT_DRAWING_EL = document.getElementById('parentDrawing');
const PARENT_CONTROL_EL = document.getElementById('parentControl');
const PARENT_PRICE_EL = document.getElementById('parentPrice');
const DEFAULT_STEP = 5; //centimeter
const MIN_WIDTH = 70; //centimeter
const MAX_WIDTH = 120; //centimeter
const MIN_LENGTH = 120; //centimeter
const MAX_LENGTH = 220; //centimeter
const MIN_PRICE = 100; //$ cost
const MAX_PRICE = 500; //$ cost

function Control(
    {
        parentDrawEl,
        parentControlEl,
        middleBottomSrc,
        middleTopSrc,
        leftSrc,
        rightSrc,
        step,
        minWidth,
        maxWidth,
        minLength,
        maxLength,
        minPrice,
        maxPrice
    }) {

    this.length = Math.round((maxLength + minLength) / 2);
    this.width = Math.round((maxWidth + minWidth) / 2);
    this.getValue = () => ({length: this.length, width: this.width});
    this.price = minPrice;


    // Here is logic of making price
    const changePrice = () => {
        const {length, width} = this.getValue();
        const minSquare = minLength * minWidth;
        const maxSquare = maxLength * maxWidth;
        const currentSquare = length * width;
        const ratio = (currentSquare - minSquare) / (maxSquare - minSquare);
        const newPrice = (Math.round((minPrice + ratio * (maxPrice - minPrice)) * 100) / 100).toFixed(2);
        this.price = newPrice;
        this.onchange();
    };

    this.onchange = () => {}

    function MeasureControl(
        {
            parentEl,
            type,
            value = 0,
            min = 0,
            max = 100,
            step = 5
        }
    ) {
        const label = document.createElement('div');
        label.append(`${type} ${value}`);
        parentEl.append(label);

        const control = document.createElement('input');
        control.type = 'range';
        control.step = step;
        control.min = min;
        control.max = max;
        control.classList.add('slider');
        control.value = value;
        parentEl.append(control);

        const leftEdge = document.createElement('div');
        leftEdge.append(min);
        const rightEdge = document.createElement('div');
        rightEdge.append(max);
        const legend = document.createElement('div');
        legend.append(leftEdge, rightEdge);
        legend.classList.add('legend');
        parentEl.append(legend);


        control.oninput = (e) => {
            value = parseInt(e.target.value, 10);
            label.innerHTML = (`${type} ${value}`);
            this.onChange();
        };

        this.onChange = () => {
        };

        this.getValue = () => value;
    }


    const appendImg = (el, src) => {
        const img = document.createElement('img');
        img.setAttribute('src', src);
        el.append(img);
        return img;
    };


    const wrapperDrawing = document.createElement('div');
    wrapperDrawing.classList.add('drawingWrapper');
    appendImg(wrapperDrawing, middleBottomSrc);
    const topImg = appendImg(wrapperDrawing, middleTopSrc);
    appendImg(wrapperDrawing, leftSrc);
    appendImg(wrapperDrawing, rightSrc);
    const topCover = document.createElement('div');
    topCover.classList.add('topCover');
    wrapperDrawing.append(topCover);
    parentDrawEl.append(wrapperDrawing);


    const wrapperControl = document.createElement('div');
    wrapperControl.classList.add('controlWrapper');

    const widthControl = new MeasureControl({
        parentEl: wrapperControl,
        value: this.width,
        min: minWidth,
        max: maxWidth,
        step: step,
        type: "Width"
    });
    widthControl.onChange = () => {
        let newTopCoverHeght = Math.round(75 - (widthControl.getValue() - minWidth) / (maxWidth - minWidth) * 35);
        newTopCoverHeght += 'px';
        topCover.style.height = newTopCoverHeght;
        topImg.style.top = newTopCoverHeght;
        this.width = widthControl.getValue();
        changePrice();
    };
    widthControl.onChange();


    const lengthControl = new MeasureControl({
        parentEl: wrapperControl,
        value: this.length,
        min: minLength,
        max: maxLength,
        step: step,
        type: "Length"
    });
    lengthControl.onChange = (callback) => {
        let newWidthPercent = 50 + (lengthControl.getValue() - minLength) / (maxLength - minLength) * 40;
        newWidthPercent += '%';
        wrapperDrawing.style.width = newWidthPercent;
        this.length = lengthControl.getValue();
        changePrice();
    };
    lengthControl.onChange();

    parentControlEl.prepend(wrapperControl);
}


const flexibleDrawing = new Control({
    parentDrawEl: PARENT_DRAWING_EL,
    parentControlEl: PARENT_CONTROL_EL,
    middleBottomSrc: MIDDLE_BOTTOM_SRC,
    middleTopSrc: MIDDLE_TOP_SRC,
    leftSrc: LEFT_SRC,
    rightSrc: RIGHT_SRC,
    step: DEFAULT_STEP,
    minWidth: MIN_WIDTH,
    maxWidth: MAX_WIDTH,
    minLength: MIN_LENGTH,
    maxLength: MAX_LENGTH,
    minPrice: MIN_PRICE,
    maxPrice: MAX_PRICE
});

flexibleDrawing.onchange = () => {
    PARENT_PRICE_EL.innerHTML = flexibleDrawing.price
}

flexibleDrawing.onchange()






