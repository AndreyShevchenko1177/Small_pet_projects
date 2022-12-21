
const str:  string = 'Stroka'

const isFetching: boolean = true;

const int:number = 42;
const float:number = 4.2;
const num:number = 3e10;

const arr:number[] = [1, 1, 2, 3, 5, 8, 13];
const arr2: Array<number>  = [1, 1, 2, 3, 5, 8, 13]; //generic

const words: string[] = ['Hello', 'word'];

// Tuple
const contact:[string, number] = ['Vlad', 12345678];

// Any
let variable: any = 42;
variable = 'New string';

// =======

function sayMyName(name: string): void{
    console.log(name);
}

// Never
function throwError(message: string): never {
    throw new Error(message)
}

function infifnit(): never {
    while(true) {

    }
}

// Type
type Login = string;

const login: Login = 'admin';

type ID = string | number;
const id1:ID = 23;
const id2:ID = '123';

type SomeType = string | null | undefined;