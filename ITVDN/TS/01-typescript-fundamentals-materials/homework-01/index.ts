console.log('IceCream');



interface ConeInterface {
    cone: number,
    filling: number;
    fillingMarshmallow: number;
    [key: string]: number,
};

 interface coneCostInterface {
            small: number,
            big: number,
            [key: string]: number,
        }

        type coneCostKeys = keyof coneCostInterface;

class IceCream {

    cost: number = 0;
    // conf: ConeInterface = {
    //     cone: 0,
    //     filling: 0,
    //     fillingMarshmallow: 0,
    // };
    conf = {} as ConeInterface;

    constructor(coneSize?: coneCostKeys, filling?: string, marshmallow?: boolean) {

        console.log(this.conf);
        

       

        const coneCost = {
            small: 10,
            big: 20,
        } as coneCostInterface;


        interface fillingCostInterface {
            chocolate: number,
            caramel: number,
            berries: number,
            marshmallow: number,
            [key: string]: number,
        }


        const fillingCost: fillingCostInterface = {
            chocolate: 5,
            caramel: 6,
            berries: 10,
            marshmallow: 5,
        };

        if (coneSize) {
            this.conf.cone = coneCost[coneSize]
        } else {
            const answerConeSize: string = prompt("Cone small/big ?", "small");
            this.conf.cone = coneCost[answerConeSize]
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

        this.cost = Object.keys(this.conf).reduce((accum, current)=>accum+this.conf[current], 0)
    };

    howMach = function ():number{
        return this.cost
    }
}


let myIceCream = new IceCream("small", "chocolate");
console.log(myIceCream.howMach());

let smbIceCream = new IceCream();
console.log(smbIceCream.howMach());

