$(document).ready(function () {
    try {

        var gacFields = document.getElementById("addressSearch");

        var componentForm = {

            subpremise: 'short_name',

            street_number: 'short_name',

            route: 'long_name',

            locality: 'long_name',

            administrative_area_level_1: 'short_name',

            country: 'short_name',

            postal_code: 'short_name'

        };


        var options = {

            types: ['address']
        }


        var autocomplete = new google.maps.places.Autocomplete(gacFields, options);

        google.maps.event.addListener(autocomplete, 'place_changed', function (e) {

            var place = autocomplete.getPlace();

            if (!place.geometry) {

                return;

            }

            for (const component of place.address_components) {
                const componentType = component.types[0];
                
                switch (componentType) {
                    case "street_number": {
                        $("#street_number").val(component.short_name);
                        break;
                    }

                    case "route": {
                        $("#tbl_client_header_address1").val(component.short_name);
                        break;
                    }
                    case "sublocality_level_1": {
                        $("#tbl_client_header_address2").val(component.short_name);
                        break;
                    }
                    case "postal_code": {
                        
                        $("#tbl_client_header_postcode").val(component.short_name);
                        break;
                    }
                    case "locality":
                        $("#tbl_client_header_city").val(component.long_name);
                        break;
                    case "country":
                        $("#tbl_client_header_country").val(component.short_name);
                        break;
                    case "administrative_area_level_1":
                        $("#tbl_client_header_state").val(component.short_name);
                        break;
                    case "subpremise":
                        $("#subpremise").val(component.short_name);
                        break;
                }
            }

        });
    }
    catch (err) {
        alert(err.message);
    }
});