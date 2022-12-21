console.log('Zoom-image');

function zoom(e) {
    // console.log(e.touches);
    // if (!e.offsetX || !e.offsetY) {console.log(e);}
    const zoomer = e.currentTarget;
    // e.offsetX ? offsetX = e.offsetX : offsetX = e.touches[0].pageX
    // e.offsetY ? offsetY = e.offsetY : offsetX = e.touches[0].pageX
    // console.log(e.offsetX, e.offsetY);
    // const offsetX = e.offsetX
    // const offsetY = e.offsetY
    x = e.offsetX / zoomer.offsetWidth * 100
    y = e.offsetY / zoomer.offsetHeight * 100
    zoomer.style.backgroundPosition = x + '% ' + y + '%';
}


function scrollZoomMaker(element) {

    function scrollZoom(e) {
        e = e || window.event;
        e.preventDefault ? e.preventDefault() : (e.returnValue = false);
        const delta = e.deltaY || e.detail || e.wheelDelta;
        // if (!element.style.backgroundSize) {
        //     element.style.backgroundSize = '200%'
        // }
        let currentZoom = +element.style.backgroundSize.slice(0,-1);
        if (!currentZoom) {
            currentZoom = 200;
        }
        let newZoom = currentZoom*(1 - Math.sign(delta)/2);
        if (newZoom < 110){
            newZoom = 110
        }
        if (newZoom > 2000){
            newZoom = 2000
        }
        element.style.backgroundSize = newZoom + '%';
        
        console.log('scroll', delta, element.style.backgroundSize);
    }

    if (element.addEventListener) {
        if ('onwheel' in document) {
            // IE9+, FF17+, Ch31+
            element.addEventListener("wheel", scrollZoom);
        } else if ('onmousewheel' in document) {
            // устаревший вариант события
            element.addEventListener("mousewheel", scrollZoom);
        } else {
            // Firefox < 17
            element.addEventListener("MozMousePixelScroll", scrollZoom);
        }
    } else { // IE8-
        element.attachEvent("onmousewheel", scrollZoom);
    }
    
    
    
}

const imgContainer = document.getElementById('imgContainer');

imgContainer.addEventListener('mousemove', zoom)
//   imgContainer.addEventListener('wheel', scrollZoom)
scrollZoomMaker(imgContainer)

