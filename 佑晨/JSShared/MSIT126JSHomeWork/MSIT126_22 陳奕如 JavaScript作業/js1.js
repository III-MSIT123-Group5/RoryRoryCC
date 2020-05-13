var i, j;

for (i = 1; i <= 9; i++) {
    document.write("<tr>");
    j = 2;
    while (j <= 9) {
        document.write("<td>");
        document.write(j + "*" + i + "=" + i * j);
        document.write("</td>");
        j++;
    }
    document.write("</tr>");
}