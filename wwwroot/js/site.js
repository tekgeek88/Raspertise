// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function processColor() {
    // color = document.getElementById("colorInput").value;
    // color = color.match(/[A-Za-z0-9]{2}/g).map(function (v) {
    //     return parseInt(v, 16)
    // }).join(",");
    // document.getElementById("colorInput").value = color
}

$("#sliderSpeed").on("input", function () {
    speed = this.value;
    setSliderValue($("#sliderSpeed"), speed);
});

function setSliderValue(slider, value) {
    $(slider).prop("value", value);
    $(slider).next("label").html(value);
}

