/*global my */

my.Views.Search = (function ($) {
    "use strict";

    var init = function init() {
        my.Views._Shared.initTables();
    }

    return {
        init: init
    };
})(this.jQuery);