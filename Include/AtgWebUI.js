function toggleDivision(inDivID, inUniqueDivID) {
    var tmpButtonLinkBtn = document.getElementById(inDivID + 'LinkBtn');
    var tmpLinkText = document.getElementById(inDivID + 'HeaderLinkText');
    var tmpContainerDiv = document.getElementById(inDivID);
    var tmpHeaderDiv = document.getElementById(inDivID + 'Header');
    //var tmpHeaderState = document.getElementById(inDivID + "hf");
    
    //alert(document.getElementById(inUniqueDivID).value);
    
    if (tmpContainerDiv.style.height == 'auto') {
        tmpContainerDiv.style.height = tmpHeaderDiv.style.height;
        tmpContainerDiv.Expanded = 'false';

        //alert(document.getElementById(inUniqueDivID + '_ExpandState'));
        
        if ( null != document.getElementById(inUniqueDivID + '_ExpandState') )
            document.getElementById(inUniqueDivID + '_ExpandState').value = 'false';
            
        if (null != tmpButtonLinkBtn)
            tmpButtonLinkBtn.value = 'Show';
        if (null != tmpLinkText)
            tmpLinkText.innerHTML = 'Show';
    }
    else {
        tmpContainerDiv.style.height = 'auto';
        tmpContainerDiv.Expanded = 'true';

        //alert(document.getElementById(inUniqueDivID + '_ExpandState'));
        
        if (null != document.getElementById(inUniqueDivID + '_ExpandState'))
            document.getElementById(inUniqueDivID + '_ExpandState').value = 'true';
        
        if (null != tmpButtonLinkBtn)
            tmpButtonLinkBtn.value = 'Hide';
        if (null != tmpLinkText)
            tmpLinkText.innerHTML = 'Hide';
    }
}

function toggleDivHeaderMouseOver(inDivID, inDirection) {
    var tmpHeaderDiv = document.getElementById(inDivID + 'Header');

    //alert(tmpHeaderDiv.className);
    if (tmpHeaderDiv.className != 'SliderDivHeaderCustom') {
        if (inDirection == 'over') {
            tmpHeaderDiv.style.cursor = 'pointer';
            tmpHeaderDiv.style.color = 'black';
            tmpHeaderDiv.style.backgroundPosition = '100% -200px';
        }
        else {
            tmpHeaderDiv.style.cursor = 'auto';
            tmpHeaderDiv.style.color = 'white';
            tmpHeaderDiv.style.backgroundPosition = '100% 0px';
        }
    }
    else {
        if (inDirection == 'over') {
            tmpHeaderDiv.style.cursor = 'pointer';
        }
        else {
            tmpHeaderDiv.style.cursor = 'auto';
        }

    }
}

function SetDivHeaderStatus(inDivID, inStatusType, inUserText) {
    var tmpHeaderDivCheck = document.getElementById(inDivID + 'HeaderCheck');
    var tmpHeaderDivStatusText = document.getElementById(inDivID + 'HeaderTitleStatus');

    if (inStatusType == 'C') {
        tmpHeaderDivCheck.src = '/images/checkmarkgreen.png';
        tmpHeaderDivStatusText.innerHTML = "(Complete)";
    }
    else if (inStatusType == 'I') {
        tmpHeaderDivCheck.src = '/images/checkmarkred.png';
        tmpHeaderDivStatusText.innerHTML = "(Incomplete)";
    }
    else if (inStatusType == 'U') {
        tmpHeaderDivCheck.src = '';
        tmpHeaderDivStatusText.innerHTML = inUserText;
    }
    else {
        tmpHeaderDivCheck.src = '';
        tmpHeaderDivStatusText.innerHTML = "";
    }

}