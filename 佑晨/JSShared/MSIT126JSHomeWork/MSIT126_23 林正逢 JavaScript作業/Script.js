document.querySelector("#pwd").onblur = checkPwd;
function checkPwd() {
    //取得idPwd元素
    var thePwdObj = document.getElementById("pwd");
    //取得idPwd元素值
    var thePwdObjVal = thePwdObj.value;
    let strObj = document.getElementById("idsp2");
    let thePwdObjValLen = thePwdObjVal.length;
    let acount = 0; //英文
    let ncount = 0; //數字
    let tcount = 0; //特殊符號
    //判斷元素值是否為空白，密碼長度是否大於6
    if (thePwdObjVal == "") {
        strObj.style.color = "red";
        strObj.style.fontFamily = "標楷體";
        strObj.innerText = "不能空白";
    }
    else if (thePwdObjValLen >= 6) {
        //如果長度是否大於6，判斷是否包含字母、數字、特殊符號
        for (let i = 0; i < thePwdObjValLen; i++) {
            let ch = thePwdObjVal.charAt(i).toUpperCase();
            console.log(ch);
            if (ch >= "A" && ch <= "Z") {
                acount += 1; //有英文輸入就+1
            }
            else if (ch >= "0" && ch <= "9") {
                ncount += 1; //有數字輸入就+1
            }
            if (ch >= "A" && ch <= "Z") {

            }
            else if (ch >= "0" && ch <= "9") {

            }
            else {
                tcount += 1; //除了英文或數字輸入就表示是特殊符號，就+1
            }
        }
        if (acount != 0 && ncount != 0 && tcount != 0) {
            strObj.style.color = "yellow";
            strObj.style.fontFamily = "標楷體";
            strObj.innerHTML = "正確"; //三個都不等於0，表示全都有輸入，等於正確
        }
        else {
            strObj.style.color = "red";
            strObj.style.fontFamily = "標楷體";
            strObj.innerHTML = "密碼需要包含字母、數字、特殊符號";
        }
    }
    else {
        strObj.style.color = "red";
        strObj.style.fontFamily = "標楷體";
        strObj.innerHTML = "密碼不能少於六位數";
    }
}



document.querySelector("#account").onblur = checkname;
function checkname() {
    //取得idname元素
    var nameObj = document.getElementById("account");
    //取得idname元素值
    var nameObjVal = nameObj.value;
    let strObj = document.getElementById("idsp");
    let nameObjValLen = nameObjVal.length;
    let acount = false;
    //判斷元素值是否為空白
    if (nameObjVal == "") {
        strObj.style.color = "red";
        strObj.style.fontFamily = "標楷體";
        strObj.innerHTML = "不能空白";
    }
    else if (nameObjValLen <= 5) {
        //如果長度是否小於等於5，判斷是否中文字
        for (let i = 0; i < nameObjValLen; i++) {
            //let ch = nameObjVal.charCodeAt(i)
            //if (ch >= 19968 && ch <= 40959) {
            //    acount = true; //有中文輸入就等於true
            //}           
            let ch = nameObjVal.charAt(i);
            if (ch >= "\u4E00" && ch <= "\u9FFF") {
                acount = true; //有中文輸入就等於true
            }
        }
        if (acount == true) {
            strObj.style.color = "yellow";
            strObj.style.fontFamily = "標楷體";
            strObj.innerHTML = "正確";
        }
        else {
            strObj.style.color = "red";
            strObj.style.fontFamily = "標楷體";
            strObj.innerHTML = "必須輸入中文字";
        }
    }
}

function checkDate() {
    //取得iddate元素
    var dateObj = document.getElementById("date");
    //取得iddate元素值
    var dateObjVal = dateObj.value;
    let strObj = document.getElementById("idsp3");
    var sp = dateObjVal.split('/');
    var theYear = parseInt(sp[0]);
    var theMonth = parseInt(sp[1]);
    var theDay = parseInt(sp[2]);
    var d = false;
    //判斷元素值是否為空白
    if (dateObjVal == "") {
        strObj.style.color = "red";
        strObj.style.fontFamily = "標楷體";
        strObj.innerHTML = "不能空白";
    }
    else {
        var dateObjVal = new Date(theYear, theMonth -1 , theDay);
        var year = dateObjVal.getFullYear();
        var month = dateObjVal.getMonth() +1;
        var day = dateObjVal.getDate();
        if (year == theYear && month == theMonth && day == theDay) {
            d = true;
        }
        if (d == true) {
            strObj.style.color = "yellow";
            strObj.style.fontFamily = "標楷體";
            strObj.innerHTML = "格式正確";
        }
        else {
            strObj.style.color = "red";
            strObj.style.fontFamily = "標楷體";
            strObj.innerHTML = "格式錯誤";
        }
    }
} 
document.querySelector("#date").onblur = checkDate;