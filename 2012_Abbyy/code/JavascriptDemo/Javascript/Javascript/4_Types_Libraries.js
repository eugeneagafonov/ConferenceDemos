///<reference path="Scripts/jquery-1.7.2.intellisense.js" />
///<reference path="Scripts/write.js" />
///<reference path="Scripts/underscore.js" />
///<reference path="Scripts/date.js" />

// -------------------------------------------
// 1. Strings
//var string1 = "The quick brown fox's jump";

//var string2 = '"The quick brown fox"';

//// escape s
//var a = "\n";
//var b = "\"";
//var c = "\u00A9";

//writeLine(c);

//// concatenation 
//writeLine(string1 + string2);

//// charAt
//var character = "abcd".charAt(2);
//writeLine("Third character in 'abcd' is: " + character);
//writeLine("Type of character is: " + typeof character);
//newParagraph();

//// indexOf
//var index = "abcd".indexOf("c");
//writeLine("Index of 'c' in 'abcd' is: " + index);

//// search
//index = "abcd".search(/c/);
//writeLine("Index of 'c' in 'abcd' is (using 'search'): " + index);
//newParagraph();

//// replace
//var lyric = "3 oh 3 it's a magic number";
//writeLine('lyric.replace("3", "4"): ' + lyric.replace("3", "4"));
//writeLine('lyric: ' + lyric); // has the original string changed?
//writeLine('lyric.replace(/3/, "4"): ' + lyric.replace(/3/, "4"));
//writeLine('lyric.replace(/3/g, "4"): ' + lyric.replace(/3/g, "4"));
//newParagraph();

//// slice
//var letters = ['a', 'b', 'c', 'd'];
//var sliced = letters.slice(1, 3);
//for (var i = 0; i < sliced.length; i++) {
//	writeLine(sliced[i]); 
//}
//newParagraph();

//// split
//var words = "The western wave was all a-flame".split(" ");
//for (var i = 0; i < words.length; i++) {
//	writeLine(words[i]);
//}
//var letters = "abcd".split("");
//for (var i = 0; i < letters.length; i++) {
//	writeLine(letters[i]);
//}
//newParagraph();

//// toUpperCase / toLowerCase
//var name = "Frank";
//writeLine("Upper case of 'Frank': " + name.toUpperCase());
//writeLine("Lower case of 'Frank': " + name.toLowerCase());

// ------------------------------------------------------------
// 2. Number
// all the numbers are floating point
// operators: +, -, *, /, %
// .toFixed(n)

//// number type
//writeLine('type of 1: ' + typeof 1);
//writeLine('typeof 3.14: ' + typeof 3.14);
//newParagraph();

//// operators
//writeLine("1 + 1: " + (1 + 1)); 
//writeLine("10 - 1: " + (10 - 1));
//writeLine("3 * 4: " + (3 * 4));
//writeLine("22 / 7: " + (22 / 7));
//writeLine("22 % 10: " + (22 % 10));
//newParagraph();

//// inexact decimal fractions
//writeLine("0.1 + 0.2: " + (0.1 + 0.2));
//writeLine("(0.1 + 0.2).toFixed(1): " + (0.1 + 0.2).toFixed(1));
//writeLine("(0.1 * 10 + 0.2 * 10) / 10: " + (0.1 * 10 + 0.2 * 10) / 10); // convert to integers. to avoid incorrect results

// ------------------------------------------------------------
// 3. Array
// Array and Object are two built-in objects
// indexed collection

//// empty array 
//var empty = [];
//writeLine("length of an empty array: " + empty.length);
//newParagraph();

//// enumeration
//var letters = ['a', 'b', 'c', 'd'];
//for (var i = 0; i < letters.length; i++) {
//	writeLine(letters[i]); 
//}
//newParagraph();

//// stack methods
//letters.push('e');
//writeLine("['a','b','c','d'].push('e'): " + letters);
//writeLine("['a','b','c','d','e'].pop(): " + letters.pop());
//writeLine("letters: " + letters);
//newParagraph();

//// reverse
//writeLine("['a','b','c','d'].reverse(): " + letters.reverse());
//newParagraph();

//// slice(start, end) - copies part of an array
//writeLine("['a','b','c','d'].slice(1,3): " + ['a','b','c','d'].slice(1,3));
//newParagraph();

//// splice(start, count) - removes part of an array
//var collection = ['a', 'b', 'c', 'd'];
//writeLine("['a','b','c','d'].splice(1,2): " + collection.splice(1,2));
//writeLine("remaining collection: " + collection);
//newParagraph();

//// sort
//writeLine("['q','m','j','t','v','b'].sort(): " + ['q','m','j','t','v','b'].sort());
//writeLine("[2,1,8,99,75,10,22].sort(): " + [2,1,8,99,75,10,22].sort()); //alphabetically
//writeLine([2, 1, 8, 99, 75, 10, 22].sort(function (first, second) {
//	// 0 if equals, <0 if first is less than second, >0 if first is greater that second
//return first - second;
//}));

// ----------------------------------------------------------------------------------------
// 4. underscore.js
// http://documentcloud.github.com/underscore/

//var odds = _.reject([1, 2, 3, 4, 5, 6], function (num) { return num % 2 == 0; });
//writeLine(odds);

//var groups = _.groupBy(['one', 'two', 'three'], 'length');
//for(var i in groups) {
//	writeLine(i + " : " + groups[i]);
//}

//var numbers = [1, 2, 3];

//// functional style
//_.each(numbers, function (num) {
//	writeLine(num);
//});
//newParagraph();

//// object-oriented style
//_(numbers).each(function (num) {
//	writeLine(num);
//});
//newParagraph();

//// map
//var doubled = _(numbers).map(function (num) {
//	return num * 2;
//});
//writeLine("[1,2,3] doubled: " + doubled);
//newParagraph();

//// reduce 
//var total = _(doubled).reduce(function (memo, num) {
//	return memo += num;
//}, 0);
//writeLine("[2,4,6] reduced: " + total);
//newParagraph();

//// select
//var evens = _([1, 2, 3, 4, 5]).select(function (num) {
//	return num % 2 === 0;
//});
//writeLine("[1,2,3,4,5] evens: " + evens);
//newParagraph();

//// all
//var allNumbers = _([1, 2, 'a']).all(function (item) {
//	return typeof item === "number";
//});
//writeLine(allNumbers);
//newParagraph();

//// include
//var hasPeanuts = _(['wheat flour', 'sugar', 'salt', 'peanut', 'caramel']).include("peanut");
//writeLine(hasPeanuts);
//newParagraph();

//// max
//writeLine(_({a: 3, b:2, c:1}).max()); //highest value of properties


// ----------------------------------------------------------------------------------------
// 5. Regular expressions
// search
//var result = "abcde".search(/c/);
//writeLine("index of c in 'abcd': " + result);
//newParagraph();

//// exec
//var input = "Text with some <strong>highlighted</strong> parts.";
//var expression = /<strong>(.*)<\/strong>/;
//var results = expression.exec(input);
//writeLine("matched substring: " + results[0]);
//writeLine("first capture group: " + results[1]);
//newParagraph();

//// test
//var containsANumber = /\d/.test("abc4de");
//writeLine("abc4de contains a number: " + containsANumber);
//newParagraph();

//// replace - replacement can be a string or a function
//var updated = "Fred Brooks".replace(/(\w+) (\w+)/g, function (match, capture1, capture2) {
//	return capture2.toUpperCase() + ", " + capture1;
//});
//writeLine(updated);

// ------------------------------------------------------------------------------------------
// 6. Date

//// 14 августа
//var birthday = new Date(2012, 07, 14);
//writeLine(birthday);
//writeLine(birthday.toUTCString());
//newParagraph();

//// date subtraction
//var from = new Date();
//for (var i = 0; i < 10000000; i++) {
//	var result = Math.sqrt(i);
//}
//var to = new Date();
//var elapsed = to - from;
//writeLine("Calculating the square root of 100,000,000 numbers took: " + elapsed + " milliseconds");
//newParagraph();

////http://datejs.com/

//writeLine(Date.today().getDayName());
//writeLine(Date.parse("tomorrow"));


// ------------------------------------------------------------------------------------------
// 7. Other things:
eval("alert('Hello World');");

var source = { series: [{ title: "Doctor Who", rating: 5 }, { title: "Firefly", rating: 4 }] };

var json = JSON.stringify(source);

writeLine(json);
newParagraph();

var obj = JSON.parse(json);

for (var i in obj.series) {
	writeLine(obj.series[i].title);
}

// json2.js
writeLine("isNaN(NaN): " + isNaN(NaN));
newParagraph();

writeLine('isNaN("hello world"): ' + isNaN("hello world"));
newParagraph();

writeLine("isNaN(5.5): " + isNaN(5.5));
newParagraph();

writeLine("isNaN(2 / 'a'): " + isNaN(2 / 'a'));
newParagraph();

var num = parseFloat("28.567");
writeLine("Parsed: " + num + " isNaN: " + isNaN(num));
newParagraph();

// Math.abs
writeLine("Math.abs(4.2): " + Math.abs(4.2));
writeLine("Math.abs(-4.2): " + Math.abs(-4.2));
newParagraph();

// Math.floor
writeLine("Math.floor(1.909): " + Math.floor(1.909));
writeLine("Math.floor(-1.909): " + Math.floor(-1.909));
newParagraph();

// Math.ceil
writeLine("Math.ceil(1.909): " + Math.ceil(1.909));
writeLine("Math.ceil(-1.909): " + Math.ceil(-1.909));
newParagraph();

// Math.pow
writeLine("Math.pow(3,2): " + Math.pow(3,2));
newParagraph();

// Math.random
writeLine("Math.random(): " + Math.random());
writeLine("Math.random(): " + Math.random());
newParagraph();

// Math.round
writeLine("Math.round(2.5): " + Math.round(2.5));
writeLine("Math.round(-2.2): " + Math.round(-2.2));