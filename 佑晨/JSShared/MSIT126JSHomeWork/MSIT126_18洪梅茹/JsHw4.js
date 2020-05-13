let count = -1;
var pictures = [{ img: 'images/p0.jpg', link: 'https://zh.wikipedia.org/wiki/%E6%96%AF%E7%89%B9%E6%8B%89%E6%96%AF%E5%A0%A1' },
{ img: 'images/p1.jpg', link: 'https://sally1017.pixnet.net/blog/post/463917953' },
{ img: 'images/p2.jpg', link: 'https://zh.wikipedia.org/wiki/%E5%B0%BC%E6%96%AF' },
{ img: 'images/p3.jpg', link: 'https://zh.wikipedia.org/wiki/%E5%A4%A7%E5%B3%BD%E8%B0%B7%E5%9C%8B%E5%AE%B6%E5%85%AC%E5%9C%92' },
{ img: 'images/p4.jpg', link: 'https://zh.wikipedia.org/wiki/%E5%93%88%E5%B0%94%E6%96%BD%E5%A1%94%E7%89%B9' }];

function pictureShow() {
    count++;
    if (count > pictures.length - 1)
        count = 0;
    //document.querySelector("#picture").innerHTML = "<img src='images/p" + count + ".jpg' width=700 height=500/>";
    document.querySelector("#picture").innerHTML = "<a href=" + pictures[count].link + ">" + "<img src=" + pictures[count].img + " width=650 height=400/>" + "</a>";
    circle();
}

let myInterval = window.setInterval(pictureShow, 3000);
pictureShow();

document.querySelector("#nextPictureId").onclick = nextPicture;
function nextPicture() {
    count++;
    if (count > pictures.length - 1)
        count = 0;
    document.querySelector("#picture").innerHTML = "<a href=" + pictures[count].link + ">" + "<img src=" + pictures[count].img + " width=650 height=400/>" + "</a>";
    circle();
}
document.querySelector("#lastPictureId").onclick = lastPicture;
function lastPicture() {
    count--;
    if (count < 0)
        count = pictures.length - 1;
    document.querySelector("#picture").innerHTML = "<a href=" + pictures[count].link + ">" + "<img src=" + pictures[count].img + " width=650 height=400/>" + "</a>";
    circle();
}
let pictureStatus = 0;
document.querySelector("#stopPicture").onclick = myIntervalStop;
function myIntervalStop() {
    if (pictureStatus == 0) {
        clearInterval(myInterval);
        document.querySelector("#stopPicture").src = "images/stop.png";
        pictureStatus = 1;
    }
    else {
        myInterval = window.setInterval(pictureShow, 3000);
        pictureShow();
        document.querySelector("#stopPicture").src = "images/play.png";
        pictureStatus = 0;
    }
}

function circle() {
    var list = document.getElementById("tips").getElementsByTagName("LI");
    list[count].className = "active";
    for (let i = 0; i < pictures.length; i++) {
        if (count != i) {
            list[i].className = "";
        }
    }
}