$(function () {
    var sortParams = {
        "nombre_desc": "sort-desc",
        "": "sort-asc",
        "Porcentaje": "sort-asc",
        "porcentaje_desc": "sort-desc",
        "Carrera": "sort-asc",
        "carrera_desc": "sort-desc"
    };

    $("th a").each(function () {
        var href = $(this).attr("href");
        var sortOrder = href ? href.split('sortOrder=')[1] : null;
        if (sortOrder) {
            $(this).addClass(sortParams[sortOrder] || "");
        }
    });
});