let imgs = document.querySelectorAll(".s");
let imgsLen = imgs.length;

//for (let i = 0; i < imgsLen; i++) {
//    imgs[i].onmouseover = mouseover;
//    imgs[i].onmouseout = mouseout;
//}
var currentindex;
for (let i = 0; i < imgsLen; i++) {
    imgs[i].onmouseover = mouseover;
    imgs[i].onmouseout = mouseout;
}

function mouseover() {
    console.log(this.id);
    for (let i = 0; i < imgsLen; i++) {
        if (this.id == imgs[i].id) {
            currentindex = i;
            console.log(currentindex);
        }
    }
    for (let i = 0; i < currentindex + 1; i++) {
        imgs[i].src = "images/chngstar.gif";
    }
    //this.src = "images/chngstar.gif";
}

function mouseout() {
    for (let i = 0; i < imgsLen; i++) {
        imgs[i].src = "images/star.gif";
    }
    //this.src = "images/star.gif";
}