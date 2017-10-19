var buyItems = localStorage.length;

$(document).ready(function () {
    $("#cartWin").hide();

    var listproducts = "";
    var key1 = "Key";
    var anum = 0;


    // GENERATE CART
    for (var i = 0; i < localStorage.length; i++) {
        var key = key1 + anum;
        anum++;

        var getItems = localStorage.getItem(key);
        listproducts += getItems + "<br /><hr /><br />";
    }
    $("#cartWin").append(listproducts);

    $("#number").html(localStorage.length);


    //FILTER SEARCH
    $("#filter").keyup(function () {

        var filter = $(this).val();

        $("#indexcontent .imagecontent").each(function () {

            if ($(this).text().search(new RegExp(filter, "i")) < 0) {
                $(this).fadeOut();

            } else {
                $(this).show();
            }
        });
    });

    // Click buy
    $("#buy").click(function () {
        var id = $(this).data("assigned-id");
        var test = "";
        var num = localStorage.length++;
        var detailsUrl = "http://developer.bimobject.com/sandbox/retailx/home/details";

        test += "Key" + num;
        var productname = '<a href="' + detailsUrl + id + '">' + $(this).parents().eq(2).find("h2").text() + '</a>';
        localStorage.setItem(test, productname);
        listproducts += "<br /><br />" + productname;

        $("#number").html(localStorage.length);


        $("#cartWin").slideToggle(500).append(productname);

    });

    $("#cart").click(function () {
        $("#cartWin").slideToggle();
    });

    $("#emptycart").click(function () {
        localStorage.clear();
        $("#number").html(localStorage.length);
        $("#cartWin").html("");
    });

    $("#wrapper").click(function () {
        $("#cartWin").slideUp(2000);
    });

    //$(".linkbtn").click(function (event) {
    //    event.preventDefault();
    //    //var popupWindow = window.open(this.href, "GetFile", "width=400,height=600");
    //});
});