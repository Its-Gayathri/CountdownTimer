﻿
var date,
	now = new Date(),
	newYear = new Date('1.1.2020').getTime(),
	startTimer = '';

document.addEventListener("DOMContentLoaded", function (event) {
	var dates = reminders[0].reminderDate;	
	getAllReminders(reminders);
	calcTime(dates);
});

//calculate date, hour, minute and second
function calcTime(dates) {
	clearInterval(startTimer);

	if(typeof(dates) == 'undefined'){
		date = new Date(newYear).getTime();
	}else {
		date = new Date(dates).getTime();
	}

	function updateTimer(date){

		var now = new Date().getTime();
		var distance = date - now;

		// Time calculations for days, hours, minutes and seconds
		var days = Math.floor(distance / (1000 * 60 * 60 * 24));
		var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
		var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
		var seconds = Math.floor((distance % (1000 * 60)) / 1000);

		// select element
		document.querySelector('.clock-day').innerHTML = days;
		document.querySelector('.clock-hours').innerHTML = hours;
		document.querySelector('.clock-minutes').innerHTML = minutes;
		document.querySelector('.clock-seconds').innerHTML = seconds;

		if(now >= date){
			clearInterval(startTimer);
			document.querySelector('.clock-day').innerHTML = 'D';
			document.querySelector('.clock-hours').innerHTML = 'O';
			document.querySelector('.clock-minutes').innerHTML = 'N';
			document.querySelector('.clock-seconds').innerHTML = 'E';
		}
	}

	startTimer = setInterval(function() { updateTimer(date); }, 1000);

}

function getAllReminders(reminders) {
	if (reminders != undefined && reminders != null) {
		$.each(reminders, function (index, item) {
			if (index == 0) {
				var reminderdiv = "<div href='#' class='list-group-item list-group-item-action active border border-3' data-reminderDate = '" + item.reminderDate + "'>" + item.reminderName + "<br>" + moment(item.reminderDate).format('DD/MM/YYYY') + "<button type='button' class='close btn-reminder-close' aria-label='Close'> <span aria-hidden='true'>&times;</span> </button> </div>";
				$('#list-allReminders').append(reminderdiv);
			}
			else {
				var reminderdiv = "<div href='#' class='list-group-item list-group-item-action border border-3' data-reminderDate = '" + item.reminderDate + "'  data-reminderId = '" + item.id + "'>" + item.reminderName + "<br>" + moment(item.reminderDate).format('DD/MM/YYYY') + "<button type='button' class='close btn-reminder-close' aria-label='Close'> <span aria-hidden='true'>&times;</span> </button> </div>";
				$('#list-allReminders').append(reminderdiv);
			}
		});
	}
	else {
		var reminderdiv = "<div href='#' class='list-group-item list-group-item-action active border border-3'>No Reminders Available!!<button type='button' class='close btn-reminder-close' aria-label='Close'> <span aria-hidden='true'>&times;</span> </button> </div>";
		$('#list-allReminders').append(reminderdiv);
    }
};

$(document).ready(function () {
	$(".list-group-item.list-group-item-action").click(function () {
		$('.list-group-item.list-group-item-action.active').removeClass('active');
		$(this).addClass('active');
		var currentDate = $(this).data("reminderdate");
		now = new Date(),
		startTimer = '';
		calcTime(currentDate);
	});

	$('.btn-reminder-close').click(function () {		
		var reminderId = $(this).closest('.list-group-item.list-group-item-action').data("reminderid");
		$(this).parent().remove();
		$.ajax({
			type: "POST",
			url: "/Home/DeleteReminder",
			data: {
				reminderId: reminderId
			},
			success: function (data) {
				
			}
		});
	});

	
	
	$('#modal-addReminder').on('shown.bs.modal', function () {
		$('.fetched-date input').datepicker({
			//beforeShow: function (input, inst) {
			//	inst.dpDiv.css({
			//		marginTop: -input.offsetHeight + 'px',
			//		marginLeft: input.offsetWidth + 'px'
			//	});
			//},
			orientation: "top",
			format: "dd/mm/yyyy",
			startDate: "01-01-2015",
			//endDate: "01-01-2020",
			todayHighlight: true,
			todayBtn: "linked",
			autoclose: true,
			//calendarWeeks: true,
		});
	});

	(function () {
		'use strict'

		// Fetch all the forms we want to apply custom Bootstrap validation styles to
		var forms = document.querySelectorAll('.needs-validation')

		// Loop over them and prevent submission
		Array.prototype.slice.call(forms)
			.forEach(function (form) {
				form.addEventListener('submit', function (event) {
					if (!form.checkValidity()) {
						event.preventDefault()
						event.stopPropagation()
					}

					form.classList.add('was-validated')
				}, false)
			})
	})()

	$('#save-btn-AddReminder').click(function () {	
		$('#modal-addReminder').modal('hide');
		var reminderName = $('#id-reminderName').val();
		var reminderDate = $('#id-reminderDate').val();
		var reminderType = $('#id-reminderType').val();
		var data =
		{
			ReminderName: reminderName,
			ReminderDate: reminderDate,
			ReminderType: reminderType
		}
		sendDataToBackEnd(data, "/Home/AddReminder");
		location.reload();
	});
});

function sendDataToBackEnd(data, uri) {
	$.ajax({
		type: "POST",
		url: uri,
		data: data,
		async: false,
		success: function (data) {			
		}
	});
}	