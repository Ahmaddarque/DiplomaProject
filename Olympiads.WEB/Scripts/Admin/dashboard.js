$(function () {
    $.get('/Statistics/MonthVisits', { "month": 1 }, function (visits) {
        let data = [];
        for (var i = 0; i < visits.length; i++) {
            var output = visits.map(s => {
                if (s.hasOwnProperty("Count")) {
                    s.value = s.Count;
                    delete s.Count;
                }
                if (s.hasOwnProperty("Date")) {
                    s.year = s.Date;
                    delete s.Date;
                }
                return s;
            })
        }
        var chart = AmCharts.makeChart("statestics-chart", {
            "type": "serial",
            "marginTop": 0,
            "hideCredits": true,
            "marginRight": 0,
            "dataProvider": visits,
            "valueAxes": [{
                "axisAlpha": 0,
                "dashLength": 6,
                "gridAlpha": 0.1,
                "position": "left"
            }],
            "graphs": [{
                "id": "g1",
                "bullet": "round",
                "bulletSize": 9,
                "lineColor": "#4680ff",
                "lineThickness": 2,
                "negativeLineColor": "#4680ff",
                "type": "smoothedLine",
                "valueField": "value"
            }],
            "chartCursor": {
                "cursorAlpha": 0,
                "valueLineEnabled": false,
                "valueLineBalloonEnabled": true,
                "valueLineAlpha": false,
                "color": '#fff',
                "cursorColor": '#FC6180',
                "fullWidth": true
            },
            "categoryField": "year",
            "categoryAxis": {
                "gridAlpha": 0,
                "axisAlpha": 0,
                "fillAlpha": 1,
                "fillColor": "#FAFAFA",
                "minorGridAlpha": 0,
                "minorGridEnabled": true
            },
            "export": {
                "enabled": true
            }
        });
    }).fail(function (err)
    {
        console.log(err);
    });
});

