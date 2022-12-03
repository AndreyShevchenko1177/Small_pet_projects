function partial(func, ...argsBound) {
    console.log('from part 1: ', this);
    return function(...args) { // (*)
        console.log('from part 2: ', this);
      return func.call(this, ...argsBound, ...args);
    }
  }
  
  // использование:
  let user = {
    firstName: "John",
    say(time, phrase) {
        console.log('from say 1: ', this);
      alert(`[${time}] ${this.firstName}: ${phrase}!`);
    }
  };
  
  // добавляем частично применённый метод с фиксированным временем
  user.sayNow = partial(user.say, new Date().getHours() + ':' + new Date().getMinutes());
  
  user.sayNow("Hello");
  // Что-то вроде этого:
  // [10:00] John: Hello!