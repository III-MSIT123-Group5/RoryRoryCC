//===============評價
//===========星星複製
let star = document.querySelector("#star");
str = "";
for (let i = 0; i < 5; i++) {
    str += `<img src="image/star.gif" / id=${i} class="s">`;
}
star.innerHTML = str;
let img = document.querySelectorAll(".s");
for (let i = 0; i < img.length; i++) {
    img[i].addEventListener("mouseover",mouseover);
    img[i].addEventListener("mouseout", mouseout);
    img[i].addEventListener("click", click);   
}

function mouseover() {
    for (let i = 0; i <= this.id; i++) {
      img[i].src = "image/chngstar.gif";
    }
}
    function mouseout() {
        for (let i = 0; i < img.length; i++) {
            this.src = "image/star.gif";
        }
}
function click() {
    let temp = this.id;
    
    document.getElementById("count").innerHTML =`<p>您給的是${parseInt(temp)+1}星評價</p>`;
    for (let i = 0; i < img.length; i++) {
        img[i].src = "image/star.gif";
    }
    for (let i = 0; i <= temp; i++) {
        img[i].src = "image/chngstar.gif";
        
    } 
     
    for (let i = 0; i < img.length ; i++) {
        img[i].removeEventListener("mouseover", mouseover);
        img[i].removeEventListener("mouseout", mouseout);
    }
   
}