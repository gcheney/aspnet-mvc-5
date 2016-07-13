function switchViews() {
	$(".hidden, .visible").toggleClass("hidden visible");
}

function processResponse(appt) {
	$('#successClientName').text(appt.ClientName);
	var terms;
	if (appt.TermsAccepted) {
		terms = "You accepted the terms";
	} else {
		terms = "You did NOT accept the terms";
	}
	$('#successTermsAccepted').text(terms);
	switchViews();
}

$(document).ready(function () {
	$('#backButton').click(function (e) {
		switchViews();
	});
});