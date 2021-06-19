$(function () {
    let chartVisits = {
        "type": "serial",
            "marginTop": 0,
                "hideCredits": true,
                    "marginRight": 0,
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
    }
    let chartParticipants = {
        "type": "serial",
        "marginTop": 0,
        "hideCredits": true,
        "marginRight": 0,
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
            "lineColor": "#CCCC00",
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
    }
    let chartMonthVisits = {
        "type": "serial",
        "marginTop": 0,
        "hideCredits": true,
        "marginRight": 0,
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
    }
    let chartMonthParticipants = {
        "type": "serial",
        "marginTop": 0,
        "hideCredits": true,
        "marginRight": 0,
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
            "lineColor": "#CCCC00",
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
    }
    function loadMonthStats() {
        let period = parseInt($("#monthPeriod").val());
        $.get("/Statistics/MonthVisits", {"month":period}).done(function (monthVisits) {
            var data = monthVisits.map(s => {
                if (s.hasOwnProperty("Count")) {
                    s.value = s.Count;
                    delete s.Count;
                }
                if (s.hasOwnProperty("Date")) {
                    s.year = s.Date;
                    delete s.Date;
                }
                return s;
            });
            chartMonthVisits.dataProvider = data;
            var a = AmCharts.makeChart("visiterMonthStats", chartMonthVisits);
        });
        $.get("/Statistics/MonthRegistrations", { "month": period }).done(function (monthRegs) {
            var data = monthRegs.map(s => {
                if (s.hasOwnProperty("Count")) {
                    s.value = s.Count;
                    delete s.Count;
                }
                if (s.hasOwnProperty("Date")) {
                    s.year = s.Date;
                    delete s.Date;
                }
                return s;
            });
            chartMonthParticipants.dataProvider = data;
            var a = AmCharts.makeChart("participantMonthStats", chartMonthParticipants);
        });
        $.get("/Statistics/MonthParticipantVisiterRatio", { "month": period }).done(function (ratio) {
            am4core.useTheme(am4themes_animated);
            // Themes end

            // Create chart instance
            var chart = am4core.create("participantMonthStats", am4charts.XYChart);
            chart.data = data;
            var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
            categoryAxis.dataFields.category = "year";
            categoryAxis.renderer.grid.template.location = 0;
            categoryAxis.renderer.minGridDistance = 30;

            categoryAxis.renderer.labels.template.adapter.add("dy", function (dy, target) {
                if (target.dataItem && target.dataItem.index & 2 == 2) {
                    return dy + 0;
                }
                return dy;
            });

            var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());

            // Create series
            var series = chart.series.push(new am4charts.ColumnSeries());
            series.dataFields.valueY = "value";
            series.dataFields.categoryX = "year";
            series.name = "Visits";
            series.columns.template.tooltipText = "{categoryX}: [bold]{valueY}[/]";
            series.columns.template.fillOpacity = .8;

            var columnTemplate = series.columns.template;
            columnTemplate.strokeWidth = 2;
            columnTemplate.strokeOpacity = 1;
            am4core.useTheme(am4themes_animated);
            // Themes end

            // Create chart instance
            var chart = am4core.create("participantVisiterMonthRatio", am4charts.PieChart);

            // Add data
            var colorSet = new am4core.ColorSet();
            colorSet.list = ["#CCCC00", "#4680FF"].map(function (color) {
                return new am4core.color(color);
            });
            chart.data = [{
                "user": "Участник",
                "count": ratio.First
            }, {
                "user": "Посетитель",
                "count": ratio.Second
            }];
        });
    }
    $.post("/Statistics/WeeklyVisits").done(function (weeklyVisits) {
        var data = weeklyVisits.map(s => {
            if (s.hasOwnProperty("Count")) {
                s.value = s.Count;
                delete s.Count;
            }
            if (s.hasOwnProperty("Date")) {
                s.year = s.Date;
                delete s.Date;
            }
            return s;
        });
        chartVisits.dataProvider = data;
        var a = AmCharts.makeChart("visiterWeekStats", chartVisits);
    });

    $.post("/Statistics/WeeklyRegistrations").done(function (weeklyRegs) {
        var data = weeklyRegs.map(s => {
            if (s.hasOwnProperty("Count")) {
                s.value = s.Count;
                delete s.Count;
            }
            if (s.hasOwnProperty("Date")) {
                s.year = s.Date;
                delete s.Date;
            }
            return s;
        });
        chartParticipants.dataProvider = data;
        var a = AmCharts.makeChart("participantWeekStats", chartParticipants);
    });

    $.post("/Statistics/WeeklyParticipantVisiterRatio").done(function (ratio) {
        // Themes begin
        am4core.useTheme(am4themes_animated);
        // Themes end

        // Create chart instance
        var chart = am4core.create("participantVisiterWeekRatio", am4charts.PieChart);

        // Add data
        var colorSet = new am4core.ColorSet();
        colorSet.list = ["#CCCC00", "#4680FF"].map(function (color) {
            return new am4core.color(color);
        });
        chart.data = [{
            "user": "Участник",
            "count": ratio.First
        }, {
            "user": "Посетитель",
            "count": ratio.Second
        }];

        // Add and configure Series
        var pieSeries = chart.series.push(new am4charts.PieSeries());
        pieSeries.dataFields.value = "count";
        pieSeries.dataFields.category = "user";
        pieSeries.colors = colorSet;
        pieSeries.slices.template.stroke = am4core.color("#fff");
        pieSeries.slices.template.strokeWidth = 2;
        pieSeries.slices.template.strokeOpacity = 1;

        // This creates initial animation
        pieSeries.hiddenState.properties.opacity = 1;
        pieSeries.hiddenState.properties.endAngle = -90;
        pieSeries.hiddenState.properties.startAngle = -90;

    });
    
    $("#monthPeriod").change(function () {
        let period = parseInt($(this).val());
        if (period > 0) {
            loadMonthStats();
        }
        else {
            $(this).val(1);
            //loadMonthStats();
        }
    });
    loadMonthStats();
});