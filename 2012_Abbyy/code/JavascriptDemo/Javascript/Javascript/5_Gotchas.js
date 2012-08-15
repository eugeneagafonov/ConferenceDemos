///<reference path="Scripts/jquery-1.7.2.intellisense.js" />
///<reference path="Scripts/write.js" />
///<reference path="Scripts/underscore.js" />
///<reference path="Scripts/date.js" />

// -------------------------------------------
// Gotchas
// 1. Chain assignement
//var a = 2;

//var a, b;
//a = b = 2;

//var a = b = 2; // b - global
//if(window.b) {
//    writeLine("b is a global variable");
//}


//(function () {
//    var fun = function() {
//        writeLine(a); // defined to undefined
//        //writeLine(b);
//        var a = 20;
//        writeLine(a);
//    };

//    fun();

//}());

//(function () {
//    var i;

//    i = 199;
    
//    for (var i = 0; i < 10; i++)
//        ;

//    writeLine(i);

//}());

//var i = 20;
//(function () {
    
//    writeLine(i);
    
//    var i = 50;

//    writeLine(i);
//}());

//writeLine(i);

//function foo() {
//    function bar() {
//        return 3;
//    }
//    return bar();
//    function bar() {
//        return 8;
//    }
//}
//writeLine(foo());

//function foo() {
//    var bar = function () {
//        return 3;
//    };
//    return bar();
//    var bar = function () {
//        return 8;
//    };
//}
//writeLine(foo());

//writeLine(foo());
//function foo() {
//    var bar = function () {
//        return 3;
//    };
//    return bar();
//    var bar = function () {
//        return 8;
//    };
//}

//function foo() {
//    return bar();
//    var bar = function () {
//        return 3;
//    };
//    var bar = function () {
//        return 8;
//    };
//}
//writeLine(foo());

//// declare all vars at the very first line of a function

// -------------------------------------------------------------

//writeLine(parseInt("10"));
//writeLine(parseInt("010")); // IE10 - wtf??
//writeLine(parseInt("0x10"));
//writeLine(parseInt("09"));
//writeLine(parseInt("09", 10));

//var a = "09" - 1;
//writeLine(a);

//var a = "09" + "010";
//writeLine(a);

//var a = + "09" + "10";
//writeLine(a);

//var a = + "09" + "010";
//writeLine(a);

//var a = + "09" + ( + "010");
//writeLine(a);

//var a = "3" * "010";
//writeLine(a);

//writeLine(parseInt(1 / 0, 24));
// ---------------------------------------------------------------

//var a = 20
//a = 5

//writeLine(a);

// --

//function foo() {
//	return {
//		"name" : "eugene"
//	};
//}

////function bar() {
////	return 
////	{
////		name : "eugene"
////	};
////}

//writeLine(foo().name);
////writeLine(bar().name);

//---------------------------

//(function () {

//	var i = 50;

//	writeLine(i);
//	for (var i = 0; i < 10; i++) {
//		writeLine(i);
//	}

//	writeLine(i);
//}());

////--
//var p1 = {
//	name: "Eugene",
//	sayHello: function() {
//		writeLine("Hi, my name is " + this.name);
//	}
//};

//p1.sayHello();

//var p2 = {
//	name: "Eugene",
//	sayHello: function () {
//		var f = function() {
//			writeLine("Hi, my name is " + this.name);
//		};
//		f();
//	}
//};

//p2.sayHello();

////--

//var processor = function(msg) {
//	var message = msg;

//	return {
//		greet: function(callback) {
//			return msg + " " + callback();
//		}
		
		
//	};
//};

//var person = function(name) {
//	return {
//		name: name,
//		getName : function () {
//			return this.name;
//		}
//	};
//};

//var p = person("Eugene");
//writeLine(p.getName());

//var proc = processor("Hello");
//writeLine(proc.greet(p.getName));

////proc.greet = function(callback, ctx) { return "New hello! " + callback.call(ctx); };
////writeLine(proc.greet(p.getName, p));

////--

//function inherit(proto) {
//	function F() { }
//	F.prototype = proto;
//	return new F;
//}

//function Animal(name) {
//	var self = this;
//	self.name = name;
//}

//Animal.prototype = {
//	type: "mammal",
//	walk: function() {
//		writeLine(self.name + " walks!");
//	}
//};

//function Rabbit() {
//	test: "rabbit";
//}

//Rabbit.prototype = inherit(Animal.prototype);

//Rabbit.prototype.jump = function () {
//	writeLine(this.name + " jumps!");
//}

//var r = new Rabbit("Eugene");
//r.walk();
//r.jump();