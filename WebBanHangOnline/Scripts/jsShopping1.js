﻿$(document).ready(function () {
    ShowCount();

    // Thêm sản phẩm vào giỏ hàng
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quantity = parseInt($('#quantity_value').text()); // Lấy số lượng từ số trên giao diện
        var size = $('#size').val(); // Lấy kích thước từ dropdown list

        $.ajax({
            url: '/shoppingcart/AddToCart',
            type: 'POST',
            data: { id: id, quantity: quantity, size: size }, // Truyền id, số lượng và kích thước
            success: function (rs) {
                if (rs.Success) {
                    $('#checkout_items').html(rs.Count);
                    alert(rs.msg);
                    LoadCart(); // Load lại giỏ hàng sau khi thêm sản phẩm
                }
            }
        });
    });

    // Xóa tất cả sản phẩm trong giỏ hàng
    $('body').on('click', '.btnDeleteAll', function (e) {
        e.preventDefault();

        var conf = confirm('Bạn muốn xóa tất cả sản phẩm này?');
        if (conf == true) {
            DeleteAll();
        }

    });

    // Cập nhật số lượng sản phẩm trong giỏ hàng
    $('body').on('click', '.btnUpdate', function (e) {
        e.preventDefault();
        var id = $(this).data("id");
        var quantity = $('#Quantity_' + id).val();
        Update(id, quantity);
    });

    // Xóa sản phẩm từ giỏ hàng
    $('body').on('click', '.btnDelete', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var conf = confirm('Bạn muốn xóa sản phẩm này?');
        if (conf == true) {
            $.ajax({
                url: '/shoppingcart/Delete',
                type: 'POST',
                data: { id: id },
                success: function (rs) {
                    if (rs.Success) {
                        $('#checkout_items').html(rs.Count);
                        $('#trow_' + id).remove();
                        LoadCart();
                    }
                }
            });
        }
    });
});

// Hiển thị số lượng sản phẩm trong giỏ hàng
function ShowCount() {
    $.ajax({
        url: '/shoppingcart/ShowCount',
        type: 'GET',
        success: function (rs) {
            $('#checkout_items').html(rs.Count);
        }
    });
}

// Xóa tất cả sản phẩm trong giỏ hàng
function DeleteAll() {
    $.ajax({
        url: '/shoppingcart/DeleteAll',
        type: 'POST',
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}

// Cập nhật số lượng sản phẩm trong giỏ hàng
function Update(id, quantity) {
    $.ajax({
        url: '/shoppingcart/Update',
        type: 'POST',
        data: { id: id, quantity: quantity },
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}

// Load lại giỏ hàng
function LoadCart() {
    $.ajax({
        url: '/shoppingcart/Partial_Item_Cart',
        type: 'GET',
        success: function (rs) {
            $('#load_data').html(rs);
        }
    });
}
