
var actionColumn = function (cell, formatterParams, onRendered) {

    var row = cell.getRow();

    var ID = row.getData().idtbl_receptacle;

    var status = row.getData().tbl_receptacle_status;


    if (status == 'CLOSED') {



        var disabledInd = 'disabled-link';



    } else {

        var disabledInd = 'enabled-link';

    }

    return '<span><a id="printLabel" href="#"><i class="fas fa-print"></i></a></span>&nbsp;' +
        '<span><a id="scanItems" class="' + disabledInd + '" href="/Receptacle/CreateEdit?id=' + ID + '"><i class="fas fa-barcode"></i></a></span>';

}



//var scanItems = function (cell, formatterParams, onRendered) {



//    var row = cell.getRow();

//    var ID = row.getIndex();

//    var status = row.getData().status;



//    if (status == 'closed') {



//        var disabledInd = 'disabled-link';



//    } else {



//        var disabledInd = 'enabled-link';



//    }



//    return '<a id="scanItems" class="' + disabledInd + '" href="/dashboard/scan-receptacle?id=' + ID + '"><i class="fas fa-barcode"></i>';



//}





var table = new Tabulator("#example-table", {

    layout: "fitColumns",      //fit columns to width of table

    responsiveLayout: "hide",  //hide columns that dont fit on the table

    tooltips: true,

    //ajaxURL: 'GetAllReceptacle', //ajax URL
    //ajaxParams: {}, //ajax parameters

    ajaxConfig: "post", //ajax HTTP request type   

    placeholder: "No Receptacles Found",

    addRowPos: "top",          //when adding a new row, add it to the top of the table

    history: true,             //allow undo and redo actions on the table

    pagination: "local",       //paginate the data

    paginationSize: 10,         //allow 7 rows per page of data

    movableColumns: true,      //allow column order to be changed

    resizableRows: true,       //allow row order to be changed

    initialSort: [             //set the initial sort order of the data

        { column: "creationDate", dir: "DESC" },

    ],

    columns: [                 //define the table columns
        { title: "Id", headerFilter: "input", field: "idtbl_receptacle", visible: false },

        { title: "Receptacle Id", headerFilter: "input", field: "tbl_receptacle_ref" },

        {
            title: "Creation Date", headerFilter: "input", field: "tbl_receptacle_creation", formatter: function (cell, formatterParams) {
                var toRet = 'No Date';
                if (cell.getValue() != null) toRet = cell.getValue().slice(0, 10)
                return toRet;
            }, align: "center", width: 150
        },

        { title: "Linked HWB", headerFilter: "input", field: "tbl_hawb_id" },

        { title: "Type", headerFilter: "input", field: "tbl_receptacle_type", width: 100, align: "center" },

        { title: "Status", headerFilter: "input", field: "tbl_receptacle_status", width: 100, align: "center" },

        { title: "No. Items", headerFilter: "input", field: "tbl_receptacle_no_items", width: 100, align: "center" },

        { title: "Mode", headerFilter: "input", field: "tbl_receptacle_mode", width: 150 },

        { title: "Origin", headerFilter: "input", field: "tbl_receptacle_origin" },

        { title: "Destination", headerFilter: "input", field: "tbl_receptacle_dest" },

        { title: "Actions", formatter: actionColumn, align: "center", width: 50, headerSort: false, width: 100 }

    ]
});

$("#printLabel").on("click", function (e) {
    e.preventDefault();

    alert("printlabel");
    return false;


    var rowData = row.getData();



    $.ajax({

        type: 'POST',

        url: 'PrintReceptacleLabel',

        data: {

            function: 'print',

            scheduleData: rowData

        },

        error: function (XMLHttpRequest, textStatus, errorThrown) {



            // alert('error:1:: '+ textStatus + " (" + errorThrown + ")");

            swal.fire({

                title: textStatus,

                text: errorThrown,

                icon: "error",

                button: "Close",

            });

        },

        success: function (data) {





        }//end success

    });
});

$(".createLine").click(function () {



    Swal.fire({

        title: 'Creating Receptacle..',

        html: 'Please bear with us',

        timer: 10000,

        timerProgressBar: true,

        showConfirmButton: false

    })





    $.ajax({

        type: 'POST',

        url: 'Receptacle/Create',

        data: {},

        error: function (XMLHttpRequest, textStatus, errorThrown) {



            // alert('error:1:: '+ textStatus + " (" + errorThrown + ")");

            swal.fire({

                title: textStatus,

                text: errorThrown,

                icon: "error",

                button: "Close",

            });

        },

        success: function (data) {


            //debugger;
            swal.close()



            var obj = jQuery.parseJSON(data);


            table.updateOrAddData([{ tbl_receptacle_ref: obj.tbl_receptacle_ref, tbl_receptacle_creation: obj.tbl_receptacle_creation, tbl_receptacle_status: obj.tbl_receptacle_status }])



        }//end success

    });



});


$(".refreshButton").click(function () {
    ReloadReceptacles();
});

function ReloadReceptacles() {
    Swal.fire({

        title: 'Refreshing Data..',

        html: 'Please bear with us',

        timer: 10000,

        timerProgressBar: true,

        showConfirmButton: false

    })

    $.ajax({

        type: 'POST',

        url: "Receptacle/List",

        data: {},

        error: function (XMLHttpRequest, textStatus, errorThrown) {



            // alert('error:1:: '+ textStatus + " (" + errorThrown + ")");

            swal.fire({

                title: textStatus,

                text: errorThrown,

                icon: "error",

                button: "Close",

            });

        },

        success: function (data) {
            //debugger;


            swal.close()

            table.replaceData(data);





        }//end success

    });
}

$(document).ready(function () {

    ReloadReceptacles();

});