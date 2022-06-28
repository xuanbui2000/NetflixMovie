// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
if ($(".background_table")[0] || $(".child_item")[0]) {

    $("body").addClass("bodyPage");
} else {
    $("body").addClass("bodyHome");
}