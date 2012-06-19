function getPage(size)
{
    alert("getpage");
    window.pagesize = size;
    GetPageAjax(0);
};

function setdisabled() 
{
    var elem;
    if (page != 0) {
        elem = $("#prev"); //jQuery Selects a single element with the given id attribute.
        elem.removeClass('disabled');
        elem = document.getElementById("prev");
        elem.href = "javascript:GetPageAjax('prev')";
    } else {
        elem = $("#prev");  //jQuery Selects a single element with the given id attribute.
        elem.addClass('disabled');
        elem = document.getElementById("prev");
        elem.href = "javascript:void(0)";
    }
    if (page != lastpage) {
        elem = $("#next");  //jQuery Selects a single element with the given id attribute.
        elem.removeClass('disabled');
        elem = document.getElementById("next");
        elem.href = "javascript:GetPageAjax('next')";
    } else {
        elem = $("#next");  //jQuery Selects a single element with the given id attribute.
        elem.addClass('disabled');
        elem = document.getElementById("next");
        elem.href = "javascript:void(0)";
    }
};

function GetPageAjax(pageBtn)
{
    if (pageBtn == "prev" && page > 0)
    {
        page--;
    }

    if (pageBtn == "next" && page < lastpage)
    {
        page++;
    }

    if (pageBtn == "first") 
    {   
        page = 0;
    }

    if (pageBtn == "last")
    {
        page = lastpage;
    }



    function pagecallback(xmlhttp)
    {
        var input = xmlhttp.responseText;
        setdisabled();
        var cache = page;
        window.history.pushState(cache, "Page" + page, "/Programs/IndexWithPage?page=" + page + "&pagesize=" + pagesize);
        document.getElementById("currentPage").textContent = page;
        $("#main").html(input);
    }

    if (XMLHttpRequest)
    { // code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else
    { // code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function ()
    {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200)
        {
            pagecallback(xmlhttp);
        }
    };

    var pageopen = "IntervalPage";

    xmlhttp.open("GET", "/" + "Programs" + "/" + pageopen + "?page=" + page + "&pagesize=" + pagesize, true);
    xmlhttp.send();


};