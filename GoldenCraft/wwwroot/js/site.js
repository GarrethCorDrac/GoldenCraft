//google.charts.setOnLoadCallback(drawStuff);

$(document).ready(function () {
    google.charts.load('current', { 'packages': ['bar'] });

    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Home/GetMoves',
        success: function (response) {
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
                width: 750

            };

            var dataArray = [
                ['Przemierzony dystans', 'wędrując', 'łądzią', 'biegnąc', 'skradając się', 'latając', 'inaczej']
            ];

            $.each(response, function (i, item) {
                dataArray.push([item.userName, item.walking, item.boat, item.sprinting, item.sneaking, item.flying, item.other]);
            });

            drawGraph(dataArray, 'move_div', options);
        }
    })

    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Home/GetDiamondBreaks',
        success: function (response) {
            var options = {
                legend: { position: 'none' },
                axes: {
                    x: {
                        0: { side: 'bottom', label: '' } // Top x-axis.
                    }
                },
                bar: { groupWidth: "70%" },
                width: 750
            };

            var dataArray = [
                ['Gracz', 'Ilość']
            ];

            $.each(response, function (i, item) {
                dataArray.push([item.userName, item.amount]);
            });

            drawGraph(dataArray, 'diamonds_div', options);
        }
    })

    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Home/GetPlaytimes',
        success: function (response) {
            var options = {
                legend: { position: 'none' },
                axes: {
                    x: {
                        0: { side: 'bottom', label: '' } // Top x-axis.
                    }
                },
                bar: { groupWidth: "70%" },
                width: 750
            };

            var dataArray = [
                ['Gracz', 'Czas gry']
            ];

            $.each(response, function (i, item) {
                dataArray.push([item.userName, item.time]);
            });

            drawGraph(dataArray, 'playtime_div', options);
        }
    })
});

function drawGraph(dataValues, elementId, options) {
    
    var data = google.visualization.arrayToDataTable(dataValues);  

    var chart = new google.charts.Bar(document.getElementById(elementId));

    chart.draw(data, google.charts.Bar.convertOptions(options));  
}