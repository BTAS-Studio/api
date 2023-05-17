$('.scan-row').hide();

var tableData

$(document).ready(() => {



    $.blockUI.defaults = {

        timeout: 1500,

        fadeIn: 200,

        fadeOut: 400,

    };

    $(".card-details-receptacle").block({

        message: $(

            '<div class="loader mx-auto">\n' +

            '<div class="ball-grid-pulse">\n' +

            '<div class="bg-white"></div>\n' +

            '<div class="bg-white"></div>\n' +

            '<div class="bg-white"></div>\n' +

            '<div class="bg-white"></div>\n' +

            '<div class="bg-white"></div>\n' +

            '<div class="bg-white"></div>\n' +

            '<div class="bg-white"></div>\n' +

            '<div class="bg-white"></div>\n' +

            '<div class="bg-white"></div>\n' +

            "</div>\n" +

            "</div>"

        ),

    });



    $(".card-details").block({

        message: $(

            '<div class="loader mx-auto">\n' +

            '<div class="ball-grid-pulse">\n' +

            '<div class="bg-white"></div>\n' +

            '<div class="bg-white"></div>\n' +

            '<div class="bg-white"></div>\n' +

            '<div class="bg-white"></div>\n' +

            '<div class="bg-white"></div>\n' +

            '<div class="bg-white"></div>\n' +

            '<div class="bg-white"></div>\n' +

            '<div class="bg-white"></div>\n' +

            '<div class="bg-white"></div>\n' +

            "</div>\n" +

            "</div>"

        ),

    });

});

//$.ajax({

//    type: 'POST',

//    url: '/Receptacle/Details',

//    data: {

//        receptacleId: $("#receptacleId").innerHtml()

//    },

//    error: function (XMLHttpRequest, textStatus, errorThrown) {

//        // swal({title:textStatus,text: errorThrown,icon: "error",button: "Close"});

//    },

//    success: function (dataresult) {



//        var obj = jQuery.parseJSON(dataresult);



//        $('#reference').val(obj.receptacle.reference);

//        $('#origin').val(obj.receptacle.origin);

//        $('#destination').val(obj.receptacle.destination);

//        $('#mode').val(obj.receptacle.mode);

//        $('#type').val(obj.receptacle.type);

//        $('#weight').val(obj.receptacle.weight);

//        $('#length').val(obj.receptacle.length);

//        $('#width').val(obj.receptacle.width);

//        $('#height').val(obj.receptacle.height);

//        $('#itemsNo').val(obj.receptacle.shipmentCount);



//        if (obj.receptacle.status == 'closed') {



//            $(".receptacle-info").prop('disabled', true);

//            $(".dim-info").prop('disabled', true);

//            $("#uploadBtn").remove();

//            $('.scan-row').show();

//            $("#scan").prop('disabled', true);

//            $(".saveShipmentsReceptacle").remove();





//        }





//        var table = new Tabulator("#example-table", {



//            layout: "fitColumns",      //fit columns to width of table

//            responsiveLayout: "hide",  //hide columns that dont fit on the table

//            tooltips: true,

//            placeholder: "Scan Shipments",

//            addRowPos: "top",          //when adding a new row, add it to the top of the table

//            history: true,             //allow undo and redo actions on the table

//            pagination: "local",       //paginate the data

//            paginationSize: 10,         //allow 7 rows per page of data

//            movableColumns: true,      //allow column order to be changed

//            resizableRows: true,       //allow row order to be changed

//            columns: [                //define the table columns

//                { title: "", headerFilter: "input", field: "apiID", visible: false },

//                { title: "Item Id", headerFilter: "input", field: "id" },

//                { title: "Shipment Id", headerFilter: "input", field: "shipmentId" },

//                { title: "Tracking Id", headerFilter: "input", field: "tracking" },

//                { title: "Shipper", headerFilter: "input", field: "shipper" },

//                { title: "Reference", headerFilter: "input", field: "reference" },

//                { title: "Service Code", headerFilter: "input", field: "service" }

//            ]
//        });



//        table.setData(obj.shipments);



//        tableData = obj.shipments;



//        $(".excel-download").click(function (e) {



//            table.download("xlsx", "Receptacle Manifest.xlsx", { sheetName: "Shipment data" }); //download a Xlsx file that has a sheet name of "MyData"



//        });



//        $(".label-downloads").click(function (e) {



//            var reference = $('#reference').val();

//            var origin = $('#origin').val();

//            var destination = $('#destination').val();

//            var mode = $('#mode').val();

//            var type = $('#type').val();

//            var weight = $('#weight').val();

//            var length = $('#length').val();

//            var width = $('#width').val();

//            var height = $('#height').val();

//            var receptacleFull = $('#receptacleId').text();





//            $.ajax({

//                type: 'POST',

//                url: '/Receptacle/CreateLabel',

//                data: {

//                    reference: reference,

//                    receptacleId: receptacleFull,

//                    barcode: '<?php echo $recId; ?>',

//                    origin: origin,

//                    destination: destination,

//                    mode: mode,

//                    type: type,

//                    weight: weight,

//                    length: length,

//                    height: height,

//                    width: width

//                },

//                error: function (XMLHttpRequest, textStatus, errorThrown) {

//                    // swal({title:textStatus,text: errorThrown,icon: "error",button: "Close"});

//                },

//                success: function (data) {



//                    var obj = JSON.parse(data);



//                    function downloadPDF(pdf, name) {

//                        const linkSource = `data:application/pdf;base64,${pdf}`;

//                        const downloadLink = document.createElement("a");

//                        const fileName = name + ".pdf";



//                        downloadLink.href = linkSource;

//                        downloadLink.download = fileName;

//                        downloadLink.click();

//                    }



//                    downloadPDF(obj.receptacleBase, obj.receptacleRef);



//                }//end success

//            });





//        });



//    }//end success

//});



$(".saveDetails").click(function (e) {



    e.preventDefault(e);



    $('.with-errors-receptacle').html('<div class="help-block with-errors-receptacle"></div>');



    var reference = $('#reference').val();

    var origin = $('#origin').val();

    var destination = $('#destination').val();

    var mode = $('#mode').val();

    var type = $('#type').val();



    var fieldArray = { 'reference': reference, 'origin': origin, 'destination': destination, 'mode': mode, 'type': type };



    error = false;



    $.each(fieldArray, function (index, value) {



        if (value == '' || value == null) {

            error = true;

        }



    });



    if (error == true) {



        $('.with-errors-receptacle').html('<div class="help-block with-errors-receptacle">*</div>');



        end();



    }



    var deleteShipment = function (cell, formatterParams, onRendered) {



        return '<a id="deleteShipment" href=""><i class="fas fa-trash-alt"></i>';

    }



    $(".receptacle-info").prop('disabled', true);



    var table = new Tabulator("#example-table", {



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

            { title: "", headerFilter: "input", field: "apiID", visible: false },

            { title: "Item Id", headerFilter: "input", field: "id" },

            { title: "Shipment Id", headerFilter: "input", field: "shipmentId" },

            { title: "Tracking Id", headerFilter: "input", field: "tracking" },

            { title: "Shipper", headerFilter: "input", field: "shipper" },

            { title: "Reference", headerFilter: "input", field: "reference" },

            { title: "Service Code", headerFilter: "input", field: "service" },

            {
                title: "Delete", formatter: deleteShipment, align: "center", width: 50, headerSort: false, cellClick: function (e, cell) {



                    e.preventDefault();

                    cell.getRow().delete();

                    $('#itemsNo').get(0).value--;



                }
            },

        ]
    });



    table.setData(tableData);



    Swal.fire({

        title: 'Saving Details..',

        html: 'Please bear with us',

        timer: 10000,

        timerProgressBar: true,

        showConfirmButton: false

    })





    $.ajax({

        type: 'POST',

        url: '/Receptacle/Shipments',

        data: { function: 'edit' },

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



            console.log(obj);

            swal.close()

            $('.scan-row').show();

            $('.cancelLine').remove();

            $('.saveDetails').remove();



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



            var scanArr = [];



            $.each(tableData, function (index, value) {



                scanArr.push(value.id);



            });





            //use it:

            $('#scan').pressEnter(function (e) {



                e.preventDefault();



                var tracking = $('#scan').val();



                var tracking = tracking.substring(10);



                error = true;



                $.each(obj, function (i, objs) {



                    if (objs.trackingNumber == tracking) {



                        console.log(scanArr);



                        if (jQuery.inArray(objs.id, scanArr) >= 0) {



                            alert('Already Scanned');

                            error = false;



                        } else {



                            $('#scan').css("background-color", "#67a75b78");



                            setTimeout(function () {

                                $('#scan').css("background-color", "UNSET");

                            }, 100);



                            $('#itemsNo').get(0).value++;



                            error = false;



                            table.updateOrAddData([{ id: objs.id, shipmentId: objs.shipmentId, tracking: objs.trackingNumber, shipper: objs.shipperID, reference: objs.reference, service: objs.servicesName }])

                            scanArr.push(objs.id);



                            obj.splice(i, 1);



                            return false;



                        }



                    }



                });



                if (error == true) {



                    alert('Does not exist!');



                }



                $('#scan').val('');

            })





        }//end success



    });



    $(".excel-download").click(function (e) {



        table.download("xlsx", "Receptacle Manifest.xlsx", { sheetName: "Shipment data" }); //download a Xlsx file that has a sheet name of "MyData"



    });



    $(".label-downloads").click(function (e) {



        alert('clicked');



        $.ajax({

            type: 'POST',

            url: '/Receptacle/CreateLabel',

            data: {

                tableData: tableData,

                reference: reference,

                receptacleId: '<?php echo $recId; ?>',

                origin: origin,

                destination: destination,

                mode: mode,

                buttonFunc: buttonvalue,

                type: type,

                weight: weight,

                length: length,

                height: height,

                width: width

            },

            error: function (XMLHttpRequest, textStatus, errorThrown) {

                // swal({title:textStatus,text: errorThrown,icon: "error",button: "Close"});

            },

            success: function (dataresult) {



                var obj = JSON.parse(data);



                function downloadPDF(pdf, name) {

                    const linkSource = `data:application/pdf;base64,${pdf}`;

                    const downloadLink = document.createElement("a");

                    const fileName = name + ".pdf";



                    downloadLink.href = linkSource;

                    downloadLink.download = fileName;

                    downloadLink.click();

                }



                downloadPDF(obj.receptacleBase, obj.receptacleRef);



            }//end success

        });





    });





    $(".saveShipmentsReceptacle").click(function (e) {



        var buttonvalue = $(this).val();



        Swal.fire({

            title: 'Saving Details..',

            html: 'Please bear with us',

            timer: 10000,

            timerProgressBar: true,

            showConfirmButton: false

        })



        e.preventDefault();



        $('.with-errors-dims').html('<div class="help-block with-errors-dims"></div>');



        var tableData = table.getData();

        var reference = $('#reference').val();

        var origin = $('#origin').val();

        var destination = $('#destination').val();

        var mode = $('#mode').val();

        var type = $('#type').val();

        var weight = $('#weight').val();

        var length = $('#length').val();

        var width = $('#width').val();

        var height = $('#height').val();



        var fieldArray = { 'length': length, 'width': width, 'height': height, 'weight': weight };



        error = false;



        $.each(fieldArray, function (index, value) {



            if (value == '' || value == null) {

                error = true;

            }



        });



        if (error == true) {



            $('.with-errors-dims').html('<div class="help-block with-errors-dims">*</div>');



            end();



        }



        $.ajax({

            type: 'POST',

            url: '/Receptacle/Update',

            data: {

                function: 'updateAndLink',

                tableData: tableData,

                reference: reference,

                receptacleId: '<?php echo $recId; ?>',

                origin: origin,

                destination: destination,

                mode: mode,

                buttonFunc: buttonvalue,

                type: type,

                weight: weight,

                length: length,

                height: height,

                width: width

            },

            error: function (XMLHttpRequest, textStatus, errorThrown) {

                // swal({title:textStatus,text: errorThrown,icon: "error",button: "Close"});

            },

            success: function (dataresult) {



                $(location).attr('href', '/Receptacle/List');



            }//end success

        });



    });







});
