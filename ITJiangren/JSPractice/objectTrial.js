var car = new Object();
car.Manufacturer= "Mazda";
car.model       = "M3";


console.log(car);
console.log(car.Manufacturer);

var myObj = new Object();
    str = "myString";
    rand = Math.random();
    obj = new Object();
myObj.type              = "Dot syntax";
myObj["date created"]   = "String with space";
myObj[str]              = "String value";
myObj[rand]             = "Random Number";
myObj[obj]              = "Object";
myObj[""]               = "Even an empty string";

// function temp (){
//     console.log("this is a function for temp");
    
// }

myObj.f1 = function (){
    console.log("this is a function of myObj");
    return true;
}
console.log(myObj);
console.log(myObj.f1);
console.log(myObj.f1());
//myObj.f1();