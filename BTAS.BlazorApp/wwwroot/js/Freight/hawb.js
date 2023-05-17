


// with plugin options

$("#input-id").fileinput(

    {

        'uploadUrl': '/',

        'previewFileType': 'any',

        'overwriteInitial': false,

        'initialPreviewAsData': true,

        'allowedFileExtensions': ['png', 'jpeg', 'csv', 'pdf', 'xlsx', 'xls', 'doc', 'txt', 'jpg'],

        'maxFileSize': 10000

    });


$.fn.pressEnter = function (fn) {

    return this.each(function () {

        $(this).bind('enterPress', fn);

        $(this).keyup(function (e) {

            if (e.keyCode == 13) {

                $(this).trigger("enterPress");

            }

        })

    });

};



$("#finish-btn").hide();



//use it:

$('#scan').pressEnter(function (e) {
    e.preventDefault();
    ScanReceptacle();

})



//Array of input fields ID.

var gacFields = ["route"];



var componentForm = {

    subpremise: 'short_name',

    street_number: 'short_name',

    route: 'long_name',

    locality: 'long_name',

    administrative_area_level_1: 'short_name',

    country: 'short_name',

    postal_code: 'short_name'

};



$.each(gacFields, function (key, field) {

    var input = document.getElementById(field);

    console.log(input);

    //varify the field

    if (input != null) {



        var options = {

            types: ['address']

        };







        var autocomplete = new google.maps.places.Autocomplete(input, options);



        google.maps.event.addListener(autocomplete, 'place_changed', function (e) {





            var place = autocomplete.getPlace();



            if (!place.geometry) {

                return;

            }



            for (var component in componentForm) {

                document.getElementById(component).value = '';

                document.getElementById(component).disabled = false;

            }



            // Get each component of the address from the place details,

            // and then fill-in the corresponding field on the form.

            for (var i = 0; i < place.address_components.length; i++) {

                var addressType = place.address_components[i].types[0];

                if (componentForm[addressType]) {

                    var val = place.address_components[i][componentForm[addressType]];

                    document.getElementById(addressType).value = val;

                }

            }

        });

    }

});



var gacFields2 = ["routedel"];



var componentForm2 = {

    subpremisedel: 'short_name',

    street_numberdel: 'short_name',

    routedel: 'long_name',

    localitydel: 'long_name',

    administrative_area_level_1del: 'short_name',

    countrydel: 'short_name',

    postal_codedel: 'short_name'

};





$.each(gacFields2, function (key, field) {

    var input = document.getElementById(field);

    console.log(input);

    //varify the field

    if (input != null) {



        var options = {

            types: ['address'],

            componentRestrictions: ({ 'country': ['au', 'nz'] })

        };







        var autocomplete = new google.maps.places.Autocomplete(input, options);



        google.maps.event.addListener(autocomplete, 'place_changed', function (e) {





            var place = autocomplete.getPlace();



            if (!place.geometry) {

                return;

            }



            for (var component in componentForm2) {

                document.getElementById(component).value = '';

                document.getElementById(component).disabled = false;

            }



            // Get each component of the address from the place details,

            // and then fill-in the corresponding field on the form.

            for (var i = 0; i < place.address_components.length; i++) {

                var addressType = place.address_components[i].types[0];

                if (componentForm2[addressType + 'del']) {

                    var val = place.address_components[i][componentForm2[addressType + 'del']];

                    document.getElementById(addressType + 'del').value = val;

                }

            }

        });

    }

});







// Toolbar extra buttons

var btnFinish = $("#finish-btn").on('click', function (e) {



    CarrierVal = $('#carrierName').find(":selected").val();

    ServicesVal = $('#carrierService').find(":selected").val();

    AccountVal = $('#carrierAccount').find(":selected").val();



    if (CarrierVal == 'false' || ServicesVal == 'false' || AccountVal == 'false') {



        Swal.fire({

            title: 'There is an Error!',

            html: 'Error: No Carrier/Service/Account selected.',

            icon: 'error',

            showDenyButton: false,

            showCancelButton: false,

            confirmButtonText: `Fix Error`,

        })



        return false;

    }



    e.preventDefault();

    if (!$(this).hasClass('disabled')) {

        var elmForm = $("#create-shipment");

        if (elmForm) {

            elmForm.validator('validate');

            var elmErr = elmForm.find('.has-error');

            if (elmErr && elmErr.length > 0) {

                return false;

            } else {



                Swal.fire({

                    title: 'Creating shipment!',

                    html: 'Please wait..',

                    timer: 10000,

                    timerProgressBar: true,

                    allowOutsideClick: false,

                    showConfirmButton: false

                })



                var myform = document.getElementById("create-shipment");



                var fd = new FormData(myform);

                $.ajax({

                    url: '~/CreateEditShipment',

                    data: fd,

                    processData: false,

                    contentType: false,

                    type: 'POST',

                    success: function (dataresult) {



                        var obj = JSON.parse(dataresult);

                        console.log(obj);



                        if (obj.carrier == 'TNTEXPDOM') {



                            error = false;





                            if (obj.response.message[0].response.status == 'Error') {



                                error = true;

                                errorMessage = obj.response.message[0].response.message;



                            } else {



                                var label = obj.response.message[0].response.message.aConsignmentActionList.banyType.aLabelPDF;

                                var consignment = obj.response.message[0].response.message.aConsignmentNumber;



                            }



                        }



                        if (obj.carrier == 'HUNTEXPAIR') {



                            error = false;



                            if (typeof obj.response.message[0].response.errorCode === "undefined") {



                                var label = obj.response.message[0].response.shippingLabel;

                                var consignment = obj.response.message[0].response.trackingNumber;



                            } else {



                                error = true;

                                errorMessage = obj.response.message[0].response.errorMessage;



                            }



                        }



                        if (obj.carrier == 'HUNTEXPSEA') {



                            error = false;





                            if (obj.response.message[0].error.success == false) {



                                error = true;

                                errorMessage = obj.response.message[0].error.responseDescription;



                            } else {



                                var label = '';

                                var consignment = obj.response.message[0].tracking_ref;





                            }







                        }



                        if (obj.carrier == 'BORDEXPPAR') {



                            error = false;





                            if (obj.response.message[0].response.success == false) {



                                error = true;

                                errors = obj.response.message[0].response.errors;



                                $.each(errors, function (idx, value) {



                                    errorMessage = value;



                                })





                            } else {



                                var label = obj.response.message[0].response.labelBase;

                                var consignment = obj.response.message[0].response.ConsignmentNumber;



                            }



                        }



                        if (obj.carrier == 'BORDEXPBUL') {



                            error = false;





                            if (obj.response.message[0].response.success == false) {



                                error = true;

                                errors = obj.response.message[0].response.errors;



                                $.each(errors, function (idx, value) {



                                    errorMessage = value;



                                })





                            } else {



                                var label = obj.response.message[0].response.labelBase;

                                var consignment = obj.response.message[0].response.ConsignmentNumber;



                            }



                        }







                        if (error == true) {



                            Swal.fire({

                                title: 'There is an Error!',

                                html: 'Error: ' + errorMessage,

                                icon: 'error',

                                showDenyButton: false,

                                showCancelButton: false,

                                confirmButtonText: `Fix Error`,

                            }).then((result) => {

                                /* Read more about isConfirmed, isDenied below */

                                if (result.isConfirmed) {



                                }

                            })





                        } else {



                            Swal.fire({

                                title: 'Shipment Created ' + consignment,

                                html: 'Download Label: <a href="data:application/pdf;base64,' + label + '" download="label.pdf"><i class="fas fa-barcode success"></i></a>',

                                icon: 'success',

                                showDenyButton: true,

                                showCancelButton: false,

                                confirmButtonText: `Search Shipment`,

                                denyButtonText: `Close`,

                            }).then((result) => {

                                /* Read more about isConfirmed, isDenied below */

                                if (result.isConfirmed) {



                                    window.location.href = "1-search.php";



                                } else if (result.isDenied) {

                                    $('#create-shipment').trigger("reset");

                                    $("#smartwizard").smartWizard("reset");

                                }

                            })



                        }



                    },

                    error: function (XMLHttpRequest, textStatus, errorThrown) {

                        alert(errorThrown);

                    },

                });



                return false;

            }

        }

    }

});



$("#smartwizard").smartWizard({

    selected: 0, // Initial selected step, 0 = first step

    theme: 'default', // theme for the wizard, related css need to include for other than default theme

    justified: true, // Nav menu justification. true/false

    darkMode: false, // Enable/disable Dark Mode if the theme supports. true/false

    autoAdjustHeight: true, // Automatically adjust content height

    cycleSteps: false, // Allows to cycle the navigation of steps

    backButtonSupport: true, // Enable the back button support

    enableURLhash: false, // Enable selection of the step based on url hash

    transition: {

        animation: 'fade', // Effect on navigation, none/fade/slide-horizontal/slide-vertical/slide-swing

        speed: '400', // Transion animation speed

        easing: '' // Transition animation easing. Not supported without a jQuery easing plugin

    },

    toolbarSettings: {

        toolbarPosition: "none",

        toolbarExtraButtons: [btnFinish]

    },

    anchorSettings: {

        anchorClickable: false, // Enable/Disable anchor navigation

        enableAllAnchors: false, // Activates all anchors clickable all times

        markDoneStep: true, // Add done state on navigation

        markAllPreviousStepsAsDone: true, // When a step selected by url hash, all previous steps are marked done

        removeDoneStepOnNavigateBack: false, // While navigate back done step after active step will be cleared

        enableAnchorOnDoneStep: true // Enable/Disable the done steps navigation

    },

    keyboardSettings: {

        keyNavigation: false, // Enable/Disable keyboard navigation(left and right keys are used if enabled)

    }

});



// External Button Events

$("#prev-btn").on("click", function () {

    // Navigate previous

    $("#smartwizard").smartWizard("prev");

    return true;

});



$("#next-btn").on("click", function () {

    // Navigate next

    $("#smartwizard").smartWizard("next");

    return true;

});



$("#smartwizard").on("showStep", function (e, anchorObject, stepNumber, stepDirection) {

    // Enable finish button only on last step

    if (stepNumber == 4) {

        $("#finish-btn").show();

        $("#next-btn").hide();

    } else {

        $("#finish-btn").hide();

        $("#next-btn").show();

    }

});



$("#smartwizard").on("leaveStep", function (e, anchorObject, stepNumber, stepDirection) {

    var elmForm = $(".form-step-" + stepNumber);

    // stepDirection === 'forward' :- this condition allows to do the form validation

    // only on forward navigation, that makes easy navigation on backwards still do the validation when going next

    if (stepDirection === 'forward' && elmForm) {

        elmForm.validator('validate');

        var elmErr = elmForm.children('.has-error');

        if (elmErr && elmErr.length > 0) {

            // Form validation failed

            return false;

        }



        if (stepNumber == 2) {



            var data = table.getData();



            $.each(data, function (idx, value) {



                var inputName = "input[name='item[" + value.id + "][itemRef]']";



                var inputValue = $(inputName).val();



                if (inputValue == undefined) {



                    $(".items").append('<div class="form-row item-row rep' + value.id + '"> ' +

                        '<div class= "col-md-2">' +
                        '<div class="position-relative form-group">' +

                        '<select name="itemType" id="itemType" class="form-control" required="" disabled>' +

                        '<option selected>' + value.type + '</option>' +

                        '</select>' +

                        '<div class="help-block with-errors"></div>' +

                        '</div>' +

                        '</div >' +

                        '<div class="col-md-1">' +

                        '<div class="position-relative form-group">' +

                        '<input name="item[' + value.id + '][itemQty]" id="itemqty" placeholder="" type="numeric" class="form-control" value=1 disabled>' +

                        '</div>' +

                        '</div>' +

                        '<div class="col-md-3">' +

                        '<div class="position-relative form-group">' +

                        '<input name="item[' + value.id + '][itemRef]" id="yourRef" placeholder="" type="text" class="form-control" value="' + value.id + '" disabled>' +

                        '</div>' +

                        '</div>' +

                        '<div class="col-md-1">' +

                        '<div class="position-relative form-group">' +

                        '<input name="item[' + value.id + '][itemWeight]" id="itemWeight" placeholder="" type="numeric" class="form-control" value="' + value.weight + '" disabled>' +

                        '</div>' +

                        '</div>' +

                        '<div class="col-md-1">' +

                        '<div class="position-relative form-group">' +

                        '<input name="item[' + value.id + '][itemLength]" id="itemLength" placeholder="" type="numeric" class="form-control" value="' + value.length + '" disabled>' +

                        '</div>' +

                        '</div>' +

                        '<div class="col-md-1">' +

                        '<div class="position-relative form-group">' +

                        '<input name="item[' + value.id + '][itemWidth]" id="itemWidth" placeholder="" type="numeric" class="form-control" value="' + value.width + '" disabled>' +

                        '</div>' +

                        '</div>' +

                        '<div class="col-md-1">' +

                        '<div class="position-relative form-group">' +

                        '<input name="item[' + value.id + '][itemHeight]" id="itemHeight" placeholder="" type="numeric" class="form-control" value="' + value.height + '" disabled>' +

                        '</div>' +

                        '</div>' +

                        '</div > ');



                }





            })





        }

    }

    return true;

});





itemnumber = 1;



$(".removebutton").click(function () {

    $(this).closest(".item-row").remove();



});



$(".addbutton").click(function (e) {



    e.preventDefault();



    $(".items").append('<div class="form-row item-row">' +

        '<div class= "col-md-2" >' +

        '<div class="position-relative form-group">' +

        '<select name="itemType" id="itemType" class="form-control" required="">' +

        '<option value="false" selected>--Select--</option>' +

        '<option value="Box">Box</option>' +

        '<option value="Pallet">Pallet</option>' +

        '</select>' +

        '<div class="help-block with-errors"></div>' +

        '</div>' +

        '</div >' +

        '<div class="col-md-1">' +

        '<div class="position-relative form-group">' +

        '<input name="item[' + itemnumber + '][itemQty]" id="itemqty" placeholder="" type="numeric" class="form-control">' +

        '</div>' +

        '</div>' +

        '<div class="col-md-3">' +

        '<div class="position-relative form-group">' +

        '<input name="item[' + itemnumber + '][itemRef]" id="yourRef" placeholder="" type="text" class="form-control">' +

        '</div>' +

        '</div>' +

        '<div class="col-md-1">' +

        '<div class="position-relative form-group">' +

        '<input name="item[' + itemnumber + '][itemWeight]" id="itemWeight" placeholder="" type="numeric" class="form-control">' +

        '</div>' +

        '</div>' +

        '<div class="col-md-1">' +

        '<div class="position-relative form-group">' +

        '<input name="item[' + itemnumber + '][itemLength]" id="itemLenght" placeholder="" type="numeric" class="form-control">' +

        '</div>' +

        '</div>' +

        '<div class="col-md-1">' +

        '<div class="position-relative form-group">' +

        '<input name="item[' + itemnumber + '][itemWidth]" id="itemWidth" placeholder="" type="numeric" class="form-control">' +

        '</div>' +

        '</div>' +

        '<div class="col-md-1">' +

        '<div class="position-relative form-group">' +

        '<input name="item[' + itemnumber + '][itemHeight]" id="itemHeight" placeholder="" type="numeric" class="form-control">' +

        '</div>' +

        '</div>' +

        '<div class="col-md-1">' +

        '<button class="mr-2 btn-icon btn-icon-only btn btn-warning removebutton">' +

        '<i class="pe-7s-trash btn-icon-wrapper"></i>' +

        '</button>' +

        '</div>' +

        '</div > ');

    itemnumber++;



    $(".removebutton").click(function () {

        $(this).closest(".item-row").remove();



    });

});



var deleteShipment = function (cell, formatterParams, onRendered) {
    return '<a id="deleteShipment" href=""><i class="fas fa-trash-alt"></i>';
}



var table = new Tabulator("#tblReceptacle", {
    layout: "fitColumns",      //fit columns to width of table

    responsiveLayout: "hide",  //hide columns that dont fit on the table

    tooltips: true,

    placeholder: "Scan Shipments",

    addRowPos: "top",          //when adding a new row, add it to the top of the table

    history: true,             //allow undo and redo actions on the table

    pagination: "local",       //paginate the data

    paginationSize: 10,         //allow 7 rows per page of data

    movableColumns: true,      //allow column order to be changed

    resizableRows: true,       //allow row order to be changed

    columns: [                 //define the table columns

        { title: "Receptacle Id", headerFilter: "input", field: "idtbl_receptacle" },

        { title: "Reference", headerFilter: "input", field: "tbl_receptacle_ref" },

        { title: "Origin", headerFilter: "input", field: "tbl_receptacle_origin" },

        { title: "Destination", headerFilter: "input", field: "tbl_receptacle_dest" },

        { title: "Type", headerFilter: "input", field: "tbl_receptacle_type" },

        { title: "Items", headerFilter: "input", field: "tbl_receptacle_no_items" },

        { title: "Weight", headerFilter: "input", field: "tbl_receptacle_weight" },

        {
            title: "Delete", formatter: deleteShipment, align: "center", width: 50, headerSort: false, cellClick: function (e, cell) {



                e.preventDefault();

                cell.getRow().delete();



                var ID = cell.getData().id

                var removeId = '.rep' + ID;



                $(removeId).remove();



            }
        },



    ]
});

//$("#hawbForm").on("submit", function (e) {
//    alert("here");
//    e.preventDefault();
//    return false;
//});

//$("#btnReceptacleScan").on("click", function (e) {
//    alert("here");
//    e.preventDefault();
//    ScanReceptacle();
//})

function ScanReceptacle() {
    Swal.fire({

        title: 'Getting Receptacle..',

        html: 'Please bear with us',

        timer: 10000,

        timerProgressBar: true,

        showConfirmButton: false

    })


    var tracking = $('#scan').val();



    if (tracking.match(".*\\d.*")) {

        // The string has a number, do whatever logic you need here.



        var recId = tracking.match(/[\d\.]+/g);

        if (recId != null) {

            var recId = recId.toString();

        }



        $.ajax({

            type: 'GET',
            dataType: "json",
            url: '/Freight/GetReceptacle/',

            data: {

                receptacleRef: recId

            },

            error: function (XMLHttpRequest, textStatus, errorThrown) {

                //swal({title:textStatus,text: errorThrown,icon: "error",button: "Close"});

            },

            success: function (dataresult) {



                if (dataresult == 'error') {



                    swal.fire({

                        title: 'Receptacle does not exist!',

                        text: 'Please try another receptacle.',

                        icon: "error",

                        button: "Close",

                    });



                    var tracking = $('#scan').val('');



                } else {



                    var obj = jQuery.parseJSON(dataresult);



                    if (obj.receptacle.status == 'closed') {



                        var tracking = $('#scan').val();



                        data = { id: obj.receptacle.id, reference: obj.receptacle.reference, origin: obj.receptacle.origin, destination: obj.receptacle.destination, type: obj.receptacle.type, items: obj.receptacle.shipmentCount, weight: obj.receptacle.weight, length: obj.receptacle.length, width: obj.receptacle.width, height: obj.receptacle.height };



                        table.setData([data]);



                        swal.close()



                        var tracking = $('#scan').val('');



                    } else {



                        swal.fire({

                            title: 'Receptacle still open',

                            text: 'Only closed receptacles can be added to a shipment.',

                            icon: "error",

                            button: "Close",

                        });



                        var tracking = $('#scan').val('');



                    }



                }





            }//end success

        });



    }

    else {



        swal.fire({

            title: 'Receptacle does not exist!',

            text: 'Please try another receptacle.',

            icon: "error",

            button: "Close",

        });



        var tracking = $('#scan').val('');



    }
}