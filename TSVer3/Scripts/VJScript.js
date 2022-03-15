

//GenerateInvoice Page validation
function validate_Invoice_GI1() {
    if (document.getElementById("MainContent_TabContainer1_TabPanel1_ddl_Category").value == "---Select---") {
        alert("Please Select Job Category ");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TabPanel1_tbx_BillNo").value == "") {
        alert("Please Enter Bill No.");
        return false;
    } else if (document.getElementById("MainContent_TabContainer1_TabPanel1_tbx_BillDate").value == "") {
        alert("Please Enter Bill Date");
        return false;
    } else if (document.getElementById("MainContent_TabContainer1_TabPanel1_tbx_InvTo1").value == "") {
        alert("Please Enter To Address");
        return false;
    } else if (document.getElementById("MainContent_TabContainer1_TabPanel1_tbx_SerTax_Total").value == "") {
        alert("Please Enter Service Tax");
        return false;
    } else if (document.getElementById("MainContent_TabContainer1_TabPanel1_tbx_TotalAmt").value == "") {
        alert("Please Enter Total Amount");
        return false;
    } else if (document.getElementById("MainContent_TabContainer1_TabPanel1_tbx_Month").value == "") {
        alert("Please Enter Month");
        return false;
    } else if (document.getElementById("MainContent_TabContainer1_TabPanel1_tbx_Year").value == "") {
        alert("Please Enter Year");
        return false;
    } else if (document.getElementById("MainContent_TabContainer1_TabPanel1_tbx_CurrValue").value == "") {
        alert("Please Enter Currency Value");
        return false;
    }
    //  return true;
}


function validate_Contacts() {
    if (document.getElementById("MainContent_tbx_Name").value == "") {
        alert("Enter your Name");
        return false;
    }
    else if (document.getElementById("MainContent_tbx_email").value == "") {
        alert("Enter your Email-Id");
        return false;
    }
    var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/;
    var emailid = document.getElementById("MainContent_tbx_email").value;
    var matchArray = emailid.match(emailPat);
    if (matchArray == null) {
        alert("Your email address seems incorrect. Please try again.");
        return false;
    }
    var Url = "^[A-Za-z]+://[A-Za-z0-9-_]+\\.[A-Za-z0-9-_%&\?\/.=]+$"
    var digits = "0123456789"; var temp;

    if (document.getElementById("MainContent_tbx_Message").value == "") {
        alert("Enter your Message");
        return false;
    }
    // return true;
}   

      
        function validate_AWB_NAWBNo() {
            if (document.getElementById("MainContent_tbx_NAWBNo").value == "") {
                alert("Enter valid AWB Number test");
                return false;
            }
            return true;
        }

function validate_SR_Date() {
    if (document.getElementById('<%=MainContent_ddl_SearchedData.ClientID%>').selectedIndex == 0) {
        alert("Please select ddl");
        return false;
    }
    if (document.getElementById("MainContent_tbx_FromDate").value == "") {
        alert("From Date can not be blank");
        return false;
    }
    if (document.getElementById("MainContent_tbx_ToDate").value == "") {
        alert("To Date can not be blank");
        return false;
    }
      return true;
  }

 function validate_GenInvoice() {
    if (document.getElementById("MainContent_tbx_BillNo").value == "") {
          alert("Please Enter Bill No.");
        return false;
    }
    else if (document.getElementById("MainContent_tbx_BillDate").value == "") {
          alert("Please Enter Bill Date");
        return false;
    }
}


// AWB Page validation
function validate_Job_Details_AWB() {
    if (document.getElementById("MainContent_TabContainer1_TP_NewJobNo_AWB").value == "") {
        alert("Job Number is required");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Newtbx_AWB").value == "") {
        alert("Master AWB No. is required");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Newtbx_AirlineName").value == "") {
        alert("Airway Bill Issued By required");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Newtbx_Shipper_l1").value == "") {
        alert("Shipper Name is required");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Newtbx_Consignee_l1").value == "") {
        alert("Consignee Name is required");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Newtbx_CarriersAgent_l1").value == "") {
        alert("Carriers Agent Name is required");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Newtbx_Origin").value == "") {
        alert("Airport of Departure is required");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Newtbx_Line1Code").value == "") {
        alert("First Carrier is required");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Newtbx_DestName").value == "") {
        alert("Airport of Destination is required");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Newtbx_Pieces").value == "") {
        alert("No. of Pieces is required");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Newtbx_GrossWeight").value == "") {
        alert("Gross Weight is required");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Newtbx_ChargeableWeight").value == "") {
        alert("Chargeable Weight is required");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Newtbx_Rate").value == "") {
        alert("Rate/Charge is required");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Newtbx_Nature").value == "") {
        alert("Nature & Quantity of goods is required");
        return false;
    }
    return true;
}

//HAWB Page
function validate_HAWB() {
    if (document.getElementById("MainContent_TC1_TP1_tbx_NAWBNo").value == "") {
        alert("Enter valid AWB Number");
        return false;
    }
    return true;
}
function validate_Insert_HAWB() {
    if (document.getElementById("MainContent_TC1_TP1_JobNo_AWB").value == "") {
        alert("Enter Job No");
        return false;
    }
    else if (document.getElementById("MainContent_TC1_TP1_tbx_HAWB").value == "") {
        alert("Enter Airway Bill No");
        return false;
    }
    return true;
}
function validate_Update_HAWB() {
    if (document.getElementById("MainContent_TC1_TP1_JobNo_AWB").value == "") {
        alert("Enter Job No");
        return false;
    }
    else if (document.getElementById("MainContent_TC1_TP1_tbx_HAWB").value == "") {
        alert("Enter Airway Bill No");
        return false;
    }
    return true;
}

//Air Job Page
function validate_insert_Air() {
    if (document.getElementById("MainContent_TabContainer1_TP_New_tbx_JobNo").value == "") {
        alert("Enter Valid Job Number");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_New_tbx_sname_l1").value == "") {
        alert("Choose Shipper Name");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_New_tbx_cname_l1").value == "") {
        alert("Choose Consignee Name");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_New_tbx_carriersagent_l1").value == "") {
        alert("Choose Carriers Agent");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_New_ddl_ClientName").value == "---Select---") {
        alert("Choose Client Name");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_New_tbx_from").value == "") {
        alert("Enter Origin");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_New_tbx_To").value == "") {
        alert("Enter Destination");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_New_tbx_sname_l1").value == "") {
        alert("Enter Shipper Name");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_New_tbx_gweight").value == "") {
        alert("Enter Gross Weight");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_New_tbx_nature").value == "") {
        alert("Enter Nature of Goods");
        return false;
    }
    return true;
}

function validate_edit_Air() {
    if (document.getElementById("MainContent_TabContainer1_TP_Edit_Etbx_JobNo").value == "") {
        alert("Enter Valid Job Number");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Edit_Etbx_sname_l1").value == "") {
        alert("Choose Shipper Name");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Edit_Etbx_cname_l1").value == "") {
        alert("Choose Consignee Name");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Edit_Etbx_carriersagent_l1").value == "") {
        alert("Choose Carriers Agent");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Edit_Eddl_ClientName").value == "---Select---") {
        alert("Choose Client Name");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Edit_Etbx_from").value == "") {
        alert("Enter Origin");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Edit_Etbx_To").value == "") {
        alert("Enter Destination");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Edit_Etbx_gweight").value == "") {
        alert("Enter Gross Weight");
        return false;
    }
    else if (document.getElementById("MainContent_TabContainer1_TP_Edit_Etbx_nature").value == "") {
        alert("Enter Nature of Goods");
        return false;
    }
    return true;
}

//Shipper Invoice Page validation
function validate_Invoice_SI1() {
    if (document.getElementById("MainContent_TC_SI_TPNew_tbx_InvoiceNo").value == "") {
        alert("Please Enter Invoice No.");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_sname_l1").value == "") {
        alert("Please Enter Exporter Name");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_cname_l1").value == "") {
        alert("Please Enter Consignee Name");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_from").value == "") {
        alert("Please Enter Place of Receipt(Origin)");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_POL").value == "") {
        alert("Please Enter Port of Loading");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_OrgCountry").value == "") {
        alert("Please Enter Country of Origin");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_DestCountry").value == "") {
        alert("Please Enter Country of Final Destination");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_POD").value == "") {
        alert("Please Enter Port of Discharge");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_To").value == "") {
        alert("Please Enter Final Destination");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_gweight").value == "") {
        alert("Please Enter Gross Weight");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_TotalAmt").value == "") {
        alert("Please Enter Total Amount");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_ddl_Currency").value == "---Select Currency---") {
        alert("Please Select Currency");
        return false;
    }
    //  return true;
}

//Packing List Page validation
function validate_Invoice_PL1() {
    if (document.getElementById("MainContent_TC_SI_TPNew_tbx_InvoiceNo").value == "") {
        alert("Please Enter Invoice No.");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_sname_l1").value == "") {
        alert("Please Enter Exporter Name");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_cname_l1").value == "") {
        alert("Please Enter Consignee Name");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_from").value == "") {
        alert("Please Enter Place of Receipt(Origin)");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_POL").value == "") {
        alert("Please Enter Port of Loading");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_OrgCountry").value == "") {
        alert("Please Enter Country of Origin");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_DestCountry").value == "") {
        alert("Please Enter Country of Final Destination");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_POD").value == "") {
        alert("Please Enter Port of Discharge");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_To").value == "") {
        alert("Please Enter Final Destination");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_gweight").value == "") {
        alert("Please Enter Gross Weight");
        return false;
    } else if (document.getElementById("MainContent_TC_SI_TPNew_tbx_TotalAmt").value == "") {
        alert("Please Enter Total Amount");
        return false;
    }
    //  return true;
}