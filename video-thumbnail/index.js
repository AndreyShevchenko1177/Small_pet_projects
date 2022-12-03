// On selecting a video file
document.querySelector("#file-input").addEventListener('change', function () {
    console.log(document.querySelector("#file-input").files[0]);
    // Set object URL as the video <source>
    document.querySelector("#video-element").setAttribute('src', URL.createObjectURL(document.querySelector("#file-input").files[0]));
    // document.querySelector("#video-element").setAttribute('src', 'https://drive.google.com/uc?export=view&id=1Jr_6LCFkbyOzWwoNq0dY5ray70NDZKMc');
});

//https://drive.google.com/file/d/1Jr_6LCFkbyOzWwoNq0dY5ray70NDZKMc/view?usp=share_link

var _VIDEO = document.querySelector("#video-element");
var _CANVAS = document.querySelector("#canvas-element");
var _CANVAS_CTX = _CANVAS.getContext("2d");

_CANVAS.setAttribute('crossOrigin', 'anonymous');
// _VIDEO.setAttribute('crossorigin', 'anonymous');


// Video metadata is loaded
_VIDEO.addEventListener('loadedmetadata', function () {
    console.log('loadedmetadata', _VIDEO.videoWidth);
    // Set canvas dimensions same as video dimensions
    _CANVAS.width = 250;
    _CANVAS.height = Math.floor(250 / _VIDEO.videoWidth * _VIDEO.videoHeight);
    // _VIDEO.currentTime = 0.1;
    _VIDEO.currentTime = Math.floor(_VIDEO.duration/2);
    // _VIDEO.setAttribute('width', 600);
    _VIDEO.setAttribute('height', (600 / _VIDEO.videoWidth * _VIDEO.videoHeight))
});

// Video playback position is changed
_VIDEO.addEventListener('timeupdate', function () {
    // You are now ready to grab the thumbnail from the <canvas> element
    console.log('timeupdate');

    // Placing the current frame image of the video in the canvas
    _CANVAS_CTX.drawImage(_VIDEO, 0, 0, 250, Math.floor(250 / _VIDEO.videoWidth * _VIDEO.videoHeight));
    // _VIDEO.remove();

    // Setting parameters of the download link
    document.querySelector("#hiddenImg").setAttribute('crossorigin', 'anonymous');
    document.querySelector("#hiddenImg").setAttribute('src', _CANVAS.toDataURL());
    // document.querySelector("#download-link").setAttribute('href', _CANVAS.toDataURL());
    // document.querySelector("#download-link").setAttribute('download', 'thumbnail.png');
});


_VIDEO.setAttribute('src', 'https://drive.google.com/uc?export=view&id=1Jr_6LCFkbyOzWwoNq0dY5ray70NDZKMc');





document.querySelector("#set-video-seconds").addEventListener('change', function () {
    console.log(document.getElementById('set-video-seconds').value);
    _VIDEO.currentTime = document.getElementById('set-video-seconds').value
})