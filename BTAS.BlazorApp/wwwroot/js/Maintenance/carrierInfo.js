(function ($) {
    var isShown = false;
    var table = $('.tableGrid').DataTable({
        pageLength: 10,
        "autoWidth": false,
        dom: '<"html5buttons"B>lTfgitp',
        scrollX: true,
        columnDefs: [
            {
                "targets": [0, 6]
            },
            {
                "targets": [7, 8, 9, 10, 11, 12, 13, 14, 15],
                "visible": false
            }
        ],
        buttons: [
            //{ extend: 'copy' },
            //{ extend: 'csv' },
            { extend: 'excel', title: 'CarrierInfoFile' },
            //{ extend: 'pdf', title: 'ShipperFile' },

            {
                extend: 'print',
                customize: function (win) {
                    $(win.document.body).addClass('white-bg');
                    $(win.document.body).css('font-size', '10px');

                    $(win.document.body).find('table')
                        .addClass('compact')
                        .css('font-size', 'inherit');
                }
            }
        ],
        "olanguage": {
            "processing": '<i class="fa fa-spinner fa-spin" style="font-size:24px;color:rgb(75, 183, 245);"></i>'
        }
    });

    function Index() {
        var $this = this;
        var obj = {};
        function initialize() {

            $("#modalCreateEdit").on('loaded.bs.modal', function (e) {
                console.log("open");
            }).on('hidden.bs.modal', function (e) {
                console.log("close");
            });

            $(".popup").on('click', function (e) {
                if ($(this).attr('data-id') === undefined) {
                    obj.param = ""
                } else {
                    obj.param = "/" + $(this).attr('data-id');
                }
                $("#modalCreateEdit").appendTo("body");
                modelPopup(this);
            });

            function modelPopup(reff) {
                var url = $(reff).data('url');

                $.ajax({
                    type: "GET",
                    url: url + obj.param,
                    dataType: "html",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        $('#modalCreateEdit').find(".modal-dialog").html(msg);
                        //$('#modalCreateEdit > .modal', msg).modal("show");
                    },
                    error: function (req, status, error) {
                        alert(msg);
                    }
                });
            }
        }

        $this.init = function () {
            initialize();
        };
    }
    $(function () {
        var self = new Index();
        self.init();
    });

    function getChildRow(data) {
        // `data` is the data object for the row
        return '<table class="detailGrid" cellpadding="5" cellspacing="0"'
            + ' style="padding-left:50px;">' +
            '<tr>' +
            '<td>Contact Name:</td>' +
            '<td>' + data[7] + '</td>' +
            '<td>Email:</td>' +
            '<td>' + data[8] + '</td>' +
            '<td>Phone:</td>' +
            '<td>' + data[9] + '</td>' +
            '</tr>' +
            '<tr>' +
            '<td>Address:</td>' +
            '<td>' + data[10] + ' ' +
            data[11] + ' ' +
            data[12] + ' ' +
            data[13] + ' ' +
            data[14] + ' ' +
            data[15] + 
            '</td>' +
            '</tr>' +
            '</table>';
    }

    $('.tableGrid tbody').on('click',
        'td.details-control', function () {
            var tr = $(this).closest('tr');
            var row = table.row(tr);

            if (row.child.isShown()) {
                $(tr).removeClass("fa-minus").addClass("fa-plus");
                // Closing the already opened row           
                row.child.hide();

                // Removing class to hide
                tr.removeClass('shown');
            }
            else {
                // Show the child row for detail
                // information
                $(tr).removeClass("fa-plus").addClass("fa-minus");
                row.child(getChildRow(row.data())).show();

                // To show details,add the below class
                tr.addClass('shown');
            }
    });

    $("#carrierForm").submit(function (e) {
        $("#loading").show();
    });
}(jQuery));  