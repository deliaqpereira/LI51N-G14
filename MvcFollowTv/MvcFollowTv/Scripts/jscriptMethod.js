function getPage(size)
{
    window.pagesize = size;
    getPageAjax(0);
};

function setdisabled()
{
};

function getPageAjax(pageBtn) 
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
        document.getElementById("active").textContent = page;
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

    xmlhttp.open("GET", "/" + controller + "/" + pageopen + "?page=" + page + "&pagesize=" + pagesize, true);
    xmlhttp.send();


};