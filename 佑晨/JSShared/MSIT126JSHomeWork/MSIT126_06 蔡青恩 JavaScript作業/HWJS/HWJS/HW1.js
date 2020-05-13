let times = document.getElementById("times");

for (let i = 1; i < 10; i++) {

    times.innerHTML += `<td>`
    for (let j = 1; j < 10; j++) {
        times.innerHTML += `<p>${i}x${j}=${i * j}</p>`;
    } times.innerHTML += `</td>`
}