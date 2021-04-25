//

const windowOnload = function () {
    let firstString = document.getElementById("firstString");
    let secondString = document.getElementById("secondString");
    let buttonStart = document.getElementById("buttonStart");

    const isSquare = (number) => number > 0 && Math.sqrt(number) % 1 === 0;

    const findNext = function (str1, str2, pos) {
        if () { }

        return false
    }

    const mainProgram = function (str1, str2) {
        if (!isSquare(str1.length)) {
            console.log("It is wrong string length");
            return "It is wrong string length";
        }

        let i = 0;

        let dimension = Math.sqrt(str1.length);
        let matrix = Array.from(Array(dimension), () => Array.from(Array(dimension), () => str1[i++]));
        console.log(matrix);

        // since we can always expand the matrix into a one-dimensional array, 
        // we can continue to work with the string

        let position = str1.indexOf(str2[0]);

        while (position > -1) {
            console.log(position);
            position = str1.indexOf(str2[0], position + 1);
        }
    };

    buttonStart.onclick = () => {
        mainProgram(firstString.value, secondString.value);
    };
};

window.onload = windowOnload;
