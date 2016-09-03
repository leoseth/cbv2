
///////  this is for car keypress  ///////

$('input[type="text"]').keydown(function (event){
    if (window.event.keyCode == 13){
        event.preventDefault();
        return false;
    }
});

$('input[type="Date"]').keydown(function (event){
    if (window.event.keyCode == 13){
        event.preventDefault();
        return false;
    }
});

function platenum(up1){             
    if (window.event.keyCode == "40"){
        document.getElementById('txtmake').focus();
    }
    if (window.event.keyCode =="13"){   
        document.getElementById('txtmake').focus();
    }
}         

function make(up2){
    if (window.event.keyCode == "38"){
        document.getElementById('txtplatenumber').focus();
    }
    if (window.event.keyCode == "40"){
        document.getElementById('txtmodel').focus();
    }
    if (window.event.keyCode == 13){
        document.getElementById('txtmodel').focus();
    }
}

function model(up3){           
    document.getElementById('lblregisnumval').style.display = "inherit"

    if (window.event.keyCode == "38"){
        document.getElementById('txtmake').focus();
    }
    if (window.event.keyCode == "40"){
        document.getElementById('txtregisnum').focus();
    }
    if (window.event.keyCode==13){
        document.getElementById('txtregisnum').focus();
    }
}

function regisnum(up4){
    if (window.event.keyCode == "38"){
        document.getElementById('txtmodel').focus();
    }

    if (window.event.keyCode == "40"){
        var car_edt = document.getElementById('caredited')['value'].trim();
        if (car_edt == "edited") {
            document.getElementById('txtrgdate2').focus();
        }else{
            document.getElementById('txtrgdate').focus();
        }
    }

    if(window.event.keyCode=="13"){                  
        var car_edt = document.getElementById('caredited')['value'].trim();
        if (car_edt == "edited"){
            document.getElementById('txtrgdate2').focus();
        }                      
        if (car_edt == "not" || car_edt == ""){
            document.getElementById('txtrgdate').focus();
        }        
    }
}

function makeupper() {
    var makeappr = document.getElementById('txtmake').value.toUpperCase();
    document.getElementById('txtmake')['value'] = makeappr;
}

function modelupper() {
    var modelappr = document.getElementById('txtmodel').value.toUpperCase();
    document.getElementById('txtmodel')['value'] = modelappr;
}

function registoupper(){
    var regis = document.getElementById('txtregisnum').value.toUpperCase();
    document.getElementById('txtregisnum')["value"] = regis;
}

function colortoupper() {
    var colorappr = document.getElementById('txtcolor').value.toUpperCase();
    document.getElementById('txtcolor')['value'] = colorappr;
}

function engnumtoupper() {
    var cnvenginenum = document.getElementById('txtenginenum').value.toUpperCase();
    document.getElementById('txtenginenum')['value'] = cnvenginenum;
}

function rgdate(up5){                    
    if (window.event.keyCode == "38"){
        document.getElementById('txtregisnum').focus();
    }
    if (window.event.keyCode == "40"){
        document.getElementById('txtcolor').focus();
    }
    if (window.event.keyCode==13){
        document.getElementById('txtcolor').focus();
    }
}

function color(up7){                 
    if (window.event.keyCode == "38"){
        var car_edt = document.getElementById('caredited')['value'].trim();
         if (car_edt == 'edited') {
                document.getElementById('txtrgdate2').focus();
            } else {
                document.getElementById('txtrgdate').focus();
            }
    }

    if (window.event.keyCode == "40"){
        document.getElementById('txtchasisnum').focus();
    }
    if (window.event.keyCode==13){
        document.getElementById('txtchasisnum').focus();
    }
}

function chasisnum(up8){
        document.getElementById('skipload')["value"] = "skip_load";
        document.getElementById('hiddenclick')["value"] = "txtenginenum"; 

        if (window.event.keyCode == "38"){
            document.getElementById('txtcolor').focus();
        }
        if (window.event.keyCode == "40"){
            document.getElementById('txtenginenum').focus();
        }
        if (window.event.keyCode==13){
            Funcenginenum();
            document.getElementById('txtenginenum').focus();                     
        }
}

function convertchasisnum(){
    var cnvchasisnum = document.getElementById('txtchasisnum').value.toUpperCase();
    document.getElementById('txtchasisnum')["value"] = cnvchasisnum;
}

function GetKeyCodeplatenum(evt){
        if (evt.keyCode > 12 && evt.keyCode <= 13){
            document.getElementById('txtmake').focus();
        }
}

function Getkeycodemodel(){
    document.getElementById('lblregisnumval').style.display ="inherit"
}

function pressplatenum(){                 
    document.getElementById('Textlog2').style.display ="none"
}

function converttouppercase(){                
    var i = document.getElementById('txtplatenumber').value.toUpperCase();
    document.getElementById('txtplatenumber')["value"] = i;
}
            
function enginenum(up9) {
        $('input[type="text"]').keydown(
         function (event) {
             if (event.keyCode == 13) {                 
                 document.getElementById('btncarsave').focus();
             }
         });

        if (window.event.keyCode == "38") {
            document.getElementById('txtchasisnum').focus();
        }                                
}
         
function sviewplatenum(){
        $('input[type="text"]').keyup(function (event){
            if (window.event.keyCode>=65 && window.event.keyCode<=90){
                var skip = document.getElementById('skipload')["value"] = "skip_load";
                document.getElementById('btnsearchviewplatenum').click();
                return true;
            }

            if (window.event.keyCode == 40){
                document.getElementById('ListBoxview').focus();
            }

            if (window.event.keyCode == 13){
                var skip = document.getElementById('skipload')["value"] = "skip_load";
                document.getElementById('btnsearchviewplatenum').click();
                return true;
            }                     
        });
}

function seditplatenum() {
    $('input[type="text"]').keyup(function (event){
        if (window.event.keyCode >= 65 && window.event.keyCode <= 90){
            var skip = document.getElementById('skipload')["value"] = "skip_load";
            document.getElementById('btntxtsearcheplatenum').click();
            return true;
        }

        if (window.event.keyCode == 40){
            document.getElementById('Listedit').focus();
        }

        if (event.keyCode == 13){
            var skip = document.getElementById('skipload>')["value"] = "skip_load";
            document.getElementById('btntxtsearcheplatenum').click();
            return true;
        }
    });
} 
//////   this is for car keypress  ///////