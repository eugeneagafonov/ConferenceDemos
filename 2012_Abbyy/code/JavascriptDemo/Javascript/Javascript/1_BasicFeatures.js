///<reference path="Scripts/jquery-1.7.2.intellisense.js" />
///<reference path="Scripts/write.js" />

writeLine(a);
var a = 30;
writeLine(a);

var test = function(value) {
    if(value == "") {
        alert("empty!")
    }
}

var i = 20;

(function(){
    writeLine(i);

    var i = 50;

    writeLine(i);
})();

writeLine(i);

function foo() {
    return {
        'name': 'john'
    };
}

writeLine(foo().name);

function bar() {
    return
    {
        'name' : 'john'
    };
}

writeLine(bar().name);