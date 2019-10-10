//google.charts.setOnLoadCallback(drawStuff);

$(document).ready(function () {
    google.charts.load('current', { 'packages': ['bar'] });

    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Home/GetMoves',
        success: function (response) {
            console.log(response);
            drawGraph(response, 'move_div');
        }
    })
});

function drawGraph(dataValues, elementId) {
    var dataArray = [
        [ 'Przemierzony dystans', 'wędrując', 'łądzią', 'biegnąc', 'skradając się', 'latając', 'inaczej' ]
    ];

    $.each(dataValues, function (i, item) {
        dataArray.push([item.userName, item.walking, item.boat, item.sprinting, item.sneaking, item.flying, item.other]);
    });

    var data = google.visualization.arrayToDataTable(dataArray);  

    var options = {
        legend: { position: 'top', maxLines: 3 },
        bar: { groupWidth: '70%' },
        isStacked: true,
        series: {
            0: { color: 'green' },
            1: { color: 'blue' },
            2: { color: 'red' },
            3: { color: 'blue' },
            4: { color: 'yellow' },
            5: { color: 'red' },
            6: { color: 'white' },
        },
        'width': 1000

    };

    var chart = new google.charts.Bar(document.getElementById(elementId));

    chart.draw(data, google.charts.Bar.convertOptions(options));  
}