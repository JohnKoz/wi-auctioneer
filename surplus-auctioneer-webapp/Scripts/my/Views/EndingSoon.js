/*global my */

my.Views.EndingSoon = (function ($) {
    "use strict";

    var init = function init() {
        $("#endingSoonAuctions").tablesorter();
    }

    return {
        init: init
    };
})(this.jQuery);