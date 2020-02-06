function validateForm() {
	if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(document.forms["email"]["input"].value))
	{
		alert("Correct email address")
		return(true)
	}
    	alert("You have entered an invalid email address!")
}