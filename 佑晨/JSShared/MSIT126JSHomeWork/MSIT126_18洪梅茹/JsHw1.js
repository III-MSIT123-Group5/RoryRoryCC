document.write("<div id='TableInfo' class='tabcontent'>")
document.write("<center>");
document.write("<table class='tb'>");
var i, j;

for (i = 2; i <= 9; i++) {
    document.write("<td class='td1'>");

    for (j = 1; j <= 9; j++) {
        document.write(i + "*" + j + "=" + i * j + "<br>");
    }
    document.write("</td>");
}

document.write("</table>");
document.write("</center>")
document.write("</div>")