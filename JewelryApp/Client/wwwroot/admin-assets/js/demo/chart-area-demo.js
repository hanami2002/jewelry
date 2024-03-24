//// Set new default font family and font color to mimic Bootstrap's default styling
//Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
//Chart.defaults.global.defaultFontColor = '#858796';

//function number_format(number, decimals, dec_point, thousands_sep) {
//  // *     example: number_format(1234.56, 2, ',', ' ');
//  // *     return: '1 234,56'
//  number = (number + '').replace(',', '').replace(' ', '');
//  var n = !isFinite(+number) ? 0 : +number,
//    prec = !isFinite(+decimals) ? 0 : Math.abs(decimals),
//    sep = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep,
//    dec = (typeof dec_point === 'undefined') ? '.' : dec_point,
//    s = '',
//    toFixedFix = function(n, prec) {
//      var k = Math.pow(10, prec);
//      return '' + Math.round(n * k) / k;
//    };
//  // Fix for IE parseFloat(0.55).toFixed(0) = 0;
//  s = (prec ? toFixedFix(n, prec) : '' + Math.round(n)).split('.');
//  if (s[0].length > 3) {
//    s[0] = s[0].replace(/\B(?=(?:\d{3})+(?!\d))/g, sep);
//  }
//  if ((s[1] || '').length < prec) {
//    s[1] = s[1] || '';
//    s[1] += new Array(prec - s[1].length + 1).join('0');
//  }
//  return s.join(dec);
//}
//var goldPrices = [1500, 1550, 1600, 1575, 1650, 1700, 1725, 1750, 1800, 1780, 1820, 1850];
//// Area Chart Example
//var ctx = document.getElementById("myAreaChart");
//var myLineChart = new Chart(ctx, {
//  type: 'line',
//  data: {
//      labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
//      datasets: [{
//          label: "Gold Prices",
//          lineTension: 0.3,
//          backgroundColor: "rgba(255, 193, 7, 0.05)",
//          borderColor: "rgba(255, 193, 7, 1)",
//          pointRadius: 3,
//          pointBackgroundColor: "rgba(255, 193, 7, 1)",
//          pointBorderColor: "rgba(255, 193, 7, 1)",
//          pointHoverRadius: 3,
//          pointHoverBackgroundColor: "rgba(255, 193, 7, 1)",
//          pointHoverBorderColor: "rgba(255, 193, 7, 1)",
//          pointHitRadius: 10,
//          pointBorderWidth: 2,
//          data: goldPrices,
//    }],
//  },
//  options: {
//    maintainAspectRatio: false,
//    layout: {
//      padding: {
//        left: 10,
//        right: 25,
//        top: 25,
//        bottom: 0
//      }
//    },
//    scales: {
//      xAxes: [{
//        time: {
//          unit: 'date'
//        },
//        gridLines: {
//          display: false,
//          drawBorder: false
//        },
//        ticks: {
//          maxTicksLimit: 7
//        }
//      }],
//      yAxes: [{
//        ticks: {
//          maxTicksLimit: 5,
//          padding: 10,
//          // Include a dollar sign in the ticks
//          callback: function(value, index, values) {
//            return '$' + number_format(value);
//          }
//        },
//        gridLines: {
//          color: "rgb(234, 236, 244)",
//          zeroLineColor: "rgb(234, 236, 244)",
//          drawBorder: false,
//          borderDash: [2],
//          zeroLineBorderDash: [2]
//        }
//      }],
//    },
//    legend: {
//      display: false
//    },
//    tooltips: {
//      backgroundColor: "rgb(255,255,255)",
//      bodyFontColor: "#858796",
//      titleMarginBottom: 10,
//      titleFontColor: '#6e707e',
//      titleFontSize: 14,
//      borderColor: '#dddfeb',
//      borderWidth: 1,
//      xPadding: 15,
//      yPadding: 15,
//      displayColors: false,
//      intersect: false,
//      mode: 'index',
//      caretPadding: 10,
//      callbacks: {
//        label: function(tooltipItem, chart) {
//          var datasetLabel = chart.datasets[tooltipItem.datasetIndex].label || '';
//          return datasetLabel + ': $' + number_format(tooltipItem.yLabel);
//        }
//      }
//    }
//  }
//});
// Tạo dữ liệu giả mạo cho giá bán vàng (đơn vị: đô la)
var goldPrices = [1500, 1520, 1510, 1505, 1512, 1508, 1500, 1515, 1510, 1502, 1498, 1505];

// Tạo dữ liệu cho biểu đồ
var data = {
    labels: ["1", "2", "3", "4", "5", "6", "6", "6", "6", "6", "6", "6"],
    datasets: [{
        label: "Gold Prices",
        lineTension: 0.3,
        backgroundColor: "rgba(255, 193, 7, 0.05)",
        borderColor: "rgba(255, 193, 7, 1)",
        pointRadius: 3,
        pointBackgroundColor: "rgba(255, 193, 7, 1)",
        pointBorderColor: "rgba(255, 193, 7, 1)",
        pointHoverRadius: 3,
        pointHoverBackgroundColor: "rgba(255, 193, 7, 1)",
        pointHoverBorderColor: "rgba(255, 193, 7, 1)",
        pointHitRadius: 10,
        pointBorderWidth: 2,
        data: goldPrices,
    }]
};

// Cài đặt các tùy chọn cho biểu đồ
var options = {
    maintainAspectRatio: false,
    layout: {
        padding: {
            left: 10,
            right: 25,
            top: 25,
            bottom: 0
        }
    },
    scales: {
        xAxes: [{
            time: {
                unit: 'date'
            },
            gridLines: {
                display: false,
                drawBorder: false
            },
            ticks: {
                maxTicksLimit: 7
            }
        }],
        yAxes: [{
            ticks: {
                maxTicksLimit: 5,
                padding: 10,
                // Bao gồm dấu đô la trong các dấu
                callback: function (value, index, values) {
                    return '$' + value;
                }
            },
            gridLines: {
                color: "rgb(234, 236, 244)",
                zeroLineColor: "rgb(234, 236, 244)",
                drawBorder: false,
                borderDash: [2],
                zeroLineBorderDash: [2]
            }
        }],
    },
    legend: {
        display: false
    },
    tooltips: {
        backgroundColor: "rgb(255,255,255)",
        bodyFontColor: "#858796",
        titleMarginBottom: 10,
        titleFontColor: '#6e707e',
        titleFontSize: 14,
        borderColor: '#dddfeb',
        borderWidth: 1,
        xPadding: 15,
        yPadding: 15,
        displayColors: false,
        intersect: false,
        mode: 'index',
        caretPadding: 10,
        callbacks: {
            label: function (tooltipItem, chart) {
                return 'Price: $' + tooltipItem.yLabel;
            }
        }
    }
};

// Tạo biểu đồ
var ctx = document.getElementById('myAreaChart').getContext('2d');
var myLineChart = new Chart(ctx, {
    type: 'line',
    data: data,
    options: options
});

