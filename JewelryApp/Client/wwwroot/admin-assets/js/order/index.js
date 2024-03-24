var url = 'https://localhost:7137/api/Order';
var pageIndex = 1, totalPage = 1, action = '';
var type = null, statuss = null, from = null, to = null;

$(document).ready(function () {
    LoadOrder();

    $('#btnSearch').click(function () {
        $('#orderModal').modal('show');
    });

    $('#btnSave').click(function () {
        type = $('#type').val() == 'all' ? null : $('#type').val();
        statuss = $('#status').val() == 'all' ? null : $('#status').val() == '1';
        from = $('#from').val() == '' ? null : $('#from').val();
        to = $('#to').val() == '' ? null : $('#to').val();
        LoadOrder();
    });
});


function LoadOrder() {
    var token = 'aa';

    if (token) {

        var req = {
            pageIndex: pageIndex,
            type: type,
            status: statuss,
            from: from,
            to: to
        };
        console.log(req);

        $.ajax({
            url: url + '/getallorder',
            type: 'POST',
            headers: {
                'Authorization': 'Bearer ' + token,
                'Content-type': 'Application/json'
            },
            data: JSON.stringify(req),
            success: function (data) {
                console.log('Data from API:', data);
                pageIndex = data.pageIndex;
                totalPage = data.pageCount;
                DisplayData(data.orders);
                LoadPagination();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error('Error:', errorThrown);
                alert('Something went wrong!');
            }
        });
    } else {
        console.error('Token not found in cookie');
    }
}

function DisplayData(data) {
    var tbody = $('#data');
    tbody.empty();

    $.each(data, function (i, o) {
        var row = '<tr>';
        row += '<td>' + o.orderId + '</td>';
        row += '<td>' + o.type + '</td>';
        row += '<td>' + o.userid + '</td>';
        row += '<td>' + o.dateOrder + '</td>';
        row += '<td>' + o.total + '</td>';
        row += '<td>' + (o.status == true ? 'Checked' : 'Not Yet') + '</td>';
        row += '<td><button data-id="' + o.orderId + '" class="btn btn-info btnView">View Detail</button></td>';
        row += '</tr>';
        tbody.append(row);
    });

    $('.btnView').click(function () {
        var oId = $(this).data('id');
        LoadDetail(oId);
    });
}

function LoadDetail(oId) {
    var token = 'aa';

    if (token) {

        $.ajax({
            url: `https://localhost:7137/api/Detail/${oId}`,
            type: 'GET',
            headers: {
                'Authorization': 'Bearer ' + token,
                'Content-type': 'Application/json'
            },
            success: function (data) {
                console.log('Data from API:', data);
                DisplayDetail(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error('Error:', errorThrown);
                alert('Something went wrong!');
            }
        });
    } else {
        console.error('Token not found in cookie');
    }
}

function DisplayDetail(data) {
    var tbody = $('#data2');
    tbody.empty();
    var grandTotal = 0;

    $.each(data, function (i, d) {
        var row = '<tr>';
        row += '<td>' + d.detailId + '</td>';
        row += '<td><img src="' + d.image + '" width="50px" height="50px"/></td>';
        row += '<td>' + d.productName + '</td>';
        row += '<td>' + d.price + '</td>';
        row += '<td>' + d.quantity + '</td>';
        row += '<td>' + d.total + '</td>';
        row += '</tr>';
        tbody.append(row);
        grandTotal += d.total;
    });
    $('#grandTotal').text('Grand Total: ' + grandTotal);
    $('#detailModal').modal('show');
}

function LoadPagination() {
    $('.pagination').empty();

    for (var i = 1; i <= totalPage; i++) {
        var liClass = (i === pageIndex) ? 'page-item active' : 'page-item';
        var liContent = '<li class="' + liClass + '"><a class="page-link">' + (i) + '</a></li>';
        $('.pagination').append(liContent);
    }

    $('.page-item').click(function () {
        pageIndex = $(this).text();
        LoadOrder();
    });
}