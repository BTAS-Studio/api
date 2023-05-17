var table = new Tabulator("#hawbTable", {



    layout: "fitColumns",      //fit columns to width of table

    responsiveLayout: "hide",  //hide columns that dont fit on the table

    tooltips: true,

    placeholder: "No Shipments Found",

    ajaxURL: "", //"/<?php echo $_SESSION['subdir']; ?>/ajax/get-air-shipments.php",

    ajaxConfig: {

        method: "POST",

        //headers: {

        //    "X-CSRF-TOKEN": nonce, //set specific content type

        //      },

    }, //ajax HTTP request type

    ajaxParams: {

        fromDate: "ignore",

    },            //show tool tips on cells

    addRowPos: "top",          //when adding a new row, add it to the top of the table

    history: true,             //allow undo and redo actions on the table

    pagination: "local",       //paginate the data

    paginationSize: 7,         //allow 7 rows per page of data

    movableColumns: true,      //allow column order to be changed

    resizableRows: true,       //allow row order to be changed

    initialSort: [             //set the initial sort order of the data

        { column: "mawb", dir: "asc" },

    ],

    rowClick: function (e, row, cell) {



        Swal.fire({

            title: "Loading...",

            icon: 'success',

            showConfirmButton: false

        });







        var jobReference = row.getData().jobReference;



        $.ajax({

            type: 'POST',

            url: '', //'/<?php echo $_SESSION['subdir']; ?>/ajax/get-air-shipment-detail.php',

            data: {

                jobReference: jobReference

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



                var obj = jQuery.parseJSON(data);



                var items = '';



                if (obj.tbl_air_shipment_DG == 0) {

                    var dgInd = 'No';

                } else {

                    var dgInd = 'Yes';

                }





                var row = 1;

                $.each(obj.parcelsDe, function (idx, value) {



                    if (row == 1) {



                        items += '<div class="form-row item-row">' +

                            '<div class="col-md-1" >' +

                            '<div class="position-relative form-group">' +

                            '<label for="emailCol">Qty</label>' +

                            '<input name="item[][itemQty]" id="itemqty" placeholder="" ' +

                            'type="numeric" class="form-control" value ="' + value.parcelQty + '" disabled>' +

                            '</div>' +

                            '</div >' +

                            '<div class="col-md-4">' +

                            '<div class="position-relative form-group">' +

                            '<label for="emailCol">Reference</label>' +

                            '<input name="item[][itemRef]" id="yourRef" placeholder="" ' +

                            'type="text" class="form-control" value ="' + value.parcelReference + '" disabled>' +

                            '</div>' +

                            '</div>' +

                            '<div class="col-md-2">' +

                            '<div class="position-relative form-group">' +

                            '<label for="emailCol">Weight</label>' +

                            '<input name="item[][itemWeight]" id="itemWeight" placeholder="" ' +

                            'type="numeric" class="form-control" value ="' + value.parcelWeight + '" disabled>' +

                            '</div>' +

                            '</div>' +

                            '<div class="col-md-1">' +

                            '<div class="position-relative form-group">' +

                            '<label for="emailCol">Length</label>' +

                            '<input name="item[][itemLength]" id="itemLenght" placeholder="" ' +

                            'type="numeric" class="form-control" value ="' + value.parcelLength + '" disabled>' +

                            '</div>' +

                            '</div>' +

                            '<div class="col-md-1">' +

                            '<div class="position-relative form-group">' +

                            '<label for="emailCol">Width</label>' +

                            '<input name="item[][itemWidth]" id="itemWidth" placeholder="" ' +

                            'type="numeric" class="form-control" value ="' + value.parcelWidth + '" disabled>' +

                            '</div>' +

                            '</div>' +

                            '<div class="col-md-1">' +

                            '<div class="position-relative form-group">' +

                            '<label for="emailCol">Height</label>' +

                            '<input name="item[][itemHeight]" id="itemHeight" placeholder="" ' +

                            'type="numeric" class="form-control" value ="' + value.parcelHeight + '" disabled>' +

                            '</div>' +

                            '</div>' +

                            '</div > ';



                    } else {



                        items += '<div class="form-row item-row">' +

                            '<div class="col-md-1" >' +

                            '<div class="position-relative form-group">' +

                            '<input name="item[][itemQty]" id="itemqty" placeholder="" ' +

                            'type="numeric" class="form-control" value ="' + value.parcelQty + '" disabled>' +

                            '</div>' +

                            '</div >' +

                            '<div class="col-md-4">' +

                            '<div class="position-relative form-group">' +

                            '<input name="item[][itemRef]" id="yourRef" placeholder="" ' +

                            'type="text" class="form-control" value ="' + value.parcelReference + '" disabled>' +

                            '</div>' +

                            '</div>' +

                            '<div class="col-md-2">' +

                            '<div class="position-relative form-group">' +

                            '<input name="item[][itemWeight]" id="itemWeight" placeholder="" ' +

                            'type="numeric" class="form-control" value ="' + value.parcelWeight + '" disabled>' +

                            '</div>' +

                            '</div>' +

                            '<div class="col-md-1">' +

                            '<div class="position-relative form-group">' +

                            '<input name="item[][itemLength]" id="itemLenght" placeholder="" ' +

                            'type="numeric" class="form-control" value ="' + value.parcelLength + '" disabled>' +

                            '</div>' +

                            '</div>' +

                            '<div class="col-md-1">' +

                            '<div class="position-relative form-group">' +

                            '<input name="item[][itemWidth]" id="itemWidth" placeholder="" ' +

                            'type="numeric" class="form-control" value ="' + value.parcelWidth + '" disabled>' +

                            '</div>' +

                            '</div>' +

                            '<div class="col-md-1">' +

                            '<div class="position-relative form-group">' +

                            '<input name="item[][itemHeight]" id="itemHeight" placeholder="" ' +

                            'type="numeric" class="form-control" value ="' + value.parcelHeight + '" disabled>' +

                            '</div>' +

                            '</div>' +

                            '</div > ';



                    }



                    row++;



                });



                var html = '<div class="align-left">' +

                    '<div class="row" > ' +

                    '<div class="col-md-6"> ' +

                    '<div class="card-hover-shadow-2x mb-3 card">' +

                    '<div class="card-header">Shipper Details</div>' +

                    '<div class="card-body">' +

                    '<div class="form-row">' +

                    '<div class="col-md-6">' +

                    '<div class="position-relative form-group">  ' +

                    '<div class="form-step-0" role="form" data-toggle="validator">' +

                    '<div class="form-group">' +

                    '<label for="businessNameCol">Business Name</label>' +

                    '<input name="businessNameCol" id="businessNameCol" placeholder="" ' +

                    'type="text" class="form-control" value ="' + obj.tbl_air_shipment_senderBusiness + '" required disabled>' +

                    '<div class="help-block with-errors"></div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '<div class="col-md-6">' +

                    '<div class="position-relative form-group">' +

                    '<div class="form-step-0" role="form" data-toggle="validator">' +

                    '<div class="form-group">' +

                    '<label for="firstNameCol">Shipper Name</label>' +

                    '<input name="firstNameCol" id="firstNameCol" placeholder="" ' +

                    'type="text" class="form-control" value ="' + obj.tbl_air_shipment_senderName + '" required disabled>' +

                    '<div class="help-block with-errors"></div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '<div class="form-row">' +

                    '<div class="col-md-6">' +

                    '<div class="position-relative form-group">' +

                    '<div class="form-step-0" role="form" data-toggle="validator">' +

                    '<div class="form-group">' +

                    '<label for="emailCol">Email</label>' +

                    '<input name="emailCol" id="emailCol" placeholder="" ' +

                    'type="email" class="form-control" value ="' + obj.tbl_air_shipment_senderEmail + '" required disabled>' +

                    '<div class="help-block with-errors"></div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '<div class="col-md-6">' +

                    '<div class="position-relative form-group">' +

                    '<div class="form-step-0" role="form" data-toggle="validator">' +

                    '<div class="form-group">' +

                    '<label for="telephoneCol">Telephone</label>' +

                    '<input name="telephoneCol" id="telephoneCol" placeholder="" ' +

                    'type="number" class="form-control" value ="' + obj.tbl_air_shipment_senderPhone + '"required disabled>' +

                    '<div class="help-block with-errors"></div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '<div class="form-row">' +

                    '<div class="col-md-12">' +

                    '<div class="position-relative form-group">' +

                    '<div class="form-step-0" role="form" data-toggle="validator">' +

                    '<div class="form-group">' +

                    '<label for="addressCol">Address</label>' +

                    '<input name="addressCol" id="addressCol" placeholder="" ' +

                    'type="text" class="form-control" value ="' + obj.tbl_air_shipment_senderAddress1 + ', ' + obj.tbl_air_shipment_senderCity + ' ' + obj.tbl_air_shipment_senderPostcode + ' ' + obj.tbl_air_shipment_senderState + '" required disabled>' +

                    '<div class="help-block with-errors"></div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '<div class="col-md-6">' +

                    '<div class="card-hover-shadow-2x mb-3 card">' +

                    '<div class="card-header">Receiver Details</div>' +

                    '<div class="card-body">' +

                    '<div class="form-row">' +

                    '<div class="col-md-6">' +

                    '<div class="position-relative form-group">  ' +

                    '<div class="form-step-0" role="form" data-toggle="validator">' +

                    '<div class="form-group">' +

                    '<label for="businessNameDel">Business Name</label>' +

                    '<input name="businessNameDel" id="businessNameDel" ' +

                    'placeholder="" ' +

                    'type="text" class="form-control" value ="' + obj.tbl_air_shipment_receiverBusiness + '" required disabled>' +

                    '<div class="help-block with-errors"></div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '<div class="col-md-6">' +

                    '<div class="position-relative form-group">' +

                    '<div class="form-step-0" role="form" data-toggle="validator">' +

                    '<div class="form-group">' +

                    '<label for="firstNameDel">Receiver Name</label>' +

                    '<input name="firstNameDel" id="firstNameDel" placeholder="" ' +

                    'type="text" class="form-control" value ="' + obj.tbl_air_shipment_receiverName + '" required disabled>' +

                    '<div class="help-block with-errors"></div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '<div class="form-row">' +

                    '<div class="col-md-6">' +

                    '<div class="position-relative form-group">' +

                    '<div class="form-step-0" role="form" data-toggle="validator">' +

                    '<div class="form-group">' +

                    '<label for="emailDel">Email</label>' +

                    '<input name="emailDel" id="emailDel" placeholder="" ' +

                    'type="email" class="form-control" value ="' + obj.tbl_air_shipment_receiverEmail + '" required disabled>' +

                    '<div class="help-block with-errors"></div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '<div class="col-md-6">' +

                    '<div class="position-relative form-group">' +

                    '<div class="form-step-0" role="form" data-toggle="validator">' +

                    '<div class="form-group">' +

                    '<label for="telephoneDel">Telephone</label>' +

                    '<input name="telephoneDel" id="telephoneDel" placeholder="" ' +

                    'type="number" class="form-control" value ="' + obj.tbl_air_shipment_receiverPhone + '" required disabled>' +

                    '<div class="help-block with-errors"></div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '<div class="form-row">' +

                    '<div class="col-md-12">' +

                    '<div class="position-relative form-group">' +

                    '<div class="form-step-0" role="form" data-toggle="validator">' +

                    '<div class="form-group">' +

                    '<label for="addressDel">Address</label>' +

                    '<input name="addressDel" id="addressDel" placeholder="" ' +

                    'type="text" class="form-control" value ="' + obj.tbl_air_shipment_receiverAddress1 + ', ' + obj.tbl_air_shipment_receiverCity + ' ' + obj.tbl_air_shipment_receiverPostcode + ' ' + obj.tbl_air_shipment_receiverState + '" required disabled>' +

                    '<div class="help-block with-errors"></div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '<div class="col-md-12"> ' +

                    '<div class="card-hover-shadow-2x mb-3 card">' +

                    '<div class="card-body">' +

                    '<div class="row"> ' +

                    '<div class="col-md-6">' +

                    '<ul class="list-group">' +

                    '<li class="list-group-item">' +

                    '<div class="widget-content p-0">' +

                    '<div class="widget-content-wrapper">' +

                    '<div class="widget-content-left">' +

                    '<div class="widget-heading">Carrier Name</div>' +

                    '<div class="widget-subheading carrier_name">' + obj.tbl_air_shipment_airlineCode + '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</li>' +

                    '<li class="list-group-item">' +

                    '<div class="widget-content p-0">' +

                    '<div class="widget-content-wrapper">' +

                    '<div class="widget-content-left">' +

                    '<div class="widget-heading">Carrier Service</div>' +

                    '<div class="widget-subheading carrier_service">' + obj.tbl_air_shipment_service + '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</li>' +

                    '<li class="list-group-item">' +

                    '<div class="widget-content p-0">' +

                    '<div class="widget-content-wrapper">' +

                    '<div class="widget-content-left">' +

                    '<div class="widget-heading">Reference Number</div>' +

                    '<div class="widget-subheading carrier_tracking">' + obj.tbl_air_shipment_senderRef + '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</li>' +

                    '<li class="list-group-item">' +

                    '<div class="widget-content p-0">' +

                    '<div class="widget-content-wrapper">' +

                    '<div class="widget-content-left">' +

                    '<div class="widget-heading">HAWB</div>' +

                    '<div class="widget-subheading shipper_reference">' + obj.tbl_air_shipment_hawb + '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</li>' +

                    '<li class="list-group-item">' +

                    '<div class="widget-content p-0">' +

                    '<div class="widget-content-wrapper">' +

                    '<div class="widget-content-left">' +

                    '<div class="widget-heading">Special Instructions</div>' +

                    '<div class="widget-subheading special_instructions">' + obj.tbl_air_shipment_notes + '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</li>' +

                    '</ul>' +

                    '</div>' +

                    '<div class="col-md-6">' +

                    '<ul class="list-group">' +

                    '<li class="list-group-item">' +

                    '<div class="widget-content p-0">' +

                    '<div class="widget-content-wrapper">' +

                    '<div class="widget-content-left">' +

                    '<div class="widget-heading">Collection/Delivery Dates</div>' +

                    '<div class="widget-subheading special_dates">Creation Date:' + obj.tbl_air_shipment_timestamp + ' Delivery Date: ' + obj.tbl_air_shipment_deliverydate + '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</li>' +

                    '<li class="list-group-item">' +

                    '<div class="widget-content p-0">' +

                    '<div class="widget-content-wrapper">' +

                    '<div class="widget-content-left">' +

                    '<div class="widget-heading">Tail Lift Origin/Destination</div>' +

                    '<div class="widget-subheading tail_lift">Tail Lift Origin:' + obj.tbl_air_shipment_tailLiftO + ' Tail Lift Destination: ' + obj.tbl_air_shipment_tailLiftD + '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</li>' +

                    '<li class="list-group-item">' +

                    '<div class="widget-content p-0">' +

                    '<div class="widget-content-wrapper">' +

                    '<div class="widget-content-left">' +

                    '<div class="widget-heading">Dangerous Goods</div>' +

                    '<div class="widget-subheading dangerous_goods">' + dgInd + '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</li>' +

                    '<li class="list-group-item">' +

                    '<div class="widget-content p-0">' +

                    '<div class="widget-content-wrapper">' +

                    '<div class="widget-content-left">' +

                    '<div class="widget-heading">Shipment Value</div>' +

                    '<div class="widget-subheading goods_value">' + obj.tbl_air_shipment_value + '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</li>' +

                    '<li class="list-group-item">' +

                    '<div class="widget-content p-0">' +

                    '<div class="widget-content-wrapper">' +

                    '<div class="widget-content-left">' +

                    '<div class="widget-heading">Goods Description</div>' +

                    '<div class="widget-subheading description_goods">' + obj.tbl_air_shipment_description + '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</li>' +

                    '</ul>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div >' +

                    '<div class="row"> ' +

                    '<div class="col-md-12"> ' +

                    '<div class="card-hover-shadow-2x mb-3 card">' +

                    '<div class="card-header">Item Details</div>' +

                    '<div class="card-body row_items">' +

                    '+items+' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div>' +

                    '</div >' +

                    '</div > ';



                Swal.fire({

                    title: "View Air Shipment",

                    html: html,

                    showClass: {

                        popup: 'animated fadeInDown faster',

                        icon: 'animated heartBeat delay-1s'

                    },

                    showConfirmButton: false,

                    hideClass: {

                        popup: 'animated fadeOutUp faster',

                    },

                    customClass: "viewjob",

                });







            }//end success

        });

    },

    columns: [                 //define the table columns

        { title: "MAWB", field: "mawb" },

        { title: "HAWB", field: "hawb" },

        { title: "AIRLINE CARRIER", field: "airline" },

        { title: "ETD", field: "etd" },

        { title: "ETA", field: "eta" },

        { title: "INCOTERMS", field: "incoterms" },

        { title: "Delivery Company", field: "receiverBusiness" }



    ]
});



$("#searchAirShipments").click(function () {



    var fromDate = $("#dateFrom").val();

    var toDate = $("#dateTo").val();

    var shipID = $("#shipperName").val();

    var airLine = $("#airLine").val();

    var mawb = $("#mawb").val();

    var hawb = $("#hawb").val();



    $.ajax({

        type: 'POST',

        url: '', //'/<?php echo $_SESSION['subdir']; ?>/ajax/get-air-shipments.php',

        data: {

            fromDate: fromDate,

            toDate: toDate,

            shipID: shipID,

            airLine: airLine,

            mawb: mawb,

            hawb: hawb

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



            table.replaceData(data); //load data array



        }//end success

    });



});