(function ($) {

    console.log("main.js loaded");
    // Hide Mobile menu
    function mobileMenuHide() {
        console.log("OK in mobileMenuHide()");
        var windowWidth = $(window).width();
        if (windowWidth < 1024) {
            $('#site_header').addClass('mobile-menu-hide');
        }
    }
    // /Hide Mobile menu

    //On document load
    // $(document).on("ready", function() {
    $(document).ready(function(){
        console.log("OK in document onReady()");
        // Mobile menu
        $('.menu-toggle').on("click", function () {
            console.log("OK, div.menu-toggle clicked");
            $('#site_header').toggleClass('mobile-menu-hide');
        });

        // Mobile menu hide on main menu item click
        $('.main-menu').on("click", "a", function (e) {
            console.log("OK, div.main-menu clicked");
            mobileMenuHide();
        });


    });

    console.log("main.js ended");

})(jQuery);


