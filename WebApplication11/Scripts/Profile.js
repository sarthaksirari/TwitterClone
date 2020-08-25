$(document).ready(function () {
    $(".accordion").accordion({ collapsible: true, defaultOpen: false, active: false });

    $("#CoverPic_FileUploaderCP").hide();
    $("#CoverPic_FileUploaderDP").hide();
    $("#CoverPic_SaveChangesButton").hide();

    $("#CoverPic_CoverPicButton").click(function () {
        $("#CoverPic_FileUploaderCP").click();
    });

    $("#CoverPic_ProfilePicButton").click(function () {
        $("#CoverPic_FileUploaderDP").click();
    });
});

function showpreview(input, type) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            if (type == "DP") {
                $("#CoverPic_ProfilePicButton").attr('src', e.target.result);
                $("#CoverPic_SaveImagesButton").show();
            }
            else if (type == "CP") {
                $("#CoverPic_CoverPicButton").attr('src', e.target.result);
                $("#CoverPic_SaveImagesButton").show();
            }
        }
        reader.readAsDataURL(input.files[0]);
    }
}
