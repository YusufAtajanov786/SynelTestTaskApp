
var dataTable;
$(document).ready(function () {
    loadList();
   
});

$(document).ready(function () {
    $('.custom-file-input').on("change", function () {
        var fileName = $(this).val().split("\\").pop();
        $(this).next('.custom-file-label').html(fileName);
    });
});


      
   


function loadList() {
    dataTable = $("#DT_load").DataTable({
        "ajax": {
            "url": "/home/getAllEmployeRecords",
            "type": "GET",
            "dataType": "json"
        },
        "columns": [
            { "data": "payroll_Number" },
            { "data": "forenames" },
            { "data": "surname" },           
            { "data": "date_of_Birth" },
            { "data": "telephone" },
            { "data": "mobile" },
            { "data": "address" },
            { "data": "address_2" },
            { "data": "postcode" },
            { "data": "eMail_Home" },
            { "data": "start_Date" },
           
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center" >
                               <div class="row>
                                    <div class="col-5">
                        <a href="/home/edit?id=${data}" class="btn btn-sm btn-success text-white mb-1" style="cursor:pointer;width:70px;>
                            <i class="far fa-edit></i>Edit
                        </a>
                            </div>
                            <div class="col-5">
                        <a class="btn btn-sm btn-danger text-white" style="cursor:pointer;width:70px;" onclick=Delete('/home/delete/'+${data}) >
                            <i class="fa-solid fa-trash"></i> Delete
                        </a>
                            </div>
                       </div>
                    </div>`;
                }

            }
        ],
        "order": [[2, "asc"]],
        "language": {
            "emptyTable": "no data found."
        },        
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to delete this?",
        text: "You will not able to restor the data! ",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "Delete",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message)
                    }
                }
            });
        }
    });
}
