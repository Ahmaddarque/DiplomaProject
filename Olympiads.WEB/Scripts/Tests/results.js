$(function () {
    var rightCount = parseInt($("#rightCount").val());
    var totalCount = parseInt($("#totalCount").val());
    var wrongCount = totalCount - rightCount;
    var ctx = document.getElementById('taskStatsChart').getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'doughnut',
        data: {
            labels: ['Правильных', 'Неверных'],
            datasets: [{
                label: 'Статистика прохождения теста',
                data: [rightCount, wrongCount],
                backgroundColor: [
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 99, 132, 0.2)'
                ],
                borderColor: [
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 99, 132, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
})