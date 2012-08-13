///<reference path="../Scripts/jquery-1.7.2-vsdoc.js"/>

$(document).ready(function () {

	loadSettings();
	$("#SubmitButton").click(function() {
		if (hasLocalStorage) {
			storeSettings();
		}
		else {
			alert("No local storage support");
		}
	});
	
	$("#ClearButton").click(function () {
		localStorage.clear();
		loadSettings();
	});
});

function loadSettings() {
	var name = localStorage.getItem("name");
	$("#NameTextBox").val(name);
}

function storeSettings() {
	try {
		localStorage.setItem("name", $("#NameTextBox").val());
	}
	catch(e) {
		if(e == QUOTA_ERR) {
			alert("Storage quota exceeded");
		}
	}
}

function hasLocalStorage() {
	return ('localStorage' in window && window['localStorage'] != null);
}