

var Popup, dataTable;

$(document).ready(function () {
    dataTable = $('#meetingMinutesTable').DataTable({
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
                $(select).click(function (e) {
                    e.stopPropagation();
                });
            });
        },
        //drawCallback: function () {
        //    colorCells();
        //},

        "ajax": {
            "url": "/MeetingMinutesDatesDetails/GetData",
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

        ],
        "language": {
            "emptyTable": "No data found, Pleas click on <b> Add New Button</b>"
        },
        "pageLength": 100

    });



    $('#meetingMinutesTable tbody').on('click', 'td.details-control', function () {
    
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
     
    var rowDetail = $.ajax({ type: "GET", url: "/Action/RowDetailsPartial?id=" + d.id, async: false }).responseText;
    return rowDetail;
}



function Kespa(url) {
    var formDiv = $('<div />');
    $.get(url)
        .done(function (response) {
            formDiv.html(response);

            Popup = formDiv.dialog({
                autoOpen: true,
                resizable: false,
                title: 'Fill Meeting Details',
                height: 620,
                width: 750,
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
      
