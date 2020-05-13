
let imgs = document.querySelectorAll(".s"); 

let myImg = document.querySelectorAll("img");
console.log(myImg);

var spanValue = document.getElementById("span");

for (var i = 0; i < imgs.length; i++) {
    imgs[i].onmouseover = mouseover;
    //imgs[i].onmouseout = mouseout;
}

var x = 0;


function mouseover() {
    this.src = "Images/chngstar.gif";
    if (x < 5) {
        x++;
    }    
    spanValue.innerText = "你選了 " + x + " 顆星";
}

//function mouseout(){
    
//}



//document.querySelector("#idimg1").onclick = click;
//document.querySelector("#idimg2").onclick = click1;
//document.querySelector("#idimg3").onclick = click2;
//document.querySelector("#idimg4").onclick = click3;
//document.querySelector("#idimg5").onclick = click4;

//function click() {
//    spanValue.innerText = "你選了1星";
//    this.src = "Images/chngstar.gif";
//}

//function click1() {
//    spanValue.innerText = "你選了2星";
//    this.src = "Images/chngstar.gif";
//}
//function click2() {
//    spanValue.innerText = "你選了3星";
//    this.src = "Images/chngstar.gif";
//}
//function click3() {
//    spanValue.innerText = "你選了4星";
//    this.src = "Images/chngstar.gif";
//}

//function click4() {
//    spanValue.innerText = "你選了5星";
//    this.src = "Images/chngstar.gif";
//}
