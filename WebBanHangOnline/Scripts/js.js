$(document).ready(function () {
    ShowCount();

    // Thêm sản phẩm vào giỏ hàng
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quantity = parseInt($('#quantity_value').text()); // Lấy số lượng từ số trên giao diện
        var size = $('#size').val(); // Lấy kích thước từ dropdown list
        var color = $('#color').val(); // Lấy kích thước từ dropdown list

        $.ajax({
            url: '/shoppingcart/AddToCart',
            type: 'POST',
            data: { id: id, quantity: quantity, size: size, color: color }, // Truyền id, số lượng, kích thước, màu
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
        var $row = $(this).closest('tr'); // Tìm dòng chứa nút cập nhật
        var id = $row.data("product-id");
        var sizeId = $row.data("size-id");
        var colorId = $row.data("color-id");
        var quantity = $row.find('.quantity-input').val(); // Tìm input số lượng trong dòng
        Update(id, quantity, sizeId, colorId);
    });

    function Update(id, quantity, sizeId, colorId) {
        $.ajax({
            url: '/shoppingcart/Update',
            type: 'POST',
            data: { id: id, quantity: quantity, sizeId: sizeId, colorId: colorId },
            success: function (rs) {
                if (rs.Success) {
                    LoadCart();
                }
            }
        });
    }



    // Xóa sản phẩm từ giỏ hàng
    $('body').on('click', '.btnDelete', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var sizeId = $(this).closest('tr').data('size-id');
        var colorId = $(this).closest('tr').data('color-id');
        var conf = confirm('Bạn muốn xóa sản phẩm này?');
        if (conf == true) {
            $.ajax({
                url: '/shoppingcart/Delete',
                type: 'POST',
                data: { id: id, sizeId: sizeId, colorId: colorId },
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
