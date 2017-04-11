function showDialog(content) {
    var dialog = $("<p>").text(content);
    $(dialog).dialog({
        buttons: {
            "Згода": function () {
                $(this).dialog("close");
            }
        }
    });
}

function reloadDisqusCommentsCounter() {
    //if (window.DISQUSWIDGETS) {
    //    window.DISQUSWIDGETS.getCount({ reset: true });
    //}
    window.DISQUSWIDGETS = undefined;
    $.getScript("http://" + config.disqusShortName + ".disqus.com/count.js");
}

var config = {
    disqusShortName: "spadschyna",
    newsStartPage: 1,
    galleryStartPage: 1,
    yearAllInt: 0
}