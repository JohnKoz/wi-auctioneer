/*global my */

my.Views.Search = (function ($) {
    "use strict";

    var init = function init() {
        $("#searchResults").tablesorter();
    }

    return {
        init: init
    };
})(this.jQuery);