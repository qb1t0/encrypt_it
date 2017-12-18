
//////////////////////////////

function startProcess() // MAIN FUNCTION TO START EVERYTHING!!!
{
	var textbox = document.getElementById('in');
	 //textbox.value = '';

	 var sel1 = document.getElementById('select1');
	 var sel2 = document.getElementById('select2');

	 var string1 = sel1.options[sel1.selectedIndex].text;
	 var string2 = sel2.options[sel2.selectedIndex].text;
	 var string3 = textbox.value;

	 textbox.value = '';	 

	 var cryptTypeId = go(string2);

	 var outbox = document.getElementById('out');

	 outbox.value = "well, let's start:\n" + string1+"\n" + string2+"\n" + "text:\n" + string3;

}

///////////////////////////////

function go(s)
{
	var id = 0;

	switch(s)
	{
		case "3DES" : id = 1;
			break;
		case "AES" : id = 2;
			break;
		case "Blowfish" : id = 3;
			break;
		case "Twofish" : id = 4;
			break;
		case "IDEA" : id = 5;
			break;
		case "MD5" : id = 6;
			break;
		case "SHA 1" : id = 7;
			break;
		case "HMAC" : id = 8;
			break;
		case "RSA Security: RC4" : id = 9;
			break;
		default: id = 0;

	}

	 return id;
	

	

}