

    document.addEventListener('DOMContentLoaded', function () {
        $("#UpdateEvent").hover(function () {
            $(this).css('color', '#b4c9ef')
        }, function () {
            $(this).css('color', '')
        });

    var calendarEl = document.getElementById('evecalendar');

        var calendar = new FullCalendar.Calendar(calendarEl, {
        plugins: ['interaction', 'dayGrid', 'timeGrid', 'list'],
            header: {
        left: 'prev,next today',
    center: 'title',
    right: 'dayGridMonth,timeGridWeek,timeGridDay,listMonth'
},
defaultDate: '2019-08-12',
navLinks: true, // can click day/week names to navigate views
businessHours: true, // display business hours
editable: true,
events: [
                {
        title: 'Business Lunch',
    start: '2019-08-03T13:00:00',
    constraint: 'businessHours'
},
                {
        title: 'Meeting',
    start: '2019-08-13T11:00:00',
    constraint: 'availableForMeeting', // defined below
    color: '#257e4a'
},
                {
        title: 'Conference',
    start: '2019-08-18',
    end: '2019-08-20'
},
                {
        title: 'Party',
    start: '2019-08-29T20:00:00'
},

// areas where "Meeting" must be dropped
                {
        groupId: 'availableForMeeting',
    start: '2019-08-11T10:00:00',
    end: '2019-08-11T16:00:00',
    rendering: 'background'
},
                {
        groupId: 'availableForMeeting',
    start: '2019-08-13T10:00:00',
    end: '2019-08-13T16:00:00',
    rendering: 'background'
},

// red areas where no events can be dropped
                {
        start: '2019-08-24',
    end: '2019-08-28',
    overlap: false,
    rendering: 'background',
    color: '#ff9f89'
},
                {
        start: '2019-08-06',
    end: '2019-08-08',
    overlap: false,
    rendering: 'background',
    color: '#ff9f89'
}
]
});

calendar.render();



$("#calendar").fullCalendar();


});


