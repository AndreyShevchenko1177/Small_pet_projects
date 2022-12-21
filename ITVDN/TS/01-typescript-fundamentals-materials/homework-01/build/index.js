console.log('IceCream');
;
class IceCream {
    constructor(coneSize, filling, marshmallow) {
        this.cost = 0;
        this.conf = {
            cone: 0,
            filling: 0,
            fillingMarshmallow: 0,
        };
        this.howMach = function () {
            return this.cost;
        };
        console.log(this.conf);
        const coneCost = {
            small: 10,
            big: 20,
        };
        const fillingCost = {
            chocolate: 5,
            caramel: 6,
            berries: 10,
            marshmallow: 5,
        };
        if (coneSize) {
            this.conf.cone = coneCost[coneSize];
        }
        else {
            const answerConeSize = prompt("Cone small/big ?", "small");
            this.conf.cone = coneCost[answerConeSize];
        }
        if (!filling) {
            filling = prompt("filling chocolate/caramel/berries ?", "chocolate");
        }
        this.conf.filling = fillingCost[filling];
        if (!marshmallow) {
            marshmallow = prompt("marshmallow yes/no?", "yes") == 'yes';
        }
        if (marshmallow) {
            this.conf.fillingMarshmallow = fillingCost.marshmallow;
        }
        this.cost = Object.keys(this.conf).reduce((accum, current) => accum + this.conf[current], 0);
    }
    ;
}
let myIceCream = new IceCream("small", "chocolate");
console.log(myIceCream.howMach());
let smbIceCream = new IceCream();
console.log(smbIceCream.howMach());
//# sourceMappingURL=index.js.map