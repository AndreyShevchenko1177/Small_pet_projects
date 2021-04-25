//

// brute force

let twoSum = function (nums, target) {
    for (let i = 0; i < nums.length - 1; i++) {
        for (let k = i + 1; k < nums.length; k++) {
            if (nums[i] + nums[k] === target) {
                return [i, k];
            }
        }
    }
    return [];
};
console.log(twoSum([2, 7, 11, 15], 9));
console.log(twoSum([3, 2, 4], 6));
console.log(twoSum([3, 3], 6));

//

//

//

// V.2

let twoSum = function (nums, target) {
    numsLength = nums.length;
    for (let i = numsLength - 1; i > 0; i--) {
        let a = nums.pop();
        index = nums.indexOf(target - a);
        if (~index) {
            return [i, index];
        }
    }
    return [];
};
console.log(twoSum([2, 7, 11, 15], 9));
console.log(twoSum([3, 2, 4], 6));
console.log(twoSum([3, 3], 6));

//

//

//

// V.3

let twoSum = function (nums, target) {
    let numsObj = {};
    for (let i = 0; i < nums.length; i++) {
        if (target - nums[i] in numsObj) {
            return [i, numsObj[target - nums[i]]];
        }
        numsObj[nums[i]] = i;
    }
    return [];
};
console.log(twoSum([2, 7, 11, 15], 9));
console.log(twoSum([3, 2, 4], 6));
console.log(twoSum([3, 3], 6));
