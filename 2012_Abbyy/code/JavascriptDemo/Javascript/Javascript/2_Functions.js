///<reference path="Scripts/jquery-1.7.2.intellisense.js" />
///<reference path="Scripts/write.js" />

// 1. function declaration
//function square(x) {
//	return x * x;
//}

//var squareFunc = function square(x) {
//	return x * x;
//	throw { name : "TestException", message: "Test" };
//};

//var squareFunc2 = function (x) {
//	return x * x;
//	throw { name : "TestException", message: "Test" };
//};

//squareFunc(2);

//var numberToSquare = 2;

//(function(x) {
//	return x * x;
//})(numberToSquare);

//(function ($) {
	
//	// any jQuery plugin
//	$.fn.extend({		
//		myPluginName: function (options) {
//			var defaults = {
//				padding: 40,
//				color: "#00ffff"
//			};

//			options = $.extend(defaults, options);
			
//			alert(options.padding);
//			alert(options.color);
//			alert(this.html());
//		}
//	});

//})(jQuery);

//var result = square(7);
//writeLine(result);

//function add(num, num2, num3) {
//	return num + num2 + num3;
//}

//function add (num, num2) {
//	return num + num2;
//}

//writeLine(add(6, 7));
//writeLine(add(6, 7, 8));

//$("#outputDiv").myPluginName({ padding: 20 });

// --------------------------------------------------------
// 2. invocation, parameters
//function add(num, num2) {
//	writeLine(typeof num2);
//	return num + num2;
//}

//write(add(3));

//var name = "Eugene";

//function reverse(s) {
//	s = s.split("").reverse().join("");
//	return s;
//}

//writeLine("<br/>" + reverse(name));
//writeLine(name);

//var eugene = { name: "Eugene" };

//function reversePersonsName(p) {
//	p.name = reverse(p.name);
//	return p;
//}

//writeLine(reversePersonsName(eugene).name);
//writeLine(eugene.name);

// --------------------------------------------------------
//3. Arguments object
//function argumentsType() {
//	//writeLine("Arguments length: " + arguments.length);
//	//writeLine("Arguments[0]: " + arguments[0]);
//	return typeof arguments;
//}

//writeLine("Type of arguments: " + argumentsType("string"));

//function add() {
//	var total = 0;
//	for(var i = 0; i <arguments.length; i++) {
//		total += arguments[i];
//	}

//	return total;
//}

//writeLine(add());
//writeLine(add(1, 3));
//writeLine(add(1, 3, 5, 7));

//function fibonacci(n) {
//	if (n == 0 || n == 1) {
//		return 1;
//	}

//	return fibonacci(n - 2) + fibonacci(n - 1);
//}

//for (var i = 0; i <= 10; i++) {
//	writeLine(fibonacci(i));
//}


// --------------------------------------------------------
//4. Closures

//var a = "a";

//var outer = function() {

//	var b = "b";
//	var middle = function() {

//		var c = "c";
//		var inner = function () {
//			// all variables are accessible
//			writeLine(a + b + c);
//		};

//		inner();
//	};
//	middle();

//};

//outer();