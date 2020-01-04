$('.input-post-cover').change(function () {

    var fileName = $(this).val().split("\\").pop();
    $(this).next(".lbl-post-cover").html(fileName);
});