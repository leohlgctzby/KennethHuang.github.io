var numArray = [3,4,-10, 100 ,200, 5];
var numArray2= numArray[0];
for(i=0;i<numArray.length;i++){
    if (numArray2< numArray[i+1]){
        numArray2 = numArray[i+1];
    }
    
}
console.log(numArray2);
