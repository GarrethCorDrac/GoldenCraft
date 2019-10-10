//google.charts.setOnLoadCallback(drawStuff);

$(document).ready(function () {
    google.charts.load('current', { 'packages': ['bar'] });

    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Kill/GetKills',
        success: function (response) {
            console.log(response);
            drawGraph(response, 'top_x_div');
        }
    })
});

function drawGraph(dataValues, elementId) {
    var dataArray = [
        [ 'User Name', 'Amount' ]
    ];

    $.each(dataValues, function (i, item) {
        dataArray.push([item.userName, item.amount]);
    });

    var data = google.visualization.arrayToDataTable(dataArray);  

    var options = {
        legend: { position: 'none' },
        axes: {
            x: {
                0: { side: 'bottom', label: '' } // Top x-axis.
            }
        },
        bar: { groupWidth: "70%" }
    };

    var chart = new google.charts.Bar(document.getElementById(elementId));

    chart.draw(data, google.charts.Bar.convertOptions(options));  
}