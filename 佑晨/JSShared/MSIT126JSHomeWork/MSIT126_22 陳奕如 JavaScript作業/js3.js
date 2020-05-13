﻿function rate(obj, oEvent) {
    var imgSrc = 'image/star_empty.png';
    var imgSrc_2 = 'image/star_full.png';
    if (obj.rateFlag) return;
    var e = oEvent || window.event;
    var target = e.target || e.srcElement;
    var imgArray = obj.getElementsByTagName("img");
    for (var i = 0; i < imgArray.length; i++) {
        imgArray[i]._num = i;
        imgArray[i].onclick = function () {
            if (obj.rateFlag) return;
            obj.rateFlag = true;
            let str = document.getElementById("ss");
            str.innerHTML = "你給" + (this._num + 1) + "顆星";
        };
    }
    if (target.tagName == "IMG") {
        for (var j = 0; j < imgArray.length; j++) {
            if (j <= target._num) {
                imgArray[j].src = imgSrc_2;
            } else {
                imgArray[j].src = imgSrc;
            }
        }
    } else {
        for (var k = 0; k < imgArray.length; k++) {
            imgArray[k].src = imgSrc;
        }
    }
}