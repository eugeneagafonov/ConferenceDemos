///<reference path="Scripts/jquery-1.7.2.intellisense.js" />
///<reference path="Scripts/write.js" />

// -------------------------------------------
// 1. Blocks
//{
//	var a = 1;
//	{
//		{
//			var c = 5;
//			writeLine(a);
//		}
//	}

//	writeLine(c);
//}

// -------------------------------------------------
// 2. Conditions

//if(true) {
//	// this will be executed
//}

//if(false) {
	
//}
//else if (false) {
	
//}
//else {
//	// this will be executed;
//}

//function sayHello(name) {
//	switch(name) {
	
//		case "Dalek":
//			writeLine("Daleks are supreme!");
//			break;
		
//		case "The Doctor":
//			writeLine("Oh My God!");
//			break;
			
//		default:
//			writeLine("Hello, " + name + "!");
//	}
//}

//sayHello("Dalek");
//sayHello("Eugene");

// -------------------------------------------------------
// 3. Loops
//var nums = [1, 2, 3, 4, 5, 6];

//for (var i = 0; i < nums.length; i++) {
//// var i = 0, max = nums.length
//	writeLine( nums[i]);
//}

//for(var i in nums) {
//	writeLine(i);
//}

//var eugene = {
//	name: "Eugene",
//	age: 33
//};

//for (var i in eugene) {
//	writeLine(i);
//}

//writeLine(i);

//var condition = true;

//while (condition) {
//	condition = false;
//}

//do {

//} while (condition);

// -------------------------------------------------------
// 4. Exceptions

//function faultyFunction() {
//	//return 1;
//	throw { name: "TestException", message: "Test" };
//};

//try {

//	var result = faultyFunction();
	
//} catch(e) {
//	writeLine(e.name);
//}
//finally {
//	writeLine("whatever happened");
//}