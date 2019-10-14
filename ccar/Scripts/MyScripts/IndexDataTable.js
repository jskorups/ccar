

var Popup, dataTable;
$(document).ready(function () {
    dataTable = $('#actionTable').DataTable({
        initComplete: function () {

            this.api().columns([1, 2, 4, 5,6, 7]).every(function () {
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
        drawCallback: function () {
            colorCells();
        },

        "ajax": {
            "url": "/Action/GetData",
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
            { "data": "Initiator" },
            { "data": "reason" },
            { "data": "problem" },
            {
                "data": "originationDate",
                "render": function (value) {
                    if (value === null) return "";
                    return moment(value).format('DD/MM/YYYY');
                }
            },
            {
                "data": "targetDate",
                "render": function (value) {
                    if (value === null) return "";
                    return moment(value).format('DD/MM/YYYY');
                }
            },
            //{
            //    "data": "completionDate",
            //    "render": function (value) {
            //        if (value === null) return "";
            //        return moment(value).format('DD/MM/YYYY');
            //    }

            //},
            { "data": "responsible" },
            { "data": "progressValue" },

            {
                "data": "id", "render": function (dane) {

                    // return "<a class='btn btn-default btn-sm' onclick=Kespa('" + $('#DataUrl').val() + "/" + data + "')><i class='fa fa-pencil'></i> Edit</a><a class='btn btn-danger btn-sm' style='margin-left:5px' onclick=Delete('" + data + "','" + $('#DeleteUrl').val()+"')><i class='fa fa-trash'></i> Delete</a>";
                    //var htmlEdit;
                    //$.get("/Action/EditDeletePartial", function (data) {

                    //    htmlEdit = data;
                    //});
                    //alert(htmlEdit);
                    //return htmlEdit;
                    var msg = $.ajax({ type: "GET", url: "/Action/EditDeletePartial?id=" + dane, async: false }).responseText;
                    return msg;
                },
                "orderable": false,
                "searchable": true,
                "width": "150px"
            }

            //{ "data": "idTypeOfAction" },

            //{ "data": "rootCause" },
            //{ "data": "correctiveAction" },

            //{ "data": "measureEffic" },
            //{ "data": "dateOfEffic" }
        ],
        "language": {
            "emptyTable": "No data found, Pleas click on <b> Add New Button</b>"
        },
        "pageLength": 100

    });



    $('#actionTable tbody').on('click', 'td.details-control', function () {

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


//////////////////////////////////////////////////////


// Array to track the ids of the details displayed rows
//var detailRows = [];

//$('#actionTable tbody').on('click', 'tr td.details-control', function () {
//    var tr = $(this).closest('tr');
//    var row = dt.row(tr);
//    var idx = $.inArray(tr.attr('id'), detailRows);

//    if (row.child.isShown()) {
//        tr.removeClass('details');
//        row.child.hide();

//        // Remove from the 'open' array
//        detailRows.splice(idx, 1);
//    }
//    else {
//        tr.addClass('details');
//        row.child(format(row.data())).show();

//        // Add to the 'open' array
//        if (idx === -1) {
//            detailRows.push(tr.attr('id'));
//        }
//    }
//});

//// On each draw, loop over the `detailRows` array and show any child rows
//dt.on('draw', function () {
//    $.each(detailRows, function (i, id) {
//        $('#' + id + ' td.details-control').trigger('click');
//    });
//});
//} );



//////////////////////////////////////////////////////


function format(d) {
    // `d` is the original data object for the row
    var rowDetail = $.ajax({ type: "GET", url: "/Action/RowDetailsPartial?id=" + d.id, async: false }).responseText;
    return rowDetail;
}



//var scale = [['vPoor', '10%'], ['poor', '45%'], ['avg', '50%'], ['good', '75%'], ['vGood', '100%']];
//var score = $(this).text();
//for (var i = 0; i < scale.length; i++) {
//    if (score <= scale[i][1]) {
//        $(this).addClass(scale[i][0]);



function colorCells() {
    $("td:contains('%')").each(function (index) {
        var scale = [['begin', '10%'], ['inprogres', '50%'], ['done', '100%']];
        console.log([scale]);
        var score = $(this).text();
        for (var i = 0; i < scale.length; i++) {
            //if (score = scale[i][0]) {
            //    $(this).addClass(scale[0][i]);
            //}
            if (score === scale[0][1]) {
                $(this).addClass(scale[0][0]);
            }
            else if (score === scale[1][1]) {
                $(this).addClass(scale[1][0]);
            }
            else if (score === scale[2][1]) {
            $(this).addClass(scale[2][0]);
            }   
        }
    });
}

function Kespa(url) {
    var formDiv = $('<div />');
    $.get(url)
        .done(function (response) {
            formDiv.html(response);

            Popup = formDiv.dialog({
                autoOpen: true,
                resizable: false,
                title: 'Fill Actions Details',
                height: 650,
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
 
