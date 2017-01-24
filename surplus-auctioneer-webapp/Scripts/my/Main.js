/*global ga */
// Everything inside of this IIFE (Immediately-Invoked Function Expression) will execute as soon as the JavaScript file is loaded.
(function IIFE(global) {
    "use strict";

    jQuery.browser = {};
    (function () {
        jQuery.browser.msie = false;
        jQuery.browser.version = 0;
        if (navigator.userAgent.match(/MSIE ([0-9]+)\./)) {
            jQuery.browser.msie = true;
            jQuery.browser.version = RegExp.$1;
        }
    })();

    // Declare the global namespaces which will be used for custom JavaScript files, and attach the namespaces to the window object.
    var _my = _my || {};
    global.my = _my;
    global.my.Common = _my.Common || {};
    global.my.Views = _my.Views || {};
})(this);