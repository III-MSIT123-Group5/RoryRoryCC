let img = document.querySelector("#switchPic");
let Pic = ["../switchPic/01.jpg",
    "../switchPic/02.jpg",
    "../switchPic/03.jpg",
   "../switchPic/04.jpg",
    "../switchPic/05.jpg",
    "../switchPic/06.jpg"]
let Pichref = [
    "https://www.pexels.com/zh-tw/photo/461198/  ",
    "https://www.pexels.com/zh-tw/photo/376464/  ",
    "https://www.pexels.com/zh-tw/photo/1633578/",
    "https://www.pexels.com/zh-tw/photo/675951/  ",
    "https://www.pexels.com/zh-tw/photo/1279330/",
    "https://www.pexels.com/zh-tw/photo/1633525/"]
let PicNum = 1;
//======a picknum按鈕
let str = "";
for (let i = 0; i < Pic.length; i++){
    str += `<a><img class="smallPic" id="${i}" src="${Pic[i]}"/></a>`

}
document.getElementById("picknum").innerHTML = str;


//=======輪播按鈕
document.getElementById("fordPic").addEventListener("click", fordPic);
document.getElementById("nextPic").addEventListener("click", nextPic);
document.getElementById("autoPic").addEventListener("click", autoPic);
let Pickup = document.querySelectorAll(".smallPic");
for (let i = 0; i < Pickup.length; i++) {
    Pickup[i].addEventListener("click",PickPic)

}
let btnlight = document.querySelectorAll(".btn");
for (let i = 0; i < btnlight.length; i++) {
    btnlight[i].addEventListener("mouseover", btnlightup);
    btnlight[i].addEventListener("mouseout", btnlightdown);
}
//=======自動輪播
    let defultauto=setInterval(nextPic, 3000);
let autoOn = 1;
Pickup[0].style.backgroundColor = "#3C3C3C";

//======方法
function fordPic() {
    let temp = PicNum;
    temp = (PicNum - (Pic.length-1)) % Pic.length;
    img.src = Pic[Math.abs(temp)];
    document.getElementById("Pichref").href = Pichref[Math.abs(temp)];
    for (let i = 0; i < Pickup.length; i++) { Pickup[i].style.backgroundColor = "#FFFFFF"; }
    Pickup[Math.abs(temp)].style.backgroundColor = "#3C3C3C";
    
    PicNum = temp;
  
}
function nextPic() {
    let temp = PicNum;
    temp = (PicNum - 1) % Pic.length;
    img.src = Pic[Math.abs(temp)];
    document.getElementById("numbertext").innerHTML = `${Math.abs(temp)+1}/${Pic.length}</div >`;
    document.getElementById("Pichref").href = Pichref[Math.abs(temp)];
    for (let i = 0; i < Pickup.length; i++)
    { Pickup[i].style.backgroundColor = "#FFFFFF"; }
    Pickup[Math.abs(temp)].style.backgroundColor = "#3C3C3C";
    PicNum = temp;
   
}
function autoPic() {
      
    let autotemp = Math.abs((autoOn - 1));

    if (autotemp) {
        defultauto=setInterval(nextPic, 3000);
     
    }
    else {
        clearInterval(defultauto);
 
     
    }
    autoOn = autotemp;
}
function PickPic() {
    PicNum = -this.id;
    img.src = Pic[Math.abs(PicNum)];
    document.getElementById("Pichref").href = Pichref[Math.abs(temp)];

}
function btnlightup() {
    this.style.backgroundColor ="#600000";
  
}
function btnlightdown() {
    this.style.backgroundColor = "";

}