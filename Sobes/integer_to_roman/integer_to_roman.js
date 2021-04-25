const intToRoman = function (num) {
    let romanLetters = new Map();

    romanLetters
        .set("M", 1000)
        .set("CM", 900)
        .set("D", 500)
        .set("CD", 400)
        .set("C", 100)
        .set("XC", 90)
        .set("L", 50)
        .set("XL", 40)
        .set("X", 10)
        .set("IX", 9)
        .set("V", 5)
        .set("IV", 4)
        .set("I", 1);

    let resultStr = "";

    for (let i of romanLetters.keys()) {
        let count = Math.floor(num / romanLetters.get(i));
        num = num - count * romanLetters.get(i);
        resultStr += i.repeat(count);
    }

    return resultStr;
};

console.log(intToRoman(3));
console.log(intToRoman(4));
console.log(intToRoman(9));
console.log(intToRoman(58));
console.log(intToRoman(1994));
