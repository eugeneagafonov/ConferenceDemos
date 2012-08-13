function write(text) {
    $("#outputDiv").append(text);
}

function writeLine(text) {
    $("#outputDiv").append(text + '<br/>');
}

function newParagraph() {
	writeLine("");
}