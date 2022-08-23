function changeToVisible( inMsgText ) {
    alert(inMsgText);
//    obj = document.getElementById("msgLbl");
//    obj.innerHTML = inMsgText;

//    obj = document.getElementById("popup");
//    obj.style.visibility = (obj.style.visibility == 'visible') ? 'hidden' : 'visible';
//    obj.style.height = (obj.style.visibility == 'visible') ? '100%' : '0%';

//    obj = document.getElementById("msgLayer");
//    obj.style.visibility = (obj.style.visibility == 'visible') ? 'hidden' : 'visible';
//    obj.style.height = (obj.style.visibility == 'visible') ? '100%' : '0%';

//    if (document.body.scrollHeight && navigator.appVersion.indexOf("Win") != -1) {
//        document.getElementById('popUp').style.height = document.body.scrollHeight;
//    }
//    else if (document.documentElement.scrollHeight) {
//        document.getElementById('popUp').style.height = document.documentElement.scrollHeight;
//    }
//    else if (document.documentElement.offsetHeight) {
//        document.getElementById('popUp').style.height = document.documentElement.offsetHeight;
//    }
}

function setPosition(obj) {
    x = 0;
    y = 0;
    obj = document.getElementById(obj);

    if (document.documentElement) {
        posLeft = document.documentElement.scrollLeft;
        posTop = (document.all) ? document.body.scrollTop : window.pageYOffset;
    }
    else if (document.body) {
        theLeft = document.body.scrollLeft;
        theTop = (document.all) ? document.body.scrollTop : window.pageYOffset;
    }

    posLeft += x;
    posTop += y;
    obj.style.left = posLeft + 'px';
    obj.style.top = posTop + 'px';

    setTimeout("setPosition('layer1')", 1);
}

function scrollPopUp() {
    setTimeout("setPosition('layer1')", 1);
}

function DisableRightClick(event) {
    //For mouse right click 
    if (event.button == 2) {
        alert("Right Click functionality is disabled!");
    }
}

function DisableCtrlKey(e) {
    var code = (document.all) ? event.keyCode : e.which;
    var message = "Ctrl key functionality is disabled!";
    // look for CTRL key press
    if (parseInt(code) == 17) {
        alert(message);
        window.event.returnValue = false;
    }
}

function RHCMsg(item) {
    if (item.get_selectedItem().get_value() == 'RH') {
        alert('If the Rural Health Clinic (RHC) to be added is an extension to an existing hospital then the addition of the RHC must be performed via the Main hospitals licensing process.');
    }
}

/* 
    inRO - bool
    inElem - Object (HTML Element)
    inSetChildren - bool
    
    "noDisable" within id field check in the begining will keep specified control and 
    child controls from being evaluated
*/
function ChangeCtrlRO(inRO, inElem, inSetChildren) {
    with (inElem) {
        if (!(Object.prototype.hasOwnProperty.call(inElem, "id") && id.indexOf("noDisable") > 0)) {

            if ("INPUT" == nodeName.toUpperCase() || "TEXTAREA" == nodeName.toUpperCase()) {
                if ("CHECKBOX" == type.toUpperCase() || "SUBMIT" == type.toUpperCase() || "RESET" == type.toUpperCase() ){ // || "BUTTON" == type.toUpperCase()) {
                    disabled = inRO;
                    //className = inRO ? className + " readOnlyInput" : className.replace("readOnlyInput", "");
                }
                else if ("TEXT" == type.toUpperCase() || "TEXTAREA" == type.toUpperCase()) {
                    readOnly = inRO;
                    if (!inRO)
                        inElem.removeAttribute("disabled");
                    else
                        disabled = inRO;
                    //className = inRO ? className + " readOnlyInput" : className.replace("readOnlyInput", "");
                }
            }
            else if ("SELECT" == nodeName.toUpperCase()) {
                if (!inRO)
                    inElem.removeAttribute("disabled");
                else {
//                    for (var i = 0; i < inElem.children.length; i++) {
//                        if (children[i].selected)
//                            children[i].style.background = "#E2E2E2";
//                    }
                    disabled = inRO;
                }
            }
            else if ("LABEL" == nodeName.toUpperCase()) {//|| "DIV" == nodeName.toUpperCase() || "SPAN" == nodeName.toUpperCase()) {
                disabled = inRO;
        //        className = inRO ? className + " readOnlyLabel" : className.replace("readOnlyLabel", "");
            }
//            else if ("SPAN" == nodeName.toUpperCase()) {
//                className = inRO ? className + " readOnlyLabel" : className.replace("readOnlyLabel", "");
//            }

            for (var x = 0; x < inElem.childNodes.length; x++) {
                ChangeCtrlRO(inRO, inElem.childNodes[x], inSetChildren);
            }
        }
    }
}

//Telerik date controls have to be handled differently than in the code behind since
//when disabled from there they remove attributes needed when re enabled from javascript
function ToggleRODatePicker(inRadDatePicker, inEnable) {
    inRadDatePicker.set_enabled(!inEnable);
    var Container1 = inRadDatePicker.get_popupContainer();
    Container1.disabled = inEnable;
}

function ToggleRO_RadCombo( inRadCombo, inEnable) {
    if (inEnable)
        inRadCombo.disable();
    else
        inRadCombo.enable();
} 
