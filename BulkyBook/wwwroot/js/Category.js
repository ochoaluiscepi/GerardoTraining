
var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $("#tblData").dataTable({
        "ajax": {
            "url":"/Admin/Categories/GetAll"
        },
        "columns": [
            { "data": "name","width":"25%" },
            { "data": "inserted", "width": "20%" },
            { "data": "insertedBy", "width": "5%" },
            { "data": "updated", "width": "20%" },
            { "data": "updatedBy", "width": "5%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href = "/Admin/Categories/Upsert/${data}" class= "btn btn-success text-white" style="cursor:pointer" >
                                    <i class="fas fa-edit"></i>
                                </a>
                                <a onclick=Delete("/Admin/Categories/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i>
                                </a>
                            </div > `;
                }, "width": "25%"
            }
        ]
    });
}
function Delete(url) {
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}