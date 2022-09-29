$(document).ready(function () {
    $("#products-table").dataTable();

    $("body").on("click", ".editProduct", function () {
        var productId = $(this).attr("data-product");
        window.location.href = "/Products/ProductDetails?productId=" + productId;
    });

    $("body").on("click", ".deleteProduct", function () {
        var productId = $(this).attr("data-product");
        $.ajax({
            type: 'POST',
            url: '/Products/DeleteProduct',
            data: { "productId": productId },
            success: function (response) {
                $("tr[data-rowid='" + productId + "']").remove();
                window.location.href = "/Products/Index";
            }
        });
    });

    $("body").on("click", ".viewProduct", function () {
        var productId = $(this).attr("data-product");
        $.ajax({
            type: 'GET',
            url: '/Products/ViewProduct',
            data: { "productId": productId },
            success: function (response) {
                $("#productDetails-container").html(response);
            }
        });
    });

    $("#activeDateFrom").datepicker({
        showOtherMonths: true,
        selectOtherMonths: true,
        changeMonth: false,
        changeYear: false
    });
    $("#activeDateTo").datepicker({
        showOtherMonths: true,
        selectOtherMonths: true,
        changeMonth: false,
        changeYear: false
    });

    $("body").on("click", "#save-product-btn", function (event) {
        if ($("input[name='Product.Product_Id'").val() !== "" && $("input[name='Product.Product_Id'").val() !== null
            && $("input[name='Product.Product_Id'").val() !== undefined) {
            EditProduct($("input[name='Product.Product_Id'").val());
        } else {
            SaveProduct();
        }

    });

    $("body").on("click", "#colors-content .mdl-switch__input", function () {

        if ($(this).attr("data-checked") === 'true') {
            $(this).attr("data-checked", false);
            $(this).parent("label").removeClass("is-checked");
        } else {
            $(this).attr("data-checked", true);
            $(this).parent("label").addClass("is-checked");
        }

    });
});

function SaveProduct() {
    if ($("#products-form")[0].checkValidity()) {
        event.preventDefault();

        var colorsArr = [];

        $("#colors-content .mdl-switch__input").each(function (index, item) {
            if ($(item).attr("data-checked") === 'true') {
                colorsArr.push($(item).attr("data-color"));
            }
        })

        var product = {
            Category_Id: $("select[name='Product.Category_Id']").val(),
            Product_Name: $("input[name='Product.Product_Name']").val(),
            product_Description: $("input[name='Product.Product_Description']").val()
        };
        var productDetails = {
            Qty_In_Stock: $("input[name='ProductDetails.Qty_In_Stock']").val(),
            Tax: $("input[name='ProductDetails.Tax']").val(),
            Price: $("input[name='ProductDetails.Price']").val(),
            Discount: $("input[name='ProductDetails.Discount']").val(),
            Active_Date_From: $("input[name='ProductDetails.Active_Date_From']").val(),
            Active_Date_To: $("input[name='ProductDetails.Active_Date_To']").val(),
        }
        var model = {
            Product: product,
            ProductDetails: productDetails,
            AttributeValues: colorsArr,
            AttributeId: $("#colors-content").attr("data-attributeid")
        };

        $.ajax({
            type: 'POST',
            url: '/Products/AddProduct',
            data: { "productModel": JSON.stringify(model) },
            success: function (response) {
                if (response.status === "success") {
                    if (document.getElementById("files").files.length > 0) {
                        UploadProductImages(response.productId);
                    } else {
                        window.location.href = "/Products/Index?status=" + response.status + "&message=" + response.message;
                    }

                }
            }
        });
    }

}

function UploadProductImages(productIds) {
    var input = document.getElementById("files");
    var files = input.files;
    var formData = new FormData();

    for (var i = 0; i != files.length; i++) {
        formData.append("files", files[i]);
    }
    $.ajax({
        type: 'POST',
        url: '/Products/UploadProductsImages?productId=' + productIds,
        data: formData,
        contentType: false,
        enctype: 'multipart/form-data',
        processData: false,
        success: function (response) {
            window.location.href = "/Products/Index?status=" + response.status + "&message=" + response.message;
        }
    });
}

function EditProduct(productId) {
    if ($("#products-form")[0].checkValidity()) {
        event.preventDefault();

        var product = {
            Product_Id: $("input[name='Product.Product_Id'").val(),
            Category_Id: $("select[name='Product.Category_Id']").val(),
            Product_Name: $("input[name='Product.Product_Name']").val(),
            product_Description: $("input[name='Product.Product_Description']").val()
        };
        var productDetails = {
            Qty_In_Stock: $("input[name='ProductDetails.Qty_In_Stock']").val(),
            Tax: $("input[name='ProductDetails.Tax']").val(),
            Price: $("input[name='ProductDetails.Price']").val(),
            Discount: $("input[name='ProductDetails.Discount']").val(),
            Active_Date_From: $("input[name='ProductDetails.Active_Date_From']").val(),
            Active_Date_To: $("input[name='ProductDetails.Active_Date_To']").val(),
        }
        var model = {
            Product: product,
            ProductDetails: productDetails
        };

        $.ajax({
            type: 'POST',
            url: '/Products/EditProduct',
            data: { "productModel": JSON.stringify(model) },
            success: function (response) {
                $("#saveAlert").addClass("alert-" + response.status);
                $("#saveMessage").html(response.message);
                $("#saveAlert").show();
            }
        });
    }

}