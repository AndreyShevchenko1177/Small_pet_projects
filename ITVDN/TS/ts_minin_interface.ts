

interface Rect {
    readonly id: string,
    color?: string
    size: {
        width: number
        height: number
    }
};

const rect1:Rect ={
    id: '123',
    size:{
        width: 10,
        height:5
    }
}

rect1.color = 'black';


const rect3 = {} as Rect;
const rect4 = <Rect>{};

// =====================================

interface RectWithArea extends Rect {
    getArea: ()=> number
}

const rect5: RectWithArea = {
    id: '789',
    size: {
        width: 5,
        height: 3,
    },
    getArea(): number {
        return this.size.width * this.size.height
    },
}

// =====================================


interface IClock {
    time: Date
    setTime (date: Date): void
}

class Clock implements IClock {
    time: Date = new Date()
    setTime(date: Date): void {
        this.time = date
    }
};

// =====================================

interface Styles {
    [key: string]: string
}

const css = {
    border: '2px solid red',
    marginTop: '2px',
    borderRadius: '5px'
}





