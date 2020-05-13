
var b = document.createElement("tbody")

for (var i = 1; i < 10; i++) {
    var y = document.createElement("tr");
    b.appendChild(y);

    for (var j = 2; j < 10; j++) {
        var z = document.createElement("td");
        var t = document.createTextNode(`${j}*${i}=${i * j}`);
        z.appendChild(t);
        y.appendChild(z);
    }
    j = 2;
}
document.getElementById("myTable").appendChild(b);