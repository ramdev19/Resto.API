Data = {}
var detailsOrder = [];
var dataHeader;
var sum = 0;
var APIResto = "https://localhost:7160/";
var js = jQuery.noConflict(true);

js(document).ready(function () {
    Form.Init();
});


function CheckListOrder() {
    if (detailsOrder.length == 0) {
        $('#listOrder').hide();
    } else {
        $('#listOrder').show();
    }
}

var Form = {
    Init: function () {
        TableOrderHeader.Init();
        TableOrderHeader.Search();
    },
    Edit: function () {
        $('#txtDescFood').val(Data.Selected.foodDescription);
        $('#txtFoodId').val(Data.Selected.id);
        $('#detailsOrder').modal('show');
    },
    SaveModalInput: function () {

        var id = $('#txtFoodId').val();
        var txtQty = $('#txtQty').val() == '' ? "0" : $('#txtQty').val();
        var foodDescription = $('#txtDescFood').val();
        var foodName = Data.Selected.foodName
        var foodPrice = Data.Selected.foodPrice

        var details = {};
            details.foodId = id,
            details.foodName = foodName,
            details.foodDescription = foodDescription,
            details.foodPrice = foodPrice,
            details.OrderId = 0,
            details.Quantity = txtQty,
            details.Amount = (foodPrice * txtQty)

        if (txtQty != "0") {
            detailsOrder.push(details);
        }
        console.log(detailsOrder);
        $('#detailsOrder').modal('hide')
        $('#txtQty').val('');
        CheckListOrder();

    },
    SaveModelDetailsOrdered() {
        $('#detailsOrdered').modal('hide');
        $('#txtTotalPayment').html(sum);
        $('#txtTotalPaymentInput').val("");  
        $('#detailsPayment').modal('show');
    }

}



var TableOrderHeader = {
    Init: function () {
        var tblOrder = js('#tblOrder').dataTable({
            "filter": false,
            "destroy": true,
            "data": []
        });
        js('#tblOrder tbody').on('click', 'button.btEdit', function (e) {
            var table = js('#tblOrder').DataTable();
            var data = table.row(js(this).parents('tr')).data();
            if (data != null) {
                Data.Selected = data;
                Form.Edit();
            }
        })
        //TableOrderHeader.Search();
    },
    Search: function () {

        var table = js('#tblOrder').DataTable({
            ajax: {
                url: APIResto + 'api/foods',
                type: 'GET',
                contentType: 'application/json',
                dataSrc: ""
            },
            filter: false,
            lengthMenu: [5, 10, 15],
            destroy: true,
            columns: [
                { data: 'foodName' },
                { data: 'foodDescription' },
                { data: 'foodPrice' },
                {
                    mRender: function (data, type, full) {
                        var strReturn = "<button type='button' title='Edit' class='btn btn-primary btEdit'>Add</button>";
                        return strReturn;
                    }, className: 'dt-center',
                    wudth: '80px'
                }

            ],
            columnDefs: [
                { "orderable": false, "targets": 'no-sort' }
            ]

        })

    },
    DetailsOrdered: function () {
        dataList = detailsOrder;
        table = js('#tblOrdered').DataTable({
            data: dataList,
            destroy: true,
            lengthMenu: [10, 20, 30],
            pagLength: 5,
            processing: false,
            columns: [
                {
                    mRender: function (data, type, full) {
                        var checkbox = "<input type='checkbox' value ='" + full.id + "'/>";
                        return checkbox;
                    }
                },
                { data: 'foodName' },
                { data: 'foodDescription' },
                { data: 'foodPrice' },
                { data: 'Quantity' },
                { data: 'Amount'}
            ],
            columnDefs: [
                { "orderable": false, "targets": 'no-sort' }
            ]
        });
        let summary = 0;
        let c = detailsOrder.map((e) => e.Amount);
        c.forEach(e => {
            summary += e
        });

        sum = summary;
        $('#txtTotalAmount').html(sum);
        $('#detailsOrdered').modal('show');
    }


}


var Ordered = {
    Save: function () {
        Swal.fire({
            title: 'Do you want to save the changes ?',
            showCancelButton: true,
            confirmButtonText: 'Save'
        }).then((result) => {
            let pay = $('#txtTotalPayment').html();
            let payMust = $('#txtTotalPaymentInput').val(); 

            var sendDetail = [];
            sendDetail = detailsOrder;
            for (var i = 0; i < sendDetail.length; i++) {
                delete sendDetail['foodName'];
                delete sendDetail['foodDescription'];
                delete sendDetail['foodPrice']
            };

            var jsonData = {
                //CustomerID: 1,
                OrderDate: new Date(),
                TransactionDate: new Date(),
                TotalPayment: payMust,
                OrderDetails: sendDetail
            };

            console.log(sendDetail);
            var formData = new FormData();
            formData.append("jsonData", JSON.stringify(jsonData));
            console.log(jsonData);

            if (pay == payMust) {
                $.ajax({
                    type: "POST",
                    url: APIResto + 'api/OrderDetails/SaveDataOrdered',
                    data: formData,
                    contentType: false,
                    processData: false,
                    success: function (response) {
                        Swal.fire("Payment Success!", "Enjoy Your Food", "success");
                        $('#detailsPayment').modal('hide');
                        detailsOrder = [];
                    },
                    error: function (e) {
                        $('#divPrint').html(e.responseText);
                    }
                });
            } else {
                Swal.fire("Failed!. Your Payment was Wrong", "Please re-input payment", "warning");
            }
        });
    }
}

