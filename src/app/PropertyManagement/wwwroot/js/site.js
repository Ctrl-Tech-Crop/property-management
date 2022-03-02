// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#propertyCollapsePanel").on("hidden.bs.collapse", function () {
    const btn = document.getElementById("viewPropertyDetailsToggleBtn");
    btn.innerText = "Show property details";
});

$("#propertyCollapsePanel").on("shown.bs.collapse", function () {
    const btn = document.getElementById("viewPropertyDetailsToggleBtn");
    btn.innerText = "Hide property details";
});
