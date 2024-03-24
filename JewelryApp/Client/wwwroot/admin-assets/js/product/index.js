
var url = 'https://localhost:7137/api/Product';
var pageIndex = 1, totalPage = 1, action = ''; 

$(document).ready(function () {
    LoadProducts();

    $('#btnAdd').click(function () {
        var modal = $('#productModal');
        $('#productModalLabel').text('Add Product');
        action = 'add';
        modal.modal('show');
        addFieldInput('add', null);
    });

    $('#btnSearch').click(function () {
        var modal = $('#productModal');
        $('#productModalLabel').text('Search Product');
        action = 'search';
        modal.modal('show');
        addFieldInput('search', null);
    });

    $('#btnSave').click(function () {
        console.log('action', action);
        if (action == 'add')
            AddProduct();
        else if (action == 'edit')
            EditProduct();
        else if (action == 'search') {
            pageIndex = 1;
            LoadProducts();
        }
    });
});

function EditProduct() {
    var token = 'aa';

    if (token) {

        var req = {
            productId: $('#id').val(),
            name: $('#name').val(),
            sellPrice: $('#sellPrice').val(),
            categoryId: $('#categoryId').val(),
            inStock: $('#inStock').val(),
            desciption: $('#desciption').val(),
            detail: $('#detail').val(),
            imageLink: $('#old-img').attr('src'),
            materialId: $('#materialId').val(),
        };

        var mess = validateInput(req);
        if (mess != '') {
            alert(mess);
            return;
        }

        $.ajax({
            url: url + '/update?id=' + req.productId,
            type: 'PUT',
            headers: {
                'Authorization': 'Bearer ' + token,
                'Content-type': 'Application/json'
            },
            data: JSON.stringify(req),
            success: function (data) {
                $('#productModal').modal('hide');
                LoadProducts();
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

function AddProduct() {
    var token = 'aa';

    if (token) {

        var req = {
            name: $('#name').val(),
            sellPrice: $('#sellPrice').val(),
            categoryId: $('#categoryId').val(),
            inStock: $('#inStock').val(),
            desciption: $('#desciption').val(),
            detail: $('#detail').val(),
            imageLink: $('#old-img').attr('src'),
            materialId: $('#materialId').val(),
        };

        var mess = validateInput(req);
        if (mess != '') {
            alert(mess);
            return;
        }

        $.ajax({
            url: url + '/AddProduct',
            type: 'POST',
            headers: {
                'Authorization': 'Bearer ' + token,
                'Content-type': 'Application/json'
            },
            data: JSON.stringify(req),
            success: function (data) {
                $('#productModal').modal('hide');
                LoadProducts();
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

function LoadProducts() {
    var token = 'aa';

    if (token) {

        var newurl = 'https://localhost:7137/api/Product/Admin';
        var apiUrl = newurl+ `?pagenamme=3&page=${pageIndex}`;

        if (action == 'search') {
            apiUrl = getSearchUrl();
        }

        $.ajax({
            url: apiUrl,
            type: 'GET',
            headers: {
                'Authorization': 'Bearer ' + token,
                'Content-type': 'Application/json'
            },
            success: function (data) {
                console.log('Data from API:', data);
                pageIndex = data.pageIndex;
                totalPage = data.totalPage;
                DisplayData(data.items);
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

function getSearchUrl() {
    var search = $('#name').val();
    var from = $('#from').val(), to = $('#to').val();
    var cId = $('#categoryId').val(), mId = $('#materialId').val();
    var apiUrl = url + '/Admin' + `?pagenamme=3&search=${search}&page=${pageIndex}`

    if (from != '')
        apiUrl += `&from=${from}`;
    if (to != '')
        apiUrl += `&to=${to}`;
    if (cId != -1)
        apiUrl += `&categoryID=${cId}`;
    if (mId != -1)
        apiUrl += `&materialID=${mId}`;

    return apiUrl;
}

function DisplayData(data) {
    var tbody = $('#data');
    tbody.empty();

    $.each(data, function (i, p) {
        var row = '<tr>';
        row += '<td>' + p.name + '</td>';
        row += '<td>' + p.sellPrice + '</td>';
        row += '<td>' + p.categoryName + '</td>';
        row += '<td>' + p.inStock + '</td>';
        row += '<td><img src="' + p.imageLink + '" width="50px" height="50px" /></td>';
        row += '<td>' + p.materialName + '</td>';
        row += '<td> <button data-id="' + p.productId + '" class="btn btn-warning btnEdit">Edit</button>' +
            ' <button data-id="' + p.productId + '" class="btn btn-danger btnDelete">Delete</button></td>'; 
        row += '</tr>';
        tbody.append(row);
    });

    $('.btnEdit').click(function () {
        var id = $(this).data('id');
        console.log('edit id: ', id);
        $('#productModalLabel').text('Edit Product');
        action = 'edit';
        GetProductDetail(id);
    });

    $('.btnDelete').click(function () {
        var id = $(this).data('id');
        console.log('delete id: ', id);
        DeleteProduct(id);
    });
}

function GetProductDetail(id) {
    var modal = $('#productModal');
    var token = 'aa';

    if (token) {

        $.ajax({
            url: `https://localhost:7137/api/Product/GetProductById/${id}`,
            type: 'GET',
            headers: {
                'Authorization': 'Bearer ' + token,
                'Content-type': 'Application/json'
            },
            success: function (data) {
                console.log('Data from API:', data);
                addFieldInput('edit', data);
                modal.modal('show');
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error('Error:', errorThrown);
                alert('Product Not Found!');
            }
        });
    } else {
        console.error('Token not found in cookie');
    }
}

function addFieldInput(type, pro) {
    var mBody = $('#mBody');
    mBody.empty();

    var nameField = $('<div class="form-group">' +
        '<label for="name">Name</label>' +
        '<input type="text" class="form-control" id="name">' +
        '</div>');

    var sellPriceField = $('<div class="form-group">' +
        '<label for="sellPrice">Sell Price</label>' +
        '<input type="number" class="form-control" id="sellPrice">' +
        '</div>')

    if (type == 'search') {
        sellPriceField = $('<div class="form-group">' +
            '<label for="from">Sell Price From</label>' +
            '<input type="number" class="form-control" id="from">' +
            '</div>' + '<div class="form-group">' +
            '<label for="to">Sell Price To</label>' +
            '<input type="number" class="form-control" id="to">' +
            '</div>');
    }

    var categoryField = $('<div class="form-group">' +
        '<label for="categoryId">Category</label>' +
        '<select class="form-control" id="categoryId">' +
        '</select>' +
        '</div>');

    var pId = type == "edit" ? pro.productId : -1;
    mBody.append(`<input value="${pId}" id="id" hidden />`);
    mBody.append(nameField);
    mBody.append(sellPriceField);
    mBody.append(categoryField);

    if (type != 'search') {
        var inStockField = $('<div class="form-group">' +
            '<label for="inStock">In Stock</label>' +
            '<input type="number" class="form-control" id="inStock">' +
            '</div>');

        var descriptionField = $('<div class="form-group">' +
            '<label for="desciption">Description</label>' +
            '<textarea class="form-control" id="desciption"></textarea>' +
            '</div>');

        var detailField = $('<div class="form-group">' +
            '<label for="detail">Detail</label>' +
            '<textarea class="form-control" id="detail"></textarea>' +
            '</div>');

        var imageLinkField = $('<div class="form-group">' +
            '<label for="imageLink">Image Link</label>' +
            '<input type="file" class="form-control" id="imageLink" accept="image/*">' +
            '<input type="text" class="form-control" id="oldImageLink" hidden>' +
            '<img id="old-img" width="50px" height="50px"/>' +
            '</div>');
        mBody.append(inStockField);
        mBody.append(descriptionField);
        mBody.append(detailField);
        mBody.append(imageLinkField);

        addChangeImgEvent();
    }
    
    var materialField = $('<div class="form-group">' +
        '<label for="materialId">Material</label>' +
        '<select class="form-control" id="materialId">' +
        '</select>' +
        '</div>');

    mBody.append(materialField);

    if (type == 'edit') {
        $('#name').val(pro.name);
        $('#sellPrice').val(pro.sellPrice);
        $('#inStock').val(pro.inStock);
        $('#desciption').val(pro.desciption);
        $('#detail').val(pro.detail);
        $('#old-img').attr('src', pro.imageLink);
        $('#oldImageLink').val(pro.imageLink);
        LoadCategory(pro.categoryName);
        LoadMaterialId(pro.materialName);
    } else {
        LoadCategory(-1);
        LoadMaterialId(-1);
    }

}

function validateInput(req) {
    if (req.name == '') {
        return 'name is required!';
    }
    else if (req.sellPrice <= 0) {
        return 'sell price must be > 0!';
    }
    else if (req.inStock < 0) {
        return 'in stock must be >= 0!';
    }

    return '';
}

function addChangeImgEvent() {
    $('#imageLink').change(function () {
        var file = this.files[0]; 
        var oldImageLink = $('#oldImageLink').val(); 

        if (file) {
            var reader = new FileReader(); 

            reader.onload = function (e) {
                $('#old-img').attr('src', e.target.result);
            };

            reader.readAsDataURL(file);
        } else {
            $('#old-img').attr('src', oldImageLink);
        }
    });
}

function LoadCategory(cName) {
    var token = 'aa';

    if (token) {

        $.ajax({
            url: 'https://localhost:7137/api/Category/all',
            type: 'GET',
            headers: {
                'Authorization': 'Bearer ' + token,
                'Content-type': 'Application/json'
            },
            success: function (data) {
                var select = $('#categoryId');
                select.empty();

                if (action == 'search') {
                    select.append('<option value="-1">No Selection</option>');
                }

                $.each(data, function (i, c) {
                    var option = $('<option>');
                    option.attr('value', c.categoryId); 
                    option.text(c.name);

                    if (c.name == cName) {
                        option.attr('selected', true);
                    }

                    option.css('color', 'black');
                    select.append(option);
                });
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error('Error:', errorThrown);
            }
        });
    } else {
        console.error('Token not found in cookie');
    }
}

function LoadMaterialId(mName) {
    var token = 'aa';

    if (token) {

        $.ajax({
            url: 'https://localhost:7137/api/Material',
            type: 'GET',
            headers: {
                'Authorization': 'Bearer ' + token,
                'Content-type': 'Application/json'
            },
            success: function (data) {
                var select = $('#materialId');
                select.empty();

                if (action == 'search') {
                    select.append('<option value="-1">No Selection</option>');
                }

                $.each(data, function (i, c) {
                    var option = $('<option>');
                    option.attr('value', c.materialId);
                    option.text(c.name);

                    if (c.name == mName) {
                        option.attr('selected', true);
                    }

                    option.css('color', 'black');
                    select.append(option);
                });
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error('Error:', errorThrown);
            }
        });
    } else {
        console.error('Token not found in cookie');
    }
}

function DeleteProduct(id) {
    if (confirm('Are you sure delete this product?') == true) {
        var token = 'aa';

        if (token) {

            $.ajax({
                url: `https://localhost:7137/api/Product/Delete?id=${id}`,
                type: 'DELETE',
                headers: {
                    'Authorization': 'Bearer ' + token,
                    'Content-type': 'Application/json'
                },
                success: function (data) {
                    LoadProducts();
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
        LoadProducts();
    });
}