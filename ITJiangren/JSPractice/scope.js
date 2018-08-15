/////////////////////////////
// var people = {
//     "age": 10,
//     "heigh": 180,
//     "price": 10,
//     "birthday": "1997/01/01",
// }

var people = new Object();
people.age = 10;
people.height = 180;
people.price = 10;
people.birthday = "1997/01/01";



console.log(people);

function f1(b) {
    b.age = 12
}

f1(people);// pass reference
console.log(people);//the age of people obj have been changed

////////////////////

function f2() {
    var p = 0;
}

// (function (f2) {
//     f2 = 1;
//     console.log("local:"+f2);
// })(f2);// the way to avoid global function a affected by the second function 

// console.log("global:", f2);

(function () {
    f2.age = 1;
    console.log(typeof(f2));
    console.log("local2(age):"+f2.age);
    console.log("local2(height):"+f2.height);
    
})();// the way to avoid global function a affected by the second function 

console.log("global:", f2);

console.log(people);

////////////////////////////////////////////////////////////////

(function (f2) {
    f2.age = 1;
    console.log(typeof(f2));
    console.log("local3(age):"+f2.age);
    console.log("local3(height):"+f2.height);
    
})(people);// “people”这个位置的参数是实际上需要复制的函数名，而“f2”位置上的参数
           // 则是这段函数体的形参。
           //抽象点说，(function(a){a.......}(b)),a是形参，b是实参。
           //也就是说，函数的声明和调用都在一起了。
            //  如果这如果形参那么默认调用函数体内的那个参数。即上面那段代码。 
            //不太确定

console.log("global2:", f2);

console.log(people);

