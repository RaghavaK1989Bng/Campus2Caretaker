
/// <reference path="jquery-1.4.1-vsdoc.js" />

$(document).ready(function() {
    // Set focus on the correct tab in the menu.
    var tabID = "#" + $("#tabid").text();
    $(tabID).addClass("current");
});


/* If you don't want to use jQuery, delete it and uncomment the following.  */

/*function setActiveMenu() {
    var control = document.getElementById('tabid');
    var menuid = control.innerText;

    var menu = document.getElementById(menuid);
    menu.className = 'current';
}

window.onload = setActiveMenu;  */
