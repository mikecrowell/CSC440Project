function ParentChkBox_Checked(parent, chkListItems) {
    var chkBoxesToCheck = chkListItems.getElementsByTagName("input");
    if (parent.checked == true) {
        for (var i = 0; i < chkBoxesToCheck.length; i++) {
            chkBoxesToCheck[i].checked = true;
        }
    } else {
        for (var j = 0; j < chkBoxesToCheck.length; j++) {
            chkBoxesToCheck[j].checked = false;
        }
    } 
}