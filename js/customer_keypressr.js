
//// this is for customer keypress  /////

function keyUP(){
   var connect = document.getElementById('sdt');
   connect.click();
}
                   
function GetKeyCode(evt){
   var keyCode; 
   if (evt.keyCode >= 48 && evt.keyCode < 58){
       if (document.getElementById('txttelno').value.length >= 10) {                                 
           if (document.getElementById('txttelno')['value'].substring(0, 1) != "(") {
                    alert('you have exceeded the 10 digits limit, please re-type');

                    vtelephonestr = document.getElementById('txttelno')['value'];
                    document.getElementById('txttelno')['value'] = "";

                    document.getElementById('txttelno')['value'] = vtelephonestr.slice(-11,-1);

                    document.getElementById('txttelno').focus();
            }
       }
            else {
                    keyCode = evt.keyCode;
                 }                               
   }
   else if (typeof (evt.charCode) != "undefined"){
           if (evt.keyCode != 13){                                               
              keyCode = evt.charCode;
              alert("Invalid, because this is a numeric data type please re-type");
           }
   }          
}
    
function getkeypressed(evt){
    var keyCode; 
    if (evt.keyCode >= 65 && evt.keyCode < 123 || evt.keyCode == 46){
        keyCode = evt.keyCode;
    }
    else if (typeof (evt.charCode) != "undefined"){
         if (evt.keyCode != 13){
             keyCode = evt.charCode;
             alert("Invalid data type, please re-type");
         }
    } 
}

function convertlast(){
    var cnvlast = document.getElementById('txtlastname').value.toUpperCase();
    document.getElementById('txtlastname')["value"] = cnvlast;
}                                                      

    $('input[type="text"]').keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });

$('input[type="Date"]').keydown(function (event) {
    if (event.keyCode == 13) {
        event.preventDefault();
        return false;
    }
});                  

function txtOnKeyPress2(txt3){                           
    if (txt3 != 'undefined'){
        if (window.event.keyCode == "38"){
            txt4 = document.getElementById('customtype').focus();
        }
        if (window.event.keyCode == "40"){
            txt4 = document.getElementById('txtlastname').focus();
        }
        if (window.event.keyCode == "13"){
            document.getElementById('txtlastname').focus();
        }
    }
}

function convertidnumber() {
    var cnvidnumber = document.getElementById('txtidnumber').value.toUpperCase();
    document.getElementById('txtidnumber')["value"] = cnvidnumber;
}

function covertcompname(){
    var vccompname = document.getElementById('txtcompname').value.toUpperCase();
    document.getElementById('txtcompname')["value"] = vccompname;
}

function txtOnKeyPress3(txt4){                         
    if (txt4 != 'undefined'){
        if (window.event.keyCode == "38"){
            txt5 = document.getElementById('txtcompname').focus();
        }
        if (window.event.keyCode == "40"){
            txt5 = document.getElementById('txtfirstname').focus();
            txtfirstfocus();
        }
    }

    if (window.event.keyCode == 13){
        document.getElementById('txtfirstname').focus();
        txtfirstfocus();
    }
}

function convertfirst(){
    var cnvfirst = document.getElementById('txtfirstname').value.toUpperCase();
    document.getElementById('txtfirstname')["value"] = cnvfirst;
}

function convertaddress(){
    var cnvaddr = document.getElementById('txtaddress').value.toUpperCase();
    document.getElementById('txtaddress')["value"] = cnvaddr;
}

function txtOnKeyPress4(txt6){                           
    if (txt6 != 'undefined'){
        if (window.event.keyCode == "38"){
            txt7 = document.getElementById('txtlastname').focus();
        }
        if (window.event.keyCode == "40"){
            txt7 = document.getElementById('txtmiddlename').focus();
            txtmiddlefocus();
        }
    }
    if(window.event.keyCode==13){
        document.getElementById('txtmiddlename').focus();
        txtmiddlefocus();
    }
}

function txtOnKeyPress5(txt8){                           
    if (window.event.keyCode == "38"){
        txt9 = document.getElementById('txtfirstname').focus();
    }
    if (window.event.keyCode == "40"){
        txt9 = document.getElementById('txtaddress').focus();
        txtaddressfocus();
    }
    if (window.event.keyCode==13){
        document.getElementById('txtaddress').focus();
        txtaddressfocus();
    }
}

function convertmiddle(){
    var cnvmiddle = document.getElementById('txtmiddlename').value.toUpperCase();
    document.getElementById('txtmiddlename')["value"] = cnvmiddle;
}

function txtOnKeyPress6(txt10){
    document.getElementById('lbltel').style.display = 'inherit';
    if (window.event.keyCode == "38"){
        txt11 = document.getElementById('txtmiddlename').focus();
        txttelnofocus();
    }
    if (window.event.keyCode == "40"){
        txt11 = document.getElementById('txttelno').focus();                                
        txttelnofocus();
    }
}

function txtOnKeyPress7(txt12){                            
    if (window.event.keyCode == "38"){
        txt13 = document.getElementById('txtaddress').focus();
    }
    if (window.event.keyCode == "40"){                                
        vtelstr3 = document.getElementById('txttelno')['value'];

        if (document.getElementById('txttelno').value.length < 7){
            alert('invalid input, your lower than 7 digits please double check');
            document.getElementById('txttelno').focus()
        }
        else{
            if (document.getElementById('txttelno').value.length == 7){

                vtelstrcom2 = vtelstr3.slice(-7, -4);
                vtelstrcom3 = vtelstr3.substring(document.getElementById('txttelno').value.length - 4);
                document.getElementById('txttelno')['value'] = "("+"   "+")" + "-" + vtelstrcom2 +"-"+ vtelstrcom3;
                document.getElementById('txtmobilenum').focus();
            }

            if (document.getElementById('txttelno').value.length == 8){

                vtelstrcom1 = vtelstr3.slice(-10, -7);
                vtelstrcom2 = vtelstr3.slice(-7, -4);
                vtelstrcom3 = vtelstr3.slice(-4);

                document.getElementById('txttelno')['value'] = "(" + "  " + vtelstrcom1 + ")" + "-" + vtelstrcom2 + "-" + vtelstrcom3;
                document.getElementById('txtmobilenum').focus();
            }

            if (document.getElementById('txttelno').value.length == 9){

                vtelstrcom1 = vtelstr3.slice(-10, -7);
                vtelstrcom2 = vtelstr3.slice(-7, -4);
                vtelstrcom3 = vtelstr3.slice(-4);

                document.getElementById('txttelno')['value'] = "("+ " " + vtelstrcom1 + ")" + "-" + vtelstrcom2 + "-" + vtelstrcom3;
                document.getElementById('txtmobilenum').focus();
            }

            if (document.getElementById('txttelno').value.length == 10){

                vtelstrcom1 = vtelstr3.slice(-10, -7);
                vtelstrcom2 = vtelstr3.slice(-7, -4);
                vtelstrcom3 = vtelstr3.slice(-4);

                document.getElementById('txttelno')['value'] = "("+ vtelstrcom1 +")" + "-" + vtelstrcom2 + "-" + vtelstrcom3;
                document.getElementById('txtmobilenum').focus();
            }
            txtmobilenumfocus();
        }
    }
    if (window.event.keyCode == 13)
    {                                
        vtelstr3 = document.getElementById('txttelno')['value'];

        if (document.getElementById('txttelno').value.length < 7){
            alert('invalid input, your lower than 7 digits please double check');
            document.getElementById('txttelno').focus()
        }
        else {
            if (document.getElementById('txttelno').value.length == 7){

                vtelstrcom2 = vtelstr3.slice(-7, -4);
                vtelstrcom3 = vtelstr3.substring(document.getElementById('txttelno').value.length - 4);
                document.getElementById('txttelno')['value'] = "("+"   "+")" + "-" + vtelstrcom2 +"-"+ vtelstrcom3;
                document.getElementById('txtmobilenum').focus();
            }

            if (document.getElementById('txttelno').value.length == 8){

                vtelstrcom1 = vtelstr3.slice(-10, -7);
                vtelstrcom2 = vtelstr3.slice(-7, -4);
                vtelstrcom3 = vtelstr3.slice(-4);

                document.getElementById('txttelno')['value'] = "(" + "  " + vtelstrcom1 + ")" + "-" + vtelstrcom2 + "-" + vtelstrcom3;
                document.getElementById('txtmobilenum').focus();
            }

            if (document.getElementById('txttelno').value.length == 9){

                vtelstrcom1 = vtelstr3.slice(-10, -7);
                vtelstrcom2 = vtelstr3.slice(-7, -4);
                vtelstrcom3 = vtelstr3.slice(-4);

                document.getElementById('txttelno')['value'] = "("+ " " + vtelstrcom1 + ")" + "-" + vtelstrcom2 + "-" + vtelstrcom3;
                document.getElementById('txtmobilenum').focus();
            }

            if (document.getElementById('txttelno').value.length == 10){

                vtelstrcom1 = vtelstr3.slice(-10, -7);
                vtelstrcom2 = vtelstr3.slice(-7, -4);
                vtelstrcom3 = vtelstr3.slice(-4);
         
                document.getElementById('txttelno')['value'] = "("+ vtelstrcom1 +")" + "-" + vtelstrcom2 + "-" + vtelstrcom3;
                document.getElementById('txtmobilenum').focus();
            }
        }
        txtmobilenumfocus();
    }
}

function txtOnKeyPress8(txt14){                            
    if (window.event.keyCode == "38"){
        txt15 = document.getElementById('txttelno').focus();
    }
    if (window.event.keyCode == "40"){
        txt15 = document.getElementById('txtemailadd').focus();
        txtemailaddfocus();
    }
    if (window.event.keyCode == 13){
        document.getElementById('txtemailadd').focus();
        txtemailaddfocus();
    }
}

function txtOnKeyPress9(txt16){
    if (window.event.keyCode == "38"){
        txt17 = document.getElementById('txtmobilenum').focus();
    }
    if (window.event.keyCode == "40"){
        if (document.getElementById('edit2')['value'] =="EDIT"){
            txt17 = document.getElementById('txtbirthday2').focus();
            txtbirthdayfocus2();
        }
        if (document.getElementById('edit2')['value'] == ""){
            txt17 = document.getElementById('txtbirthday').focus();
            txtbirthdayfocus();
        }
    }
    if (window.event.keyCode == "13"){
        if (document.getElementById('edit2')['value'] == "EDIT"){
            document.getElementById('txtbirthday2').focus();
            txtbirthdayfocus2();
        }
        if (document.getElementById('edit2')['value'] == ""){
            if (document.getElementById('txtbirthplace')['value'] != "") {                                          
                var n = document.getElementById('no_option')['value'];
                if(n=='cancelled'){
                    document.getElementById('no_option')['value'] = "";
                    document.getElementById('txtbirthday').focus();
                    txtbirthdayfocus();
                } else{
                    document.getElementById('no_option')['value'] = "";
                    document.getElementById('txtbirthday2').focus();
                    txtbirthdayfocus2();
                }
            } else {
                document.getElementById('txtbirthday').focus();
                txtbirthdayfocus();
            }                               
        }
    }
}

function txtOnKeyPress10(txt18){
    if (window.event.keyCode == "38"){
        txt19 = document.getElementById('txtemailadd').focus();
    }
    if (window.event.keyCode == "40"){
        txt19 = document.getElementById('txtbirthplace').focus();
        txtbirthplacefocus();
    }
    if (window.event.keyCode == "13"){
        txt19 = document.getElementById('txtbirthplace').focus(); 
        txtbirthplacefocus();
    }
}
                        
function txtOnKeyPress11(txt20){                            
    if (window.event.keyCode == "38"){
        if (document.getElementById('edit2')['value']=="EDIT"){
            txt21 = document.getElementById('txtbirthday2').focus();
        }
        if (document.getElementById('edit2')['value'] == ""){
            txt21 = document.getElementById('txtbirthday').focus();
        }
    }
    if (window.event.keyCode == "40"){
        txt21 = document.getElementById('txtnationality').focus();
        txtnationalityfocus();
    }
    if (window.event.keyCode==13){
        document.getElementById('txtnationality').focus();
        txtnationalityfocus();
    }
}

function convertbirthplace(){
    var cnvbirthplace = document.getElementById('txtbirthplace').value.toUpperCase();
    document.getElementById('txtbirthplace')["value"] = cnvbirthplace;
}

function txtOnKeyPress12(txt22){                            
    if (window.event.keyCode == "38"){
        txt21 = document.getElementById('txtbirthplace').focus();
    }
    if (window.event.keyCode == "40"){
        txt21 = document.getElementById('sidtype').focus();
        sidtypefocus();
    }
    if (window.event.keyCode==13){
        document.getElementById('sidtype').focus();
        sidtypefocus();
    }
}

function convertnational(){
    var cntnational = document.getElementById('txtnationality').value.toUpperCase();
    document.getElementById('txtnationality')["value"] = cntnational;
}
         
function txtOnKeyPress13(txt22){
    document.getElementById('skipload')["value"] = "skip_load";
    document.getElementById('hiddenclick')["value"] = "txtidnumber";
    if (window.event.keyCode == "38"){
        txt23 = document.getElementById('txtnationality').focus();
    }
    if (window.event.keyCode == "40"){
        txt23 = document.getElementById('txtidnumber').focus();
    }
    if (window.event.keyCode=="13"){
        document.getElementById('txtidnumber').focus();     
        Funcidnumber();
    }
}

function notify(){
    var snd = new Audio("alert/notify.wav");
    snd.play();

    document.getElementById('hiddenfieldrfid')["value"] = "";

    var carref = document.getElementById("carrefdropdownlist").value;
    document.getElementById("carrefhidden").value = carref;

    var vclick = document.getElementById("btncaref2");
    vclick.click();
}

function sendSMStone(){
    var smstone = new Audio("alert/notify.wav");
    smstone.play();
}                      
                            
    function txtOnKeyPress14(txt24){
        var x_var ="empty";
        $('input[type="text"]').keydown(function (event) {
            if (event.keyCode == 13) {
                x_var = "confirmed";

                confirmation();
                return false;                                            
            }

            if (window.event.keyCode == 13) {
                if (hiddenclick.Value != "txtidnumber") {
                    fsidtype();
                }
                else {
                    if (document.getElementById('confirmed')['value'] = "yes") {
                        var vclick2 = document.getElementById('Button2');
                        vclick2.click();
                    }
                }
            }

            if (window.event.keyCode == "38") {
                txt25 = document.getElementById('sidtype').focus();
            }
        });

        if (window.event.keyCode == 13) {
            if (x_var == "empty") {
                       document.getElementById('id_true').focus();
                       document.getElementById('confirmed')['value'] = "yes";
                       document.getElementById('no_option').value = "";
                       var vclick3 = document.getElementById('Button2');
                       vclick3.click();
                }
        }

        function confirmation() {
            document.getElementById('id_true').focus();                                    
            return false;
        }
    }
                    
function Submit(){                           
     var varhidden = document.getElementById('Hiddenfield_car')["value"];

     document.getElementById('skipload')["value"] = "";
     var edit = document.getElementById('HiddenField_edit')["value"]
     var confirmation = window.confirm("Are you sure you want to " + edit + " this record?");

     if (varhidden == "car"){
         document.getElementById("carfield")["value"] = confirmation;
         return true;
     }
     else{
         document.getElementById("HiddenField1")["value"] = confirmation;
         return true;
     }
}

function clickseacrh(){
    customertype.focus();
}

function jsFunction(value){
    document.getElementById('txtsearch').focus();
    txtsearch.value = "";
}

function fcustomtype(){
    if (customtype.value == 'Individual'){
        var a = document.getElementById('txtcompname');
        a.disabled = true;
        document.getElementById('txtlastname').focus();
    }
    if (customtype.value == 'Company'){
        var a = document.getElementById('txtcompname');
        a.disabled = false;
        document.getElementById('txtcompname').focus();
    }
} 

function fsidtype(){
    document.getElementById('txtidnumber').focus();
}

function SQLconnect(){    
    var carref = document.getElementById("carrefdropdownlist").value;
    document.getElementById("carrefhidden").value = carref;

    var vclick = document.getElementById("btncaref");
    vclick.click();
}

function connectRFID_code(){
    document.getElementById('hiddenfieldrfid')["value"] = "";

    var carref = document.getElementById("carrefdropdownlist").value;
    document.getElementById("carrefhidden").value = carref;

    var vclick = documett.getElementById("btncaref2");
    vclick.click();
}
 
function searchtext(event) { /// this is subject for research
    $('input[type="text"]').keyup(function (event){
      if (window.event.keyCode>=65 && window.event.keyCode<=90){
          var skip = document.getElementById('skipload')["value"] = "skip_load";
          document.getElementById('btnpaneltxtsearch').click();

          event.preventDeeventfault();
          return true;                                                                                                 
      }     

      if (window.event.keyCode == "13"){
          var skip = document.getElementById('skipload')["value"] = "skip_load";
          document.getElementById('btnpaneltxtsearch').click();
      }

      if (window.event.keyCode == "40") {
          if (document.getElementById('edit2')['value'] == "EDIT") {
              if (document.getElementById('Listedit').style.display = "inherit") {
                  document.getElementById('Listedit').focus();
              }
          }
          if (document.getElementById('edit2')['value'] == "POPULATE") {
              if (document.getElementById('ListBoxview').style.display = "inherit") {
                  document.getElementById('ListBoxview').focus();
              }
          }
      }
    });
}

function rfid2func(event){
    document.getElementById('txtrfid')['value'] = document.getElementById('txtrfid2')['value'];
    if (document.getElementById('txtrfid2').value.length >= 10) {
        document.getElementById('txtrfid2')['value']="";
        txtOnKeyPress();
    }
};

 
function dummyfunction(){
    document.getElementById('lblline3');
}            

function carrefdropdown() {   
    document.getElementById('carrefdropdownlist').innerText = "";

    document.getElementById('transactionlistbox').style.display = 'none';
    document.getElementById('labelranslist').style.display = 'none';
    document.getElementById('labeltransactdate').style.display = 'none';
    document.getElementById('labeltransactnum').style.display = 'none';
    document.getElementById('labelinvoicenum').style.display = 'none';
    document.getElementById('labelservice').style.display = 'none';
    document.getElementById('labelservtype').style.display = 'none';
    document.getElementById('labelwarstatus').style.display = 'none';
    document.getElementById('labelmainschedule').style.display = 'none';
    document.getElementById('labelmainduedate').style.display = 'none';
    document.getElementById('labelsearchtransactnum1').style.display = 'none';
    document.getElementById('labelsearchtransactnum2').style.display = 'none';

    document.getElementById('lblinvoicenum').style.display = 'inherit';
    document.getElementById('txtinvoicenum').style.display = 'inherit';
    document.getElementById('lbltransacnum').style.display = 'inherit';
    document.getElementById('txttransacnum').style.display = 'inherit';
    document.getElementById('lbltrandate').style.display = 'inherit';
    document.getElementById('txttrandate').style.display = 'inherit';
    document.getElementById('lblservice').style.display = 'inherit';
    document.getElementById('cmbservice').style.display = 'inherit';
    document.getElementById('lbltypeofserv').style.display = 'inherit';
    document.getElementById('cmbtypeofserve').style.display = 'inherit';
    document.getElementById('lblwarstat').style.display = 'inherit';
    document.getElementById('cmbwarstat').style.display = 'inherit';
    document.getElementById('lblwarexpire').style.display = 'inherit';
    document.getElementById('txtwarexpire').style.display = 'inherit';
    document.getElementById('lblmainsched').style.display = 'inherit';
    document.getElementById('mainscheddropdown').style.display = 'inherit';
    document.getElementById('lblmaindue').style.display = 'inherit';
    document.getElementById('txtmaindue').style.display = 'inherit';
    document.getElementById('lblsmsmess').style.display = 'inherit';
    document.getElementById('txtsmsmess').style.display = 'inherit';
    document.getElementById('lblservde').style.display = 'inherit';
    document.getElementById('txtservde').style.display = 'inherit';
    document.getElementById('transadd').style.display = 'inherit';
    document.getElementById('transedit').style.display = 'inherit';
    document.getElementById('transdelete').style.display = 'inherit';

    document.getElementById('lbltransactionlib').style.display = 'inherit';

    document.getElementById('lbleditcustid').style.display = 'none';
    document.getElementById('lblname').style.display = 'none';
    document.getElementById('lbledit').style.display = 'none';
    document.getElementById('lblfirst').style.display = 'none';
    document.getElementById('lblsearch').style.display = 'none';
    document.getElementById('customertype').style.display = 'none';
    document.getElementById('txtsearch').style.display = 'none';

    document.getElementById('Listedit').style.display = 'none';

    document.getElementById('ListBoxview').style.display = 'none';

    document.getElementById('lblcarinfo').style.display = 'none';
    document.getElementById('labelplatenum').style.display = 'none';
    document.getElementById('labelmake').style.display = 'none';
    document.getElementById('labelmodel').style.display = 'none';

    document.getElementById('lblplatesearch').style.display = 'none'
    document.getElementById('txtsearchplatenum').style.display = 'none'
    document.getElementById('lblsearch').style.display = 'none'

    document.getElementById('labelregnum').style.display = 'none';
    document.getElementById('labelcolor').style.display = 'none';
    document.getElementById('labelchasisnum').style.display = 'none';

    document.getElementById('lblsearchviewplatenum').style.display = 'none';
    document.getElementById('txtserchviewplatenum').style.display = 'none';

    document.getElementById('lblcarrefernces').style.display = 'inherit';
    document.getElementById('carrefdropdownlist').style.display = 'inherit';
    document.getElementById('Label2').style.display = 'inherit';
    vtranslistcnt = 0;
    return;
}

function mssgrfid() {
    document.getElementById('carrefdropdownlist').innerText = "";
                
    alert('This RFID CODE exist in the database, please re-type and use a different rfid ');
    document.getElementById('txtrfid')['value'] = "";             
    return;               
}

function carrefdrop() {
    document.getElementById('carrefdropdownlist').innerText = "";
}            
            
      
$(document).ready(function () {
    $(document.getElementById('form1')).mouseenter(function (){
        if (document.getElementById('txtrfid')['value'] == "") {
            if (document.getElementById('Listedit').style.display == "none" && document.getElementById('ListBoxview').style.display == "none") {
                document.getElementById('txtrfid2').focus();
            }
        }
    });              
});

function Grfid2Code(evt){
    var keyCode;
    if (evt.keyCode >= 48 && evt.keyCode < 58) {                   
    }
    else if (typeof (evt.charCode) != "undefined"){
        if (evt.keyCode != 13) {                        
            alert("Invalid input");
            document.getElementById('txtrfid2')['value'] = "          "
            execScript;                       
        }
    }
}

//// this is for customer keypress  /////
