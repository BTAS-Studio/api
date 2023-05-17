(function ($) {
    function Index() {
        var $this = this;
        var obj = {};
        function initialize() {

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
                        $('#modalCreateEdit > .modal', data).modal("show");
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

    $('.tableGrid').DataTable({
        pageLength: 10,
        "autoWidth": false,
        dom: '<"html5buttons"B>lTfgitp',
        buttons: [
            //{ extend: 'copy' },
            //{ extend: 'csv' },
            { extend: 'excel', title: 'ServicesFile' },
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

    

    $("#serviceForm").submit(function (e) {
        displayBusyIndicator();
    });
}(jQuery));  