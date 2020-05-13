function attachEvents() {
    document.getElementById("name1").onblur = checkName;
    
    document.getElementById("pwd1").onblur = checkPwd;
    
    document.getElementById("date1").onblur = checkDate;

    document.getElementById("submit1").onclick = form_submit;
    document.getElementById("reset1").onclick = form_reset;
}

function checkName() {
    var theNameObj = document.getElementById("name1");
    var theNameObjVal = theNameObj.value;
    var theNameObjValLen = theNameObjVal.length;
    var nameInfo = document.getElementById("name_info");

    if (theNameObjValLen == 0) {
        nameInfo.innerHTML = "<img src=\'../images/cross16.png\' />姓名不可為空白";
        nameInfo.className = "info_err";
    }
    else if (IsNotAllCN(theNameObjVal)) {
        nameInfo.innerHTML = "<img src=\'../images/cross16.png\' />姓名必須全為中文";
        nameInfo.className = "info_err";
    }
    else if (theNameObjValLen < 2) {
        nameInfo.innerHTML = "<img src=\'../images/cross16.png\' />姓名不可少於兩個字";
        nameInfo.className = "info_err";
    }
    else {
        nameInfo.innerHTML = "<img src=\'../images/check16.png\' />正確";
        nameInfo.className = "info_corr";
    }
}

function IsNotAllCN(str) {
    for (let i = 0; i < str.length; i++) {
        if (str.charAt(i) < "\u4E00" || str.charAt(i) > "\u9FFF") {
            return true;
        }
    }
    return false;
}



function checkPwd() {
    var thePwdObj = document.getElementById("pwd1");
    var thePwdObjVal = thePwdObj.value;
    var thePwdObjValLen = thePwdObjVal.length;
    var pwdInfo = document.getElementById("pwd_info");

    if (thePwdObjValLen == 0) {
        pwdInfo.innerHTML = "<img src=\'../images/cross16.png\' />密碼不可為空白";
        pwdInfo.className = "info_err";
    }
    else if (thePwdObjValLen < 6) {
        pwdInfo.innerHTML = "<img src=\'../images/cross16.png\' />密碼不可少於6個字";
        pwdInfo.className = "info_err";
    }
    else if (hasEng(thePwdObjVal) && hasNum(thePwdObjVal) && hasSpe(thePwdObjVal)) {
        pwdInfo.innerHTML = "<img src=\'../images/check16.png\' />正確";
        pwdInfo.className = "info_corr";
    }
    else {
        pwdInfo.innerHTML = "<img src=\'../images/cross16.png\' />密碼必須包含英文字母、數字、特殊字元[!@#$%^&*]";
        pwdInfo.className = "info_err";
    }
}

function hasEng(str) {
    for (let i = 0; i < str.length; i++) {
        let ch = str.charAt(i).toUpperCase();
        if (ch >= "A" && ch <= "Z") {
            return true;
        }
    }
    return false;
}

function hasNum(str) {
    for (let i = 0; i < str.length; i++) {
        let ch = str.charAt(i);
        if (ch >= "0" && ch <= "9") {
            return true;
        }
    }
    return false;
}


function hasSpe(str) {
    for (let i = 0; i < str.length; i++) {
        let ch = str.charAt(i);
        if (ch == "!" || ch == "@" || ch == "#" || ch == "$" || ch == "%" || ch == "^" || ch == "&" || ch == "*") {
            return true;
        }
    }
    return false;
}




function checkDate() {
    var theDateObj = document.getElementById("date1");
    var theDateObjVal = theDateObj.value;
    var theDateObjValLen = theDateObjVal.length;
    var dateInfo = document.getElementById("date_info");

    if (theDateObjValLen == 0) {
        dateInfo.innerHTML = "<img src=\'../images/cross16.png\' />日期不可為空白";
        dateInfo.className = "info_err";
    }
    else if (DateFormInvalid(theDateObjVal)) {
        dateInfo.innerHTML = "<img src=\'../images/cross16.png\' />日期不正確";
        dateInfo.className = "info_err";
    }
    else {
        dateInfo.innerHTML = "<img src=\'../images/check16.png\' />正確";
        dateInfo.className = "info_corr";
    }
}

function DateFormInvalid(str) {
    if (str.indexOf(".") >= 0) {
        return true;
    }

    var nums = str.split("/");
    if (nums.length != 3) {
        return true;
    }

    var yyyy = Number(nums[0]);
    var mm = Number(nums[1]);
    var dd = Number(nums[2]);
    if (yyyy == NaN || mm == NaN || dd == NaN) {
        return true;
    }
    if (yyyy < 0 || mm < 1 || mm > 12) {
        return true;
    }

    var correctDate = new Date(yyyy, mm - 1, dd);
    if (dd != correctDate.getDate() || (mm - 1) != correctDate.getMonth()) {
        return true;
    }

    return false;
}

function form_submit() {
    if (document.getElementById("name_info").innerText == "正確" &&
        document.getElementById("pwd_info").innerText == "正確" &&
        document.getElementById("date_info").innerText == "正確") {
        document.getElementById("form1").submit();
    }
}

function form_reset() {
    document.getElementById("form1").reset();
    document.getElementById("name_info").innerHTML = "";
    document.getElementById("pwd_info").innerHTML = "";
    document.getElementById("date_info").innerHTML = "";
}
