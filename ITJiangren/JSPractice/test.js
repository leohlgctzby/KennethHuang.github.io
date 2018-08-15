var a = { key: 100 };
function squareFuc(args) { args.key = args.key * args.key; } 
squareFuc(a); 
console.log(a.key);//10000