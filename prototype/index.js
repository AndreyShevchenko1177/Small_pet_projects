console.log('prototype');

let car = {
    name: 'Mustang',
    type: 'sedan',
}



alert(car);



Object.defineProperty(car, 'toString', {
    value: function(){
        let st = '{';
            for (key of Object.keys(this)) {
                st += key + ': ' + this[key] + ', '
            }
            st+='}'
            return st
    },
})



alert(car);
