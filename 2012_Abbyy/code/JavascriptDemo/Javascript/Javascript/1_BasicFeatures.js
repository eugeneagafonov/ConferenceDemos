///<reference path="Scripts/jquery-1.7.2.intellisense.js" />
///<reference path="Scripts/write.js" />

// 1. variables

//var name = "Eugene";
//var age = 33;

//writeLine(typeof name + " " + name);
//writeLine(typeof age + " " + age);

// --------------------------------------------
// 2. globals

//function add(first, second) {
//	a = first;
//	return a + second;
//}

//writeLine("1 + 2 = " + add(1, 2));
//writeLine("a: " + a);

//writeLine("54 + 18 = " + add(54, 18));
//writeLine("a: " + a);

//if(!window.a) {
//	write("a is undefined");
//}

// --------------------------------------------
//3. Null. Primitive type. false in boolean expressions. Absense of value

//var test = null;

//if(!test) {
//	writeLine("null -> false");
//}

//test = "abcd";

//if (test) {
//	writeLine("!null -> true");
//}

//test = 0;

//if (!test) {
//	writeLine("0 -> false");
//}

// --------------------------------------------
//4. Undefined. Primitive type. Unknown value. False in bool expressions

//var notAssigned;

//writeLine(notAssigned);

//if(!notAssigned) {
//	writeLine("undefined -> false");
//}

//var person = {
//	name: "Eugene"
//};

//writeLine("Nonexistent property: " + person.age);

// --------------------------------------------
//5. Objects. Everything except string, number (NaN, Infinity), boolean, null, undefined;
// objects are collections of properties (like a hashtable)

//var empty = {};
//writeLine(empty.toString());

//var eugene = new Object();
//eugene.name = "Eugene";
//writeLine(eugene.name);

//var eugene = {
//	name: "Eugene",
//	age: 33
//};

//writeLine(eugene.name);
//writeLine(eugene.age);
//writeLine(eugene.toString());

//// toString()
//writeLine([1, 2, 3].toString());
//writeLine(/\d/.toString());
//writeLine(false.toString());
//writeLine(writeLine.toString());

//eugene.toString = function() {
//	return "Name: " + this.name + ", Age: " + this.age;
//};

//writeLine(eugene.toString());

//var person = {
//	address: {
//		number : 2,
//		street : "ul. Otradnaya"
//	}
//};

// --------------------------------------------
// 6. Equality

//var eugene = { name: "Eugene" };
//writeLine("Eugene equals eugene: " + (eugene === eugene));

//var eugene2 = { name: "Eugene" };
//writeLine("Eugene equals eugene2: " + (eugene === eugene2));

//writeLine("1 == '1': " + (1 == "1"));
//writeLine("1 === '1': " + (1 === "1"));