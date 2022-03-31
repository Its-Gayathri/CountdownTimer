﻿// load event listeners
//loadEventListeners();

//function loadEventListeners() {
//	document.addEventListener('DOMContentLoaded', function() { calcTime(); });
//};

//var timeTo = document.getElementById('time-to').value,
//		date,
//		now = new Date(),
//		newYear = new Date('1.1.2020').getTime(),
//		startTimer = '';

// calculate date, hour, minute and second
//function calcTime(dates) {
//	//ui variables
//	clearInterval(startTimer);

//	if(typeof(dates) == 'undefined'){
//		date = new Date(newYear).getTime();
//	}else {
//		date = new Date(dates).getTime();
//	}

//	function updateTimer(date){

//		var now = new Date().getTime();
//		var distance = date - now;

//		// Time calculations for days, hours, minutes and seconds
//		var days = Math.floor(distance / (1000 * 60 * 60 * 24));
//		var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
//		var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
//		var seconds = Math.floor((distance % (1000 * 60)) / 1000);

//		// select element
//		document.querySelector('.clock-day').innerHTML = days;
//		document.querySelector('.clock-hours').innerHTML = hours;
//		document.querySelector('.clock-minutes').innerHTML = minutes;
//		document.querySelector('.clock-seconds').innerHTML = seconds;

//		if(now >= date){
//			clearInterval(startTimer);
//			document.querySelector('.clock-day').innerHTML = 'D';
//			document.querySelector('.clock-hours').innerHTML = 'O';
//			document.querySelector('.clock-minutes').innerHTML = 'N';
//			document.querySelector('.clock-seconds').innerHTML = 'E';
//		}
//	}

//	startTimer = setInterval(function() { updateTimer(date); }, 1000);

//}


document.addEventListener("DOMContentLoaded", function (event) {
	getAllReminders(reminders);
});
	
function getAllReminders(reminders) {
	if (reminders != undefined && reminders != null) {
		$.each(reminders, function (index, item) {
			if (index == 0) {
				var reminderdiv = "<div href='#' class='list-group-item list-group-item-action active border border-3'>" + item.reminderName + "<button type='button' class='close btn-reminder-close' aria-label='Close'> <span aria-hidden='true'>&times;</span> </button> </div>";
				$('#list-allReminders').append(reminderdiv);
			}
			else {
				var reminderdiv = "<div href='#' class='list-group-item list-group-item-action border border-3'>" + item.reminderName + "<button type='button' class='close btn-reminder-close' aria-label='Close'> <span aria-hidden='true'>&times;</span> </button> </div>";
				$('#list-allReminders').append(reminderdiv);
			}
		});
	}
	else {
		var reminderdiv = "<div href='#' class='list-group-item list-group-item-action active border border-3'>No Reminders Available!!<button type='button' class='close btn-reminder-close' aria-label='Close'> <span aria-hidden='true'>&times;</span> </button> </div>";
		$('#list-allReminders').append(reminderdiv);
    }
	};