/*global my */

my.Views._Shared = (function ($) {
    "use strict";

    var initTables = function () {
        $(".tableSorter")
            .tablesorter({
                theme: 'blue',
                widgets: ['zebra', 'filter'],
                sortList: [[5, 0]]
            })
            .tablesorterPager({ container: $(".pager") });
    }

    return {
        initTables: initTables
    };
})(this.jQuery);