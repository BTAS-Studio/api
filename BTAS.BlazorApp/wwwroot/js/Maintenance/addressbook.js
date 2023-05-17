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
                        /*$('#modalCreateEdit > .modal', data).modal("show");*/
                    },
                    error: function (req, status, error) {
                        alert(status);
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

    var addressBookTable = new Tabulator("#addressBookTable", {
        layout: "fitColumns",      //fit columns to width of table
        responsiveLayout: "hide",  //hide columns that dont fit on the table
        tooltips: true,
        placeholder: "No Clients Found",
        addRowPos: "top",          //when adding a new row, add it to the top of the table
        history: true,             //allow undo and redo actions on the table
        pagination: "remote",       //paginate the data
        paginationSizeSelector: [10, 20, 30, 50],
        ajaxFiltering: true,
        ajaxSorting: true,
        paginationSize: 10,         //allow 7 rows per page of data
        movableColumns: true,      //allow column order to be changed
        resizableRows: true,       //allow row order to be changed
        initialSort: [             //set the initial sort order of the data
            { column: "tbl_client_header_name", dir: "desc" },
        ],
        rowClick: function (e, row, cell) {
        },
        columns: [                 //define the table columns
            { title: "Business Name", headerFilter: "input", field: "tbl_client_header_name" },
            { title: "Creation Date", headerFilter: "input", field: "tbl_client_header_created_date" },
            { title: "Email", headerFilter: "input", field: "tbl_client_header_main_email" },
            { title: "Phone", headerFilter: "input", field: "tbl_client_header_main_phone" },
            { title: "Status", headerFilter: "input", field: "tbl_client_header_active" },
            { title: "Address", headerFilter: "input", field: "tbl_client_header_address1" }
        ]
    });

    Swal.fire({

        title: 'Searching!',

        html: 'Please wait..',

        timer: 10000,

        timerProgressBar: true,

        allowOutsideClick: false,

        showConfirmButton: false

    });

    $.ajax({

        url: 'address/list',

        error: function (XMLHttpRequest, textStatus, errorThrown) {



            //alert('error:1:: '+ textStatus + " (" + errorThrown + ")");

            swal.fire({

                title: textStatus,

                text: errorThrown,

                icon: "error",

                button: "Close",

            });

        },

        success: function (data) {

            

            addressBookTable.replaceData(JSON.stringify(data)); //load data array



            swal.close();



        }//end success

    });


    $("#addressBookForm").on("submit", function (e) {
        displayBusyIndicator();
    });
}(jQuery));