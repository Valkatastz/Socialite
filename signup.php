<?php include("inc/header.inc.php"); ?>

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6">
                <form class="form-horizontal" role="form">
                    <h2>Registration Form</h2>
                    <div class="form-group">
                        <label for="firstName" class="col-sm-3 control-label">Full Name</label>
                        <div class="col-sm-9">
                            <input type="text" id="firstName" placeholder="Full Name" class="form-control"
                                   autofocus>
                            <span class="help-block">Last Name, First Name, eg.: Smith, Harry</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="email" class="col-sm-3 control-label">Email</label>
                        <div class="col-sm-9">
                            <input type="email" id="email" placeholder="Email" class="form-control">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="password" class="col-sm-3 control-label">Password</label>
                        <div class="col-sm-9">
                            <input type="password" id="password" placeholder="Password" class="form-control">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="birthDate" class="col-sm-3 control-label">Date of Birth</label>
                        <div class="col-sm-9">
                            <input type="date" id="birthDate" class="form-control">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="country" class="col-sm-3 control-label">Country</label>
                        <div class="col-sm-9">
                            <select id="country" class="form-control">
                                <option>AD - Andorra</option>
                                <option>AE - United Arab Emirates</option>
                                <option>AF - Afghanistan</option>
                                <option>AG - Antigua and Barbuda</option>
                                <option>AI - Anguilla</option>
                                <option>AL - Albania</option>
                                <option>AM - Armenia</option>
                                <option>AO - Angola</option>
                                <option>AQ - Antarctica</option>
                                <option>AR - Argentina</option>
                                <option>AS - American Samoa</option>
                                <option>AT - Austria</option>
                                <option>AU - Australia</option>
                                <option>AW - Aruba</option>
                                <option>AZ - Azerbaijan</option>
                                <option>BA - Bosnia and Herzegovina</option>
                                <option>BB - Barbados</option>
                                <option>BD - Bangladesh</option>
                                <option>BE - Belgium</option>
                                <option>BF - Burkina Faso</option>
                                <option>BG - Bulgaria</option>
                                <option>BH - Bahrain</option>
                                <option>BI - Burundi</option>
                                <option>BJ - Benin</option>
                                <option>BL - Saint Barthelemy</option>
                                <option>BM - Bermuda</option>
                                <option>BN - Brunei</option>
                                <option>BO - Bolivia</option>
                                <option>BR - Brazil</option>
                                <option>BS - Bahamas</option>
                                <option>BT - Bhutan</option>
                                <option>BV - Bouvet Island</option>
                                <option>BW - Botswana</option>
                                <option>BY - Belarus</option>
                                <option>BZ - Belize</option>
                                <option>CA - Canada</option>
                                <option>CC - Cocos (Keeling) Islands</option>
                                <option>CD - Congo, Democratic Republic</option>
                                <option>CF - Central African Republic</option>
                                <option>CG - Congo, Republic of the</option>
                                <option>CH - Switzerland</option>
                                <option>CI - Cote d'Ivoire</option>
                                <option>CK - Cook Islands</option>
                                <option>CL - Chile</option>
                                <option>CM - Cameroon</option>
                                <option>CN - China</option>
                                <option>CO - Colombia</option>
                                <option>CR - Costa Rica</option>
                                <option>CU - Cuba</option>
                                <option>CV - Cape Verde</option>
                                <option>CW - Curacao</option>
                                <option>CX - Christmas Island</option>
                                <option>CY - Cyprus</option>
                                <option>CZ - Czech Republic</option>
                                <option>DE - Germany</option>
                                <option>DJ - Djibouti</option>
                                <option>DK - Denmark</option>
                                <option>DM - Dominica</option>
                                <option>DO - Dominican Republic</option>
                                <option>DZ - Algeria</option>
                                <option>EC - Ecuador</option>
                                <option>EE - Estonia</option>
                                <option>EG - Egypt</option>
                                <option>EH - Western Sahara</option>
                                <option>ER - Eritrea</option>
                                <option>ES - Spain</option>
                                <option>ET - Ethiopia</option>
                                <option>FI - Finland</option>
                                <option>FJ - Fiji</option>
                                <option>FK - Falkland Islands (Islas Malvinas)</option>
                                <option>FM - Micronesia</option>
                                <option>FO - Faroe Islands</option>
                                <option>FR - France</option>
                                <option>FX - France, Metropolitan</option>
                                <option>GA - Gabon</option>
                                <option>GB - United Kingdom</option>
                                <option>GD - Grenada</option>
                                <option>GE - Georgia</option>
                                <option>GF - French Guiana</option>
                                <option>GG - Guernsey</option>
                                <option>GH - Ghana</option>
                                <option>GI - Gibraltar</option>
                                <option>GL - Greenland</option>
                                <option>GM - Gambia</option>
                                <option>GN - Guinea</option>
                                <option>GP - Guadeloupe</option>
                                <option>GQ - Equatorial Guinea</option>
                                <option>GR - Greece</option>
                                <option>GS - South Georgia and the Islands</option>
                                <option>GT - Guatemala</option>
                                <option>GU - Guam</option>
                                <option>GW - Guinea-Bissau</option>
                                <option>GY - Guyana</option>
                                <option>HK - Hong Kong</option>
                                <option>HM - Heard Island and McDonald Islands</option>
                                <option>HN - Honduras</option>
                                <option>HR - Croatia</option>
                                <option>HT - Haiti</option>
                                <option>HU - Hungary</option>
                                <option>ID - Indonesia</option>
                                <option>IE - Ireland</option>
                                <option>IL - Israel</option>
                                <option>IM - Isle of Man</option>
                                <option>IN - India</option>
                                <option>IO - British Indian Ocean Territory</option>
                                <option>IQ - Iraq</option>
                                <option>IR - Iran</option>
                                <option>IS - Iceland</option>
                                <option>IT - Italy</option>
                                <option>JE - Jersey</option>
                                <option>JM - Jamaica</option>
                                <option>JO - Jordan</option>
                                <option>JP - Japan</option>
                                <option>KE - Kenya</option>
                                <option>KG - Kyrgyzstan</option>
                                <option>KH - Cambodia</option>
                                <option>KI - Kiribati</option>
                                <option>KM - Comoros</option>
                                <option>KN - Saint Kitts and Nevis</option>
                                <option>KP - Korea, North</option>
                                <option>KR - Korea, South</option>
                                <option>KW - Kuwait</option>
                                <option>KY - Cayman Islands</option>
                                <option>KZ - Kazakhstan</option>
                                <option>LA - Laos</option>
                                <option>LB - Lebanon</option>
                                <option>LC - Saint Lucia</option>
                                <option>LI - Liechtenstein</option>
                                <option>LK - Sri Lanka</option>
                                <option>LR - Liberia</option>
                                <option>LS - Lesotho</option>
                                <option>LT - Lithuania</option>
                                <option>LU - Luxembourg</option>
                                <option>LV - Latvia</option>
                                <option>LY - Libya</option>
                                <option>MA - Morocco</option>
                                <option>MC - Monaco</option>
                                <option>MD - Moldova</option>
                                <option>ME - Montenegro</option>
                                <option>MF - Saint Martin</option>
                                <option>MG - Madagascar</option>
                                <option>MH - Marshall Islands</option>
                                <option>MK - Macedonia</option>
                                <option>ML - Mali</option>
                                <option>MM - Burma</option>
                                <option>MN - Mongolia</option>
                                <option>MO - Macau</option>
                                <option>MP - Northern Mariana Islands</option>
                                <option>MQ - Martinique</option>
                                <option>MR - Mauritania</option>
                                <option>MS - Montserrat</option>
                                <option>MT - Malta</option>
                                <option>MU - Mauritius</option>
                                <option>MV - Maldives</option>
                                <option>MW - Malawi</option>
                                <option>MX - Mexico</option>
                                <option>MY - Malaysia</option>
                                <option>MZ - Mozambique</option>
                                <option>NA - Namibia</option>
                                <option>NC - New Caledonia</option>
                                <option>NE - Niger</option>
                                <option>NF - Norfolk Island</option>
                                <option>NG - Nigeria</option>
                                <option>NI - Nicaragua</option>
                                <option>NL - Netherlands</option>
                                <option>NO - Norway</option>
                                <option>NP - Nepal</option>
                                <option>NR - Nauru</option>
                                <option>NU - Niue</option>
                                <option>NZ - New Zealand</option>
                                <option>OM - Oman</option>
                                <option>PA - Panama</option>
                                <option>PE - Peru</option>
                                <option>PF - French Polynesia</option>
                                <option>PG - Papua New Guinea</option>
                                <option>PH - Philippines</option>
                                <option>PK - Pakistan</option>
                                <option>PL - Poland</option>
                                <option>PM - Saint Pierre and Miquelon</option>
                                <option>PN - Pitcairn Islands</option>
                                <option>PR - Puerto Rico</option>
                                <option>PS - Gaza Strip</option>
                                <option>PS - West Bank</option>
                                <option>PT - Portugal</option>
                                <option>PW - Palau</option>
                                <option>PY - Paraguay</option>
                                <option>QA - Qatar</option>
                                <option>RE - Reunion</option>
                                <option>RO - Romania</option>
                                <option>RS - Serbia</option>
                                <option>RU - Russia</option>
                                <option>RW - Rwanda</option>
                                <option>SA - Saudi Arabia</option>
                                <option>SB - Solomon Islands</option>
                                <option>SC - Seychelles</option>
                                <option>SD - Sudan</option>
                                <option>SE - Sweden</option>
                                <option>SG - Singapore</option>
                                <option>SH - Saint Helena, Ascension, and Tristan da Cunha</option>
                                <option>SI - Slovenia</option>
                                <option>SJ - Svalbard</option>
                                <option>SK - Slovakia</option>
                                <option>SL - Sierra Leone</option>
                                <option>SM - San Marino</option>
                                <option>SN - Senegal</option>
                                <option>SO - Somalia</option>
                                <option>SR - Suriname</option>
                                <option>SS - South Sudan</option>
                                <option>ST - Sao Tome and Principe</option>
                                <option>SV - El Salvador</option>
                                <option>SX - Sint Maarten</option>
                                <option>SY - Syria</option>
                                <option>SZ - Swaziland</option>
                                <option>TC - Turks and Caicos Islands</option>
                                <option>TD - Chad</option>
                                <option>TF - French Southern and Antarctic Lands</option>
                                <option>TG - Togo</option>
                                <option>TH - Thailand</option>
                                <option>TJ - Tajikistan</option>
                                <option>TK - Tokelau</option>
                                <option>TL - Timor-Leste</option>
                                <option>TM - Turkmenistan</option>
                                <option>TN - Tunisia</option>
                                <option>TO - Tonga</option>
                                <option>TR - Turkey</option>
                                <option>TT - Trinidad and Tobago</option>
                                <option>TV - Tuvalu</option>
                                <option>TW - Taiwan</option>
                                <option>TZ - Tanzania</option>
                                <option>UA - Ukraine</option>
                                <option>UG - Uganda</option>
                                <option>UM - United States Minor Outlying Islands</option>
                                <option>US - United States</option>
                                <option>UY - Uruguay</option>
                                <option>UZ - Uzbekistan</option>
                                <option>VA - Holy See (Vatican City)</option>
                                <option>VC - Saint Vincent and the Grenadines</option>
                                <option>VE - Venezuela</option>
                                <option>VG - British Virgin Islands</option>
                                <option>VI - Virgin Islands</option>
                                <option>VN - Vietnam</option>
                                <option>VU - Vanuatu</option>
                                <option>WF - Wallis and Futuna</option>
                                <option>WS - Samoa</option>
                                <option>XK - Kosovo</option>
                                <option>YE - Yemen</option>
                                <option>YT - Mayotte</option>
                                <option>ZA - South Africa</option>
                                <option>ZM - Zambia</option>
                                <option>ZW - Zimbabwe</option>
                            </select>
                        </div>
                    </div> <!-- /.form-group -->
                    <div class="form-group">
                        <label class="control-label col-sm-3">Gender</label>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-4">
                                    <label class="radio-inline">
                                        <input type="radio" id="femaleRadio" value="Female">Female
                                    </label>
                                </div>
                                <div class="col-sm-4">
                                    <label class="radio-inline">
                                        <input type="radio" id="maleRadio" value="Male">Male
                                    </label>
                                </div>
                                <div class="col-sm-4">
                                    <label class="radio-inline">
                                        <input type="radio" id="uncknownRadio" value="Unknown">Unknown
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div> <!-- /.form-group -->

                    <div class="form-group">
                        <div class="col-sm-9 col-sm-offset-3">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox">I accept <a href="#">terms</a>
                                </label>
                            </div>
                        </div>
                    </div> <!-- /.form-group -->
                    <div class="form-group">
                        <div class="col-sm-9 col-sm-offset-3">
                            <button type="submit" class="btn btn-primary btn-block">Register</button>
                        </div>
                    </div>
                </form> <!-- /form -->
            </div>

                <div class="col-md-6">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12">
                                <h2> Features </h2>
                            </div>
                            <div class=" col-sm-6 col-md-4">

                                <div class="thumbnail">
                                    <img src="img/radar.png" alt="socialising">
                                    </a>
                                    <div class="caption">
                                        <h3>Meet your friends</h3>
                                        <p>Join and find your new friends for life</p>
                                    </div>
                                </div>
                            </div>


                            <div class=" col-sm-6 col-md-4">
                                <div class="thumbnail">
                                    <img src="img/party.png" alt="party">
                                    </a>
                                    <div class="caption">
                                        <h3>Are you a party animal?</h3>
                                        <p>Love to party with your friends? Join NOW!</p>
                                    </div>
                                </div>
                            </div>

                            <div class="col-sm-6 col-md-4">
                                <div class="thumbnail">
                                    <img src="img/success.png" alt="succeess">
                                    </a>
                                    <div class="caption">
                                        <h3>Succeed in your career?</h3>
                                        <p>Dream to succeed in your dream job? Dive in!</p>
                                    </div>
                                </div>
                            </div>

                            <div class="col-sm-6 col-md-4">
                                <div class="thumbnail">
                                    <img src="img/communicate.png" alt="communicate">
                                    </a>
                                    <div class="caption">
                                        <h3>BE IN TOUCH!</h3>
                                        <p>Chat with your friends any where, any time!</p>
                                    </div>
                                </div>
                            </div>

                            <div class="col-sm-6 col-md-4">
                                <div class="thumbnail">
                                    <img src="img/success.png" alt="success">
                                    </a>
                                    <div class="caption">
                                        <h3>Be open to the world!</h3>
                                        <p>Connect with others who you want to meet or work with!</p>
                                    </div>
                                </div>
                            </div>

                            <div class="col-sm-6 col-md-4">
                                <div class="thumbnail">
                                    <img src="img/employee.png" alt="employee">
                                    </a>
                                    <div class="caption">
                                        <h3>Boost your company!</h3>
                                        <p>Find the perfect colleagues for your company! JUMP IN!</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

<?php include("inc/footer.inc.php"); ?>