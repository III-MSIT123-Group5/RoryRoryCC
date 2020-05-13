document.querySelector("#name1").onblur = checkName;
document.querySelector("#pwd1").onblur = checkPW;
document.querySelector("#date1").onblur = checkDT;
function checkName() {
    var theName = document.getElementById("name1");
    var theNameV = theName.value;
    var re = /[^\u4e00-\u9fa5]/;
    let strNM = document.getElementById("spac");
    if (theNameV == "") {
        strNM.innerHTML = "不可為空白";
    }
    else if (theNameV.length < 2) {
        strNM.innerHTML = "請輸入至少兩個字";
    }
    else if (theNameV.length >= 2 && re.test(theNameV)) {
        strNM.innerHTML = "必須輸入中文";
    }
    else {
        strNM.innerHTML = "正確!";
    }
}
function checkPW() {
    var thePW = document.getElementById("pwd1");
    var thePWV = thePW.value;
    var re = /^(?=.*[a-z])(?=.*\W)(?=.*\d)[^]{6,16}$/;
    let strPW = document.getElementById("sppw");
    if (thePWV == "") {
        strPW.innerHTML = "不可為空白";
    }
    else if (thePWV.length < 6) {
        strPW.innerHTML = "請輸入至少六個字元";
    }
    else if (thePWV.length >= 6 && !re.test(thePWV)) {
        strPW.innerHTML = "需包含字母,數字,特殊符號";
    }
    else {
        strPW.innerHTML = "正確!";
    }
}
function checkDT() {
    var theDate = document.getElementById("date1");
    var theDateV = theDate.value;
    var re = /^([0-9]{4})[./]{1}([0-9]{1,2})[./]{1}([0-9]{1,2})$/;
    let strDT = document.getElementById("spd");
    if (theDateV == "") {
        strDT.innerHTML = "不可為空白";
    }
    else if (!re.test(theDateV)) {
        strDT.innerHTML = "請輸入正確日期格式";
    }
    else {
        var DA = [0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
        arrD = theDateV.split("/");
        y = parseInt(arrD[0], 10);
        m = parseInt(arrD[1], 10);
        d = parseInt(arrD[2], 10);
        if (leapY(y)) DA[2] = 29;
        if (m > 12 || m < 1) {
            strDT.innerHTML = "請輸入正確日期格式";
        }
        else if (d > DA[m]) {
            strDT.innerHTML = "請輸入正確日期格式";
        }
        else {
            strDT.innerHTML = "正確!";
        }
    }
}
function leapY(yy) {
    return (new Date(yy, 1, 29).getDate() == 29);
}