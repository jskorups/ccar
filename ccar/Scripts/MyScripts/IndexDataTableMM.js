

var Popup, dataTable;

$(document).on('click', '.panel-heading span.clickable', function (e) {
    var $this = $(this);
    if (!$this.hasClass('panel-collapsed')) {
        $this.parents('.panel').find('.panel-body').slideUp();
        $this.addClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-chevron-down').addClass('glyphicon-chevron-up');

    } else {
        $this.parents('.panel').find('.panel-body').slideDown();
        $this.removeClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-chevron-up').addClass('glyphicon-chevron-down');

    }
});

$(document).ready(function () {
    dataTable = $('#Meeting').DataTable({
        initComplete: function () {
            this.api().columns([ 1,2]).every(function () {
                var column = this;
                var select = $('<select><option value="">Show all</option></select>')
                    .appendTo($(column.header()))
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex(
                            $(this).val()
                        );
                        column
                            .search(val ? '^' + val + '$' : '', true, false)
                            .draw();
                    });
                column.cells('', column[0]).render('display').sort().unique().each(function (d, j) {
                    //select.append('<option value="' + d + '">' + d + '</option>')
                    select.append('<option value="' + d + '">' + d.substr(0, 30) + '</option>')
                });
               
                });
           
        },
        //drawCallback: function () {
        //    colorCells();
        //},

        "ajax": {
            "url": "/Meeting/GetData",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "className": 'details-control',
                "data": null,
                "defaultContent": "",
                 width: "15px"
            },
     
            {
                "data": "Date",
                "render": function (value) {
                    if (value === null) return "";
                    return moment(value).format('DD/MM/YYYY');
                }
            },
            { "data": "ProjectName" },
            {
                "data": "id", "render": function (dane) {

                    // return "<a class='btn btn-default btn-sm' onclick=Kespa('" + $('#DataUrl').val() + "/" + data + "')><i class='fa fa-pencil'></i> Edit</a><a class='btn btn-danger btn-sm' style='margin-left:5px' onclick=Delete('" + data + "','" + $('#DeleteUrl').val()+"')><i class='fa fa-trash'></i> Delete</a>";
                    //var htmlEdit;
                    //$.get("/Action/EditDeletePartial", function (data) {

                    //    htmlEdit = data;
                    //});
                    //alert(htmlEdit);
                    //return htmlEdit;
                    var msg = $.ajax({ type: "GET", url: "/Meeting/EditDeletePartial?id=" + dane, async: false }).responseText;
                    return msg;
                },
                "orderable": false,
                "searchable": true,
                "width": "150px"
            }

        ],
        "language": {
            "emptyTable": "No data found, Pleas click on <b> Add New Button</b>"
        },
        "pageLength": 100

    });



    $('#Meeting tbody').on('click', 'td.details-control', function () {
    
        var tr = $(this).closest('tr');
        var tdi = tr.find("i.fa");
        var row = dataTable.row(tr);

        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
        }
        else {
            // Open this row
            row.child(format(row.data())).show();
            tr.addClass('shown');
        
        }
    });
    dataTable.on("user-select", function (e, dt, type, cell, originalEvent) {
        if ($(cell.node()).hasClass("details-control")) {
            e.preventDefault();
        }
    });
});



function format(d) {
     
    var rowDetail = $.ajax({ type: "GET", url: "/Meeting/RowDetailsPartial?id=" + d.id, async: false }).responseText;
    return rowDetail;
}



function AddNew(url) {
    var formDiv = $('<div />');
    $.get(url)
        .done(function (response) {
            formDiv.html(response);

            Popup = formDiv.dialog({
                autoOpen: true,
                resizable: false,
                title: 'Add Meeting',
                height: 600,
                width: 1200,
                close: function () {
                    Popup.dialog('destroy').remove();
                }

            });
        });
}


function PopupForm(url) {
    var formDiv = $('<div />');
    $.get(url)
        .done(function (response) {
            formDiv.html(response);

            Popup = formDiv.dialog({
                autoOpen: true,
                resizable: false,
                title: 'Fill Actijjjjjjjons Details',
                height: 300,
                width: 1100,
                close: function () {
                    Popup.dialog('destroy').remove();
                }

            });
        });
}

function SubmitForm(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        //$.ajax({
        //    type: "POST",
        //    url: form.action,
        //    data: $(form).serialize(),
        //    success: function (data) {
        //        //if (data.success) {
        //            Popup.dialog('close');
        //            dataTable.ajax.reload();

        jQuery.ajax({
            URL: form.action,
            data: $(form).serialize(),
            dataType: "json",
            type: "POST",
            success: function (data) {
                Popup.dialog('close');
                dataTable.ajax.reload();




                $.notify(data.message, {
                    globalPosition: "top center",
                    className: 'superblue',
                    style: 'happyblue'
                });

                //}
            }
        });
    }
    return false;
}
function Delete(id, urlForDelete) {
    if (confirm('Are You Sure to Delete this Employee Record ?')) {
        $.ajax({
            type: "POST",
            url: urlForDelete + '/' + id, /*'@Url.Action("Delete","Action")/' + id,*/
            success: function (data) {
                //if (data.success)
                {
                    dataTable.ajax.reload();
               
                    $.notify(data.message, {
                        globalPosition: "top center",
                        //className: "danger",
                        type: "danger"

                    });

                }
            }

        });
    }
}
      
