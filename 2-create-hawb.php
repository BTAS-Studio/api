<?php session_start();

    if(!isset($_SESSION['envoPath'])){
        header('Location: /index.php');
    } 

    $path = $_SERVER['DOCUMENT_ROOT'].'/'.$_SESSION['subdir'].'/'; // Sever root
    require $path .'templates/header.php';
    require $path .'templates/top-nav.php';
    require $path .'templates/left-nav.php';

    ?>
                <div class="app-main__outer">
                    <div class="app-main__inner">
                        <div class="app-page-title">
                            <div class="page-title-wrapper">
                                <div class="page-title-heading">
                                    <div class="page-title-icon">
                                        <i class="pe-7s-plane icon-gradient bg-grow-early"></i>
                                    </div>
                                    <div>
                                        Create Air Shipment
                                        <div class="page-title-subheading">Create your air shipment following the below steps.</div>
                                    </div>
                                </div>                                
                            </div>
                        </div>
                        <form id="create--air-shipment"> 
                        <div class="row">
                                    <div class="col-lg-12 col-md-12">
                                        <div class="main-card mb-3 card">
                                            <div class="card-body">
                                                <div id="smartwizard">
                                                    <ul class="forms-wizard">
                                                        <li>
                                                            <a href="#step-1">
                                                                <em>1</em>
                                                                <span>Shipper Details</span>
                                                            </a>
                                                        </li>
                                                        <li>
                                                            <a href="#step-2">
                                                                <em>2</em>
                                                                <span>Consignee Details</span>
                                                            </a>
                                                        </li>
                                                        <li>
                                                            <a href="#step-3">
                                                                <em>3</em>
                                                                <span>Link Receptacles</span>
                                                            </a>
                                                        </li>
                                                        <li>
                                                            <a href="#step-4">
                                                                <em>4</em>
                                                                <span>HAWB Details</span>
                                                            </a>
                                                        </li>
                                                        <li>
                                                            <a href="#step-5">
                                                                <em>5</em>
                                                                <span>Documents</span>
                                                            </a>
                                                        </li>
                                                    </ul>           
                                                    <div class="form-wizard-content">                                                        
                                                        <div id="step-1">
                                                            <div id="accordion" class="accordion-wrapper mb-3">
                                                                <div class="card">
                                                                    <div id="headingOne" class="card-header">
                                                                        <button type="button" data-toggle="" data-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne" class="text-left m-0 p-0 btn btn-link btn-block collapsed">
                                                                            <span class="form-heading">Sender Details
                                                                            </span>                                                                          
                                                                        </button>
                                                                    </div>
                                                                    <div data-parent="#accordion" id="collapseOne"
                                                                        aria-labelledby="headingOne" class="collapse show">
                                                                        <div class="card-body">
                                                                            <div class="form-row">
                                                                                <div class="col-md-6">
                                                                                    <div class="position-relative form-group">  
                                                                                    <div class="form-step-0" role="form" data-toggle="validator">                                                                   
                                                                                            <div class="form-group">
                                                                                                <label for="businessNameCol">Business Name</label>
                                                                                                    <input  name="businessNameCol" id="businessNameCol"
                                                                                                    placeholder=""
                                                                                                    type="text" class="form-control" required>
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>   
                                                                                        </div>                                                                                  
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-row">
                                                                                <div class="col-md-3">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-0" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="firstNameCol">First Name</label>
                                                                                                    <input  name="firstNameCol" id="firstNameCol"
                                                                                                    placeholder=""
                                                                                                    type="text" class="form-control" required>
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>                          
                                                                                <div class="col-md-3">
                                                                                    <div class="position-relative fEorm-group">
                                                                                        <div class="form-step-0" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="lastNameCol">Last Name</label>
                                                                                                <input name="lastNameCol" id="lastNameCol"
                                                                                                placeholder=""
                                                                                                type="text" class="form-control" required>
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-md-3">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-0" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="emailCol">Email</label>
                                                                                                <input name="emailCol" id="emailCol"
                                                                                                 placeholder=""
                                                                                                type="email" class="form-control" required>
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-md-3">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-0" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="telephoneCol">Telephone</label>
                                                                                                <input name="telephoneCol" id="telephoneCol"
                                                                                                placeholder=""
                                                                                                type="number" class="form-control" required>
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        <div class="form-row">
                                                                            <div class="col-md-2">
                                                                                <div class="position-relative form-group">
                                                                                     <div class="form-step-0" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="unitCol">Unit</label>
                                                                                                <input name="unitCol" id="subpremise" 
                                                                                                placeholder=""
                                                                                                type="text" class="form-control" disabled>
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <div class="position-relative form-group">
                                                                                     <div class="form-step-0" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="numberCol">Number</label>
                                                                                                <input name="numberCol" id="street_number" 
                                                                                                placeholder=""
                                                                                                type="text" class="form-control" required disabled>
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="position-relative form-group">
                                                                                     <div class="form-step-0" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="addressCol">Address</label>
                                                                                                <input name="addressCol" id="route" 
                                                                                                placeholder=""
                                                                                                type="text" class="form-control" required>
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="position-relative form-group">
                                                                                    <div class="form-step-0" role="form" data-toggle="validator">
                                                                                        <div class="form-group">
                                                                                            <label for="address2Col">Address 2</label>
                                                                                            <input name="address2Col" id="address2Col"
                                                                                                placeholder="Apartment, studio, or floor"
                                                                                                type="text" class="form-control">
                                                                                            <div class="help-block with-errors"></div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-row">
                                                                            <div class="col-md-3">
                                                                                <div class="position-relative form-group">
                                                                                    <div class="form-step-0" role="form" data-toggle="validator">
                                                                                        <div class="form-group">
                                                                                            <label for="cityCol">City</label>
                                                                                            <input id="locality" name="cityCol" 
                                                                                            type="text" class="form-control" required disabled>
                                                                                         <div class="help-block with-errors"></div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <div class="position-relative form-group">
                                                                                    <div class="form-step-0" role="form" data-toggle="validator">
                                                                                        <div class="form-group">
                                                                                            <label for="postcodeCol">Postcode</label>
                                                                                            <input name="postcodeCol" id="postal_code"
                                                                                                type="text" class="form-control" required disabled>
                                                                                            <div class="help-block with-errors"></div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <div class="position-relative form-group">
                                                                                    <div class="form-step-0" role="form" data-toggle="validator">
                                                                                        <div class="form-group">
                                                                                            <label for="stateCol">State</label>
                                                                                            <input name="stateCol" id="administrative_area_level_1"
                                                                                                type="text" class="form-control" required disabled> 
                                                                                            <div class="help-block with-errors"></div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <div class="position-relative form-group">
                                                                                    <div class="form-step-0" role="form" data-toggle="validator">
                                                                                        <div class="form-group">
                                                                                            <label for="countryCol">Country</label>
                                                                                            <input name="countryCol" id="country"
                                                                                                type="text" class="form-control" required disabled>
                                                                                        <div class="help-block with-errors"></div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        </div>
                                                        <div id="step-2">
                                                            <div id="accordion" class="accordion-wrapper mb-3">
                                                                <div class="card">
                                                                    <div id="headingOne" class="card-header">
                                                                        <button type="button" data-toggle="" data-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne" class="text-left m-0 p-0 btn btn-link btn-block collapsed">
                                                                            <span class="form-heading">Delivery Details
                                                                            </span>
                                                                        </button>
                                                                    </div>
                                                                    <div data-parent="#accordion" id="collapseOne"
                                                                        aria-labelledby="headingOne" class="collapse show">
                                                                        <div class="card-body">
                                                                            <div class="form-row">
                                                                                <div class="col-md-6">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-1" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="businessNameDel">Business Name</label>
                                                                                                <input  name="businessNameDel" id="businessNameDel"
                                                                                                placeholder=""
                                                                                                type="text" class="form-control" required>
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-row">
                                                                                <div class="col-md-3">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-1" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="firstNameDel">First Name</label>
                                                                                                <input  name="firstNameDel" id="firstNameDel"
                                                                                                    placeholder=""
                                                                                                    type="text" class="form-control" required>
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-md-3">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-1" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="lastNameDel">Last Name</label>
                                                                                                <input name="lastNameDel" id="lastNameDel"
                                                                                                    placeholder=""
                                                                                                    type="text" class="form-control" required>
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-md-3">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-1" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="emailDel">Email</label>
                                                                                                <input name="emailDel" id="emailDel"
                                                                                                    placeholder=""
                                                                                                    type="email" class="form-control" required>
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-md-3">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-1" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="telephoneDel">Telephone</label>
                                                                                                <input name="telephoneDel" id="telephoneDel"
                                                                                                    placeholder=""
                                                                                                    type="number" class="form-control" required>
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        <div class="form-row">
                                                                            <div class="col-md-2">
                                                                                <div class="position-relative form-group">
                                                                                    <div class="form-step-1" role="form" data-toggle="validator">
                                                                                        <div class="form-group">
                                                                                            <label for="unitDel">Unit</label>
                                                                                            <input name="unitDel" id="subpremisedel"
                                                                                                placeholder=""
                                                                                                type="text" class="form-control" disabled>
                                                                                            <div class="help-block with-errors"></div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <div class="position-relative form-group">
                                                                                    <div class="form-step-1" role="form" data-toggle="validator">
                                                                                        <div class="form-group">
                                                                                            <label for="numberDel">Number</label>
                                                                                            <input name="numberDel" id="street_numberdel"
                                                                                                placeholder=""
                                                                                                type="text" class="form-control" required disabled>
                                                                                            <div class="help-block with-errors"></div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="position-relative form-group">
                                                                                    <div class="form-step-1" role="form" data-toggle="validator">
                                                                                        <div class="form-group">
                                                                                            <label for="addressDel">Address</label>
                                                                                            <input name="addressDel" id="routedel"
                                                                                                placeholder=""
                                                                                                type="text" class="form-control" required>
                                                                                            <div class="help-block with-errors"></div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="position-relative form-group">
                                                                                    <div class="form-step-1" role="form" data-toggle="validator">
                                                                                        <div class="form-group">
                                                                                            <label for="address2Del">Address 2</label>
                                                                                            <input name="address2Del" id="address2Del"
                                                                                                placeholder="Apartment, studio, or floor"
                                                                                                type="text" class="form-control">
                                                                                            <div class="help-block with-errors"></div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-row">
                                                                            <div class="col-md-3">
                                                                                <div class="position-relative form-group">
                                                                                    <div class="form-step-1" role="form" data-toggle="validator">
                                                                                        <div class="form-group">
                                                                                            <label for="cityDel">City</label>
                                                                                            <input name="cityDel" id="localitydel"
                                                                                                type="text" class="form-control" required disabled>
                                                                                            <div class="help-block with-errors"></div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <div class="position-relative form-group">
                                                                                    <div class="form-step-1" role="form" data-toggle="validator">
                                                                                        <div class="form-group">
                                                                                            <label for="postcodeDel">Postcode</label>
                                                                                            <input name="postcodeDel" id="postal_codedel"
                                                                                                type="text" class="form-control" required disabled>
                                                                                            <div class="help-block with-errors"></div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <div class="position-relative form-group">
                                                                                    <div class="form-step-1" role="form" data-toggle="validator">
                                                                                        <div class="form-group">
                                                                                            <label for="stateDel">State</label>
                                                                                            <input name="stateDel" id="administrative_area_level_1del"
                                                                                                type="text" class="form-control" required disabled>
                                                                                            <div class="help-block with-errors"></div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <div class="position-relative form-group">
                                                                                    <div class="form-step-1" role="form" data-toggle="validator">
                                                                                        <div class="form-group">
                                                                                            <label for="countryDel">Country</label>
                                                                                            <input name="countryDel" id="countrydel"
                                                                                                type="text" class="form-control" required disabled>
                                                                                            <div class="help-block with-errors"></div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        </div>                                                                                                          
                                                        <div id="step-3">
                                                            <div id="accordion" class="accordion-wrapper mb-3">
                                                                <div class="row scan-row">
                                                                <div class="col-lg-6 col-md-6">
                                                                    <div class="main-card mb-3 card">  
                                                                        <div id="headingThree" class="card-header">                                                
                                                                            <span class="form-heading scan">Scan Receptacle</span>                                              
                                                                            <div class="widget-content-left-scan">
                                                                                <div class="col-md-12">
                                                                                    <input  name="scan" id="scan" placeholder="Enter Receptacle Information" type="text" class="form-control">
                                                                                </div> 
                                                                            </div>                                                                                               
                                                                        </div>                                           
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row scan-row">
                                                                <div class="col-lg-12 col-md-12">
                                                                    <div class="main-card mb-3 card">  
                                                                        <div id="headingTwo" class="card-header">
                                                                            <button type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo" class="text-left m-0 p-0 btn btn-link btn-block collapsed">
                                                                            <span class="form-heading">Scanned Receptacles</span>
                                                                            </button>                                                                                                             
                                                                        </div>
                                                                        <div data-parent="#accordion2" id="collapseTwo"
                                                                            aria-labelledby="headingTwo" class="collapse show">
                                                                            <div class="card-body"> 
                                                                                <div id="example-table"></div>  
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>                                    
                                                            </div>
                                                            </div>
                                                        </div>
                                                        <div id="step-4">
                                                            <div id="accordion" class="accordion-wrapper mb-3">                                                                
                                                                <div class="card">
                                                                    <div id="headingOne" class="card-header">
                                                                        <button type="button" data-toggle="" data-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne" class="text-left m-0 p-0 btn btn-link btn-block collapsed">
                                                                            <span class="form-heading">Shipment Information
                                                                            </span>
                                                                        </button>
                                                                    </div>
                                                                    <div data-parent="#accordion" id="collapseOne" aria-labelledby="headingOne" class="collapse show">
                                                                        <div class="card-body">
                                                                            <div class="form-row">
                                                                                 <div class="col-md-3">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-3" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="hawb">HAWB</label>
                                                                                                <input name="hawb" id="hawb" placeholder="" type="text" class="form-control" required>
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-md-2">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-3" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="incoterms">Incoterms</label>
                                                                                                <select name="incoterms" id="incoterms" class="form-control" required>
                                                                                                <option value ="false" selected>--Select--</option>
                                                                                                <option value="EXW">Ex Works</option> 
                                                                                                <option value="FOB">Freight On Board</option>
                                                                                                <option value="CFR">Cost Freight</option>
                                                                                                </select>
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-md-2">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-3" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="yourReference">Your Reference</label>
                                                                                                <input name="yourRef" id="yourRef" placeholder="" type="text" class="form-control">
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-row">
                                                                                <div class="col-md-2">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-3" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="shipmentValue">Shipment Value</label>
                                                                                                <input name="goodsValue" id="goodsValue" placeholder="" type="number" class="form-control" required="">
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-md-5">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-3" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="goodsDecription">Goods Description</label>
                                                                                                <input name="goodsDesc" id="goodsDesc" placeholder="" type="text" class="form-control" required="">
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-row">
                                                                                <div class="col-md-2">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-3" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="dangerousGoods">Dangerous Goods</label>
                                                                                                <select name="dangerousGoods" id="dangerousGoods" class="form-control" required="">
                                                                                                    <option selected="selected" disabled="true">--Select--</option>
                                                                                                <option value="1">Yes</option>
                                                                                                <option value="0">No</option>
                                                                                                </select>
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-md-1">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-3" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="DGClass">Class</label>
                                                                                                <input name="DGClass" id="DGClass" placeholder="" type="number" class="form-control">
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-md-1">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-3" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="DGUN">UN</label>
                                                                                                <input name="DGUN" id="DGUN" placeholder="" type="number" class="form-control">
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-md-2">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-3" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="DGPackaging">Packaging</label>
                                                                                                <input name="DGPackaging" id="DGPackaging" placeholder="" type="text" class="form-control">
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-md-2">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-3" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="tailLiftO">Tail Lift Origin</label>
                                                                                                <select name="tailLiftO" id="tailLiftO" class="form-control" required="">
                                                                                                <option value="false" selected="">--Select--</option>
                                                                                                <option value="Yes">Yes</option>
                                                                                                <option value="No">No</option>
                                                                                                </select>
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-md-2">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-3" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="tailLiftD">Tail Lift Destination</label>
                                                                                                <select name="tailLiftD" id="tailLiftD" class="form-control" required="">
                                                                                                <option value="false" selected="">--Select--</option> 
                                                                                                <option value="Yes">Yes</option>
                                                                                                <option value="No">No</option>
                                                                                                </select>
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-row">
                                                                                <div class="col-md-6">
                                                                                    <div class="position-relative form-group">
                                                                                        <div class="form-step-3" role="form" data-toggle="validator">
                                                                                            <div class="form-group">
                                                                                                <label for="specialInst">Special Instructions</label>
                                                                                                <input name="specialInst" id="specialInst" placeholder="" type="text" class="form-control">
                                                                                                <div class="help-block with-errors"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>                                                                 
                                                                <div class="card">
                                                                    <div id="headingOne" class="card-header">
                                                                        <button type="input" data-toggle="" data-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne" class="text-left m-0 p-0 btn btn-link btn-block collapsed">
                                                                            <span class="form-heading">Item Information
                                                                            </span>
                                                                        </button>
                                                                        <button class="float-right btn-icon btn-icon-only btn btn-success addbutton">
                                                                                        <i class="pe-7s-plus btn-icon-wrapper"></i>
                                                                                    </button>
                                                                    </div>
                                                                    <div data-parent="#accordion" id="collapseOne"
                                                                        aria-labelledby="headingOne" class="collapse show">
                                                                        <div class="card-body">
                                                                        <div class="items">
                                                                            <div class="form-row item-row">
                                                                                
                                                                            </div>
                                                                        </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div id="step-5">
                                                            <div id="accordion" class="accordion-wrapper mb-3">
                                                                <div class="card">
                                                                    <div id="headingOne" class="card-header">
                                                                        <button type="button" data-toggle="" data-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne" class="text-left m-0 p-0 btn btn-link btn-block collapsed">
                                                                            <span class="form-heading">Upload your documents
                                                                            </span>
                                                                        </button>
                                                                    </div>
                                                                    <div data-parent="#accordion" id="collapseOne"
                                                                        aria-labelledby="headingOne" class="collapse show">
                                                                        <div class="card-body">
                                                                            <input id="input-id" name="file-data" type="file" accept="image/png, image/jpeg, image/csv, image/pdf, image/xlsx, image/xls, image/doc, image/jpg, image/txt" multiple>                                                                                                                         
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>                                                            
                                                        </div>                                                    
                                                    </div>
                                                </div>
                                                <div class="divider"></div>
                                                <div class="clearfix">
                                                    <button type="button" id="finish-btn" class="btn-shadow btn-wide float-right btn-pill btn-hover-shine btn btn-success">Finish</button>
                                                    <button type="button" id="next-btn" class="btn-shadow btn-wide float-right btn-pill mr-2 btn-hover-shine btn btn-primary">Next</button>
                                                    <button type="button" id="prev-btn" class="btn-shadow float-right btn-wide btn-pill mr-2 btn btn-outline-secondary">Previous</button>                                                    
                                                </div>
                                            </div>
                                        </div>
                                    </div>                                    
                                </div>                       
                            </div>
                        </form>
    <script type="text/javascript" src="/<?php echo $_SESSION['subdir']; ?>/vendors/smartwizard/dist/js/jquery.smartWizard.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/1000hz-bootstrap-validator/0.11.5/validator.min.js"></script>
   <?php 
    require $path .'templates/footer.php';
    ?>
        <script>  

            // with plugin options
    $("#input-id").fileinput(
        {
        'uploadUrl': '/<?php echo $_SESSION['subdir']; ?>/ajax/file-upload.php', 
        'previewFileType': 'any',
        'overwriteInitial': false,
        'initialPreviewAsData' : true,
        'allowedFileExtensions' : ['png', 'jpeg', 'csv', 'pdf', 'xlsx', 'xls', 'doc', 'txt', 'jpg'],
        'maxFileSize' : 10000
    });


     $.fn.pressEnter = function(fn) {  

            return this.each(function() {  
                $(this).bind('enterPress', fn);
                $(this).keyup(function(e){
                    if(e.keyCode == 13)
                    {
                      $(this).trigger("enterPress");
                    }
                })
            });  
         }; 

         $("#finish-btn").hide();

    //use it:
        $('#scan').pressEnter(function(e){

             Swal.fire({
              title: 'Getting Receptacle..',
              html: 'Please bear with us',
              timer: 10000,
              timerProgressBar: true,
              showConfirmButton:false        
            })


            e.preventDefault();

            var tracking = $('#scan').val();

            if(tracking.match(".*\\d.*")){
               // The string has a number, do whatever logic you need here.            

            var recId = tracking.match(/[\d\.]+/g);
            if (recId != null){
                var recId = recId.toString();
            }           

            $.ajax({
             type: 'POST',
                url: '/<?php echo $_SESSION['subdir']; ?>/ajax/get-receptacle-details.php',
                data: { 
                        receptacleId: recId                       
                },
                  error: function (XMLHttpRequest, textStatus, errorThrown) {
                  // swal({title:textStatus,text: errorThrown,icon: "error",button: "Close"});
              },
                  success: function(dataresult) {

                    if (dataresult == 'error') {

                        swal.fire({
                          title:'Receptacle does not exist!',
                          text: 'Please try another receptacle.',
                          icon: "error",
                          button: "Close",
                        });

                        var tracking = $('#scan').val('');

                    } else {

                    var obj = jQuery.parseJSON(dataresult);

                    if (obj.receptacle.status == 'closed') {

                        var tracking = $('#scan').val();

                        data = { id: obj.receptacle.id, reference: obj.receptacle.reference, origin: obj.receptacle.origin, destination: obj.receptacle.destination, type:obj.receptacle.type, items: obj.receptacle.shipmentCount, weight: obj.receptacle.weight , length: obj.receptacle.length, width: obj.receptacle.width, height: obj.receptacle.height };

                        table.setData([data]);

                        swal.close()

                        var tracking = $('#scan').val('');

                    } else {

                        swal.fire({
                          title:'Receptacle still open',
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
            else{

                 swal.fire({
                          title:'Receptacle does not exist!',
                          text: 'Please try another receptacle.',
                          icon: "error",
                          button: "Close",
                        });

                 var tracking = $('#scan').val('');
               
            }



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

 $.each( gacFields, function( key, field ) {
            var input = document.getElementById(field);
            console.log(input);
            //varify the field 
            if ( input != null ) {
            
                     var options = {
                    types: ['address']
                };


                 
                var autocomplete = new google.maps.places.Autocomplete(input, options);
                 
                google.maps.event.addListener(autocomplete, 'place_changed', function(e) {
            

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


  $.each( gacFields2, function( key, field ) {
            var input = document.getElementById(field);
            console.log(input);
            //varify the field 
            if ( input != null ) {
            
                     var options = {
                    types: ['address'],
                    componentRestrictions: ({'country': ['au','nz']})
                };


                 
                var autocomplete = new google.maps.places.Autocomplete(input, options);
                 
                google.maps.event.addListener(autocomplete, 'place_changed', function(e) {
            

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
                    if (componentForm2[addressType+'del']) {                    
                    var val = place.address_components[i][componentForm2[addressType+'del']];
                    document.getElementById(addressType+'del').value = val;
                           }
                    }  
                });
            }
        });
        


    // Toolbar extra buttons
    var btnFinish = $("#finish-btn").on('click', function(e){

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
                if( !$(this).hasClass('disabled')){ 
                    var elmForm = $("#create-shipment");
                        if(elmForm){
                                    elmForm.validator('validate'); 
                                    var elmErr = elmForm.find('.has-error');
                                    if(elmErr && elmErr.length > 0){
                                        return false;    
                                    }else{         

                                            Swal.fire({
                                              title: 'Creating shipment!',
                                              html: 'Please wait..',
                                              timer: 10000,
                                              timerProgressBar: true,
                                              allowOutsideClick: false,
                                              showConfirmButton:false       
                                            })

                                            var myform = document.getElementById("create-shipment");

                                            var fd = new FormData(myform);
                                            $.ajax({
                                                url: '/<?php echo $_SESSION['subdir']; ?>/ajax/create-shipment.php',
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

                                                        if (typeof obj.response.message[0].response.errorCode  === "undefined" ) {
                                                            
                                                            var label = obj.response.message[0].response.shippingLabel;
                                                            var consignment = obj.response.message[0].response.trackingNumber;                                                        

                                                        } else {

                                                            error = true;
                                                            errorMessage = obj.response.message[0].response.errorMessage;

                                                        }

                                                    }

                                                    if (obj.carrier == 'HUNTEXPSEA') {

                                                        error = false;

                                                        
                                                        if (obj.response.message[0].error.success == false ) {

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

                                                            $.each(errors, function(idx, value) {

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

                                                            $.each(errors, function(idx, value) {

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
                                                      html: 'Error: '+ errorMessage,
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
                                                      title: 'Shipment Created '+ consignment,
                                                      html: 'Download Label: <a href="data:application/pdf;base64,'+label+'" download="label.pdf"><i class="fas fa-barcode success"></i></a>',
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
          darkMode:false, // Enable/disable Dark Mode if the theme supports. true/false
          autoAdjustHeight: true, // Automatically adjust content height
          cycleSteps: false, // Allows to cycle the navigation of steps
          backButtonSupport: true, // Enable the back button support
          enableURLhash: false, // Enable selection of the step based on url hash
          transition: {
              animation: 'fade', // Effect on navigation, none/fade/slide-horizontal/slide-vertical/slide-swing
              speed: '400', // Transion animation speed
              easing:'' // Transition animation easing. Not supported without a jQuery easing plugin
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

    $("#smartwizard").on("showStep", function(e, anchorObject, stepNumber, stepDirection) {
                // Enable finish button only on last step
                if(stepNumber == 4){ 
                    $("#finish-btn").show();
                    $("#next-btn").hide();  
                }else{
                    $("#finish-btn").hide();
                    $("#next-btn").show();
                }
            }); 

    $("#smartwizard").on("leaveStep", function(e, anchorObject, stepNumber, stepDirection) {
                var elmForm = $(".form-step-" + stepNumber);
                // stepDirection === 'forward' :- this condition allows to do the form validation 
                // only on forward navigation, that makes easy navigation on backwards still do the validation when going next
                if(stepDirection === 'forward' && elmForm){
                    elmForm.validator('validate'); 
                    var elmErr = elmForm.children('.has-error');
                    if(elmErr && elmErr.length > 0){
                        // Form validation failed
                        return false;    
                    }

                    if (stepNumber == 2) {

                        var data = table.getData();

                        $.each(data, function(idx, value) {

                            var inputName = "input[name='item["+value.id+"][itemRef]']";

                            var inputValue = $(inputName).val();
                            
                            if (inputValue == undefined) {

                             $(".items").append('<div class="form-row item-row rep'+value.id+'">\
                            <div class="col-md-2">\
                                <div class="position-relative form-group">\
                                    <select name="itemType" id="itemType" class="form-control" required="" disabled>\
                                    <option selected>'+value.type+'</option>\
                                    </select>\
                                    <div class="help-block with-errors"></div>\
                                </div>\
                            </div>\
                            <div class="col-md-1">\
                             <div class="position-relative form-group">\
                                    <input name="item['+value.id+'][itemQty]" id="itemqty"\
                                        placeholder=""\
                                        type="numeric" class="form-control" value=1 disabled>\
                                </div>\
                            </div>\
                            <div class="col-md-3">\
                                <div class="position-relative form-group">\
                                    <input name="item['+value.id+'][itemRef]" id="yourRef"\
                                        placeholder=""\
                                        type="text" class="form-control" value="'+value.id+'" disabled>\
                                </div>\
                            </div>\
                            <div class="col-md-1">\
                                <div class="position-relative form-group">\
                                    <input name="item['+value.id+'][itemWeight]" id="itemWeight"\
                                        placeholder=""\
                                        type="numeric" class="form-control" value="'+value.weight+'" disabled>\
                                </div>\
                            </div>\
                            <div class="col-md-1">\
                                <div class="position-relative form-group">\
                                    <input name="item['+value.id+'][itemLength]" id="itemLength"\
                                        placeholder=""\
                                        type="numeric" class="form-control" value="'+value.length+'" disabled>\
                                </div>\
                            </div>\
                            <div class="col-md-1">\
                                <div class="position-relative form-group">\
                                    <input name="item['+value.id+'][itemWidth]" id="itemWidth"\
                                        placeholder=""\
                                        type="numeric" class="form-control" value="'+value.width+'" disabled>\
                                </div>\
                            </div>\
                            <div class="col-md-1">\
                                <div class="position-relative form-group">\
                                    <input name="item['+value.id+'][itemHeight]" id="itemHeight"\
                                        placeholder=""\
                                        type="numeric" class="form-control" value="'+value.height+'" disabled>\
                                </div>\
                            </div>\
                            </div>');

                         }


                        })
                        
                     
                    }
                }
                return true;
            });


    itemnumber = 1;

    $( ".removebutton" ).click(function() {
      $(this).closest(".item-row").remove();
      
     });

    $(".addbutton").click(function(e){    

    e.preventDefault(); 
      
    $(".items").append('<div class="form-row item-row">\
                            <div class="col-md-2">\
                                <div class="position-relative form-group">\
                                    <select name="itemType" id="itemType" class="form-control" required="">\
                                    <option value ="false" selected>--Select--</option>\
                                    <option value="Box">Box</option>\
                                    <option value="Pallet">Pallet</option>\
                                    </select>\
                                    <div class="help-block with-errors"></div>\
                                </div>\
                            </div>\
                            <div class="col-md-1">\
                             <div class="position-relative form-group">\
                                    <input name="item['+itemnumber+'][itemQty]" id="itemqty"\
                                        placeholder=""\
                                        type="numeric" class="form-control">\
                                </div>\
                            </div>\
                            <div class="col-md-3">\
                                <div class="position-relative form-group">\
                                    <input name="item['+itemnumber+'][itemRef]" id="yourRef"\
                                        placeholder=""\
                                        type="text" class="form-control">\
                                </div>\
                            </div>\
                            <div class="col-md-1">\
                                <div class="position-relative form-group">\
                                    <input name="item['+itemnumber+'][itemWeight]" id="itemWeight"\
                                        placeholder=""\
                                        type="numeric" class="form-control">\
                                </div>\
                            </div>\
                            <div class="col-md-1">\
                                <div class="position-relative form-group">\
                                    <input name="item['+itemnumber+'][itemLength]" id="itemLenght"\
                                        placeholder=""\
                                        type="numeric" class="form-control">\
                                </div>\
                            </div>\
                            <div class="col-md-1">\
                                <div class="position-relative form-group">\
                                    <input name="item['+itemnumber+'][itemWidth]" id="itemWidth"\
                                        placeholder=""\
                                        type="numeric" class="form-control">\
                                </div>\
                            </div>\
                            <div class="col-md-1">\
                                <div class="position-relative form-group">\
                                    <input name="item['+itemnumber+'][itemHeight]" id="itemHeight"\
                                        placeholder=""\
                                        type="numeric" class="form-control">\
                                </div>\
                            </div>\
                            <div class="col-md-1">\
                                <button class="mr-2 btn-icon btn-icon-only btn btn-warning removebutton">\
                                    <i class="pe-7s-trash btn-icon-wrapper"></i>\
                                </button>\
                            </div>\
                            </div>');
    itemnumber++;

    $( ".removebutton" ).click(function() {
      $(this).closest(".item-row").remove();

      });



    });

    var deleteShipment = function(cell, formatterParams, onRendered){   

            return '<a id="deleteShipment" href=""><i class="fas fa-trash-alt"></i>';
        }

        var table = new Tabulator("#example-table", {

                layout:"fitColumns",      //fit columns to width of table
                responsiveLayout:"hide",  //hide columns that dont fit on the table
                tooltips:true,
                placeholder:"Scan Shipments",
                addRowPos:"top",          //when adding a new row, add it to the top of the table
                history:true,             //allow undo and redo actions on the table
                pagination:"local",       //paginate the data
                paginationSize:10,         //allow 7 rows per page of data
                movableColumns:true,      //allow column order to be changed
                resizableRows:true,       //allow row order to be changed
                columns:[                 //define the table columns
                    {title:"Receptacle Id", headerFilter:"input", field:"id"},
                    {title:"Reference", headerFilter:"input", field:"reference"},
                    {title:"Origin", headerFilter:"input", field:"origin"},
                    {title:"Destination", headerFilter:"input", field:"destination"},
                    {title:"Type", headerFilter:"input", field:"type"},
                    {title:"Items", headerFilter:"input", field:"items"},
                    {title:"Weight", headerFilter:"input", field:"weight"},                    
                    {title:"Delete", formatter:deleteShipment, align:"center", width:50, headerSort:false, cellClick:function(e, cell){

                        e.preventDefault();
                        cell.getRow().delete();
                        
                        var ID = cell.getData().id
                        var removeId = '.rep'+ID;

                        $(removeId).remove();

                    }},

                ]});

        
    </script>
    <?php
    require $path .'templates/right-nav.php';   
    ?>
          
       