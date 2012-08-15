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
// ---------------------------------------------------------------




