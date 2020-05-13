document.querySelector("#nameId").onblur = checkName;
function checkName() {
    let theNameObj = document.getElementById("nameId");
    let theSpanObj = document.getElementById("nameIdSpan");
    var rex = /[^\u4e00-\u9fff]/;

    if (theNameObj.value == "") {
        theSpanObj.innerHTML = "<img src='images/incorrect.png'/> 不可為空白";
    }
    else if (rex.test(theNameObj.value)) {
        theSpanObj.innerHTML = "<img src='images/incorrect.png'/> 請輸入中文";
    }
    else if (theNameObj.value.length < 2) {
        theSpanObj.innerHTML = "<img src='images/incorrect.png'/> 至少輸入兩個字";
    }
    else {
        theSpanObj.innerHTML = "<img src='images/correct.png'/>";
    }
}

document.querySelector("#passwordId").onblur = checkPassword;
function checkPassword() {
    var rexEng = /.*[A-Z,a-z]+/;
    var rexNum = /.*\d+/;
    var rexSpe = /.*\W+/;
    if (document.getElementById("passwordId").value == "") {
        document.getElementById("passwordIdSpan").innerHTML = "<img src='images/incorrect.png'/> 不可為空白";
    }
    else if (!rexEng.test(document.getElementById("passwordId").value)) {
        document.getElementById("passwordIdSpan").innerHTML = "<img src='images/incorrect.png'/> 請輸入英文";
    }
    else if (!rexNum.test(document.getElementById("passwordId").value)) {
        document.getElementById("passwordIdSpan").innerHTML = "<img src='images/incorrect.png'/> 請輸入數字";
    }
    else if (!rexSpe.test(document.getElementById("passwordId").value)) {
        document.getElementById("passwordIdSpan").innerHTML = "<img src='images/incorrect.png'/> 請輸入特殊字元";
    }
    else if (document.getElementById("passwordId").value.length < 6) {
        document.getElementById("passwordIdSpan").innerHTML = "<img src='images/incorrect.png'/> 至少輸入六個字";
    }
    else {
        document.getElementById("passwordIdSpan").innerHTML = "<img src='images/correct.png'/>";
    }
}

document.querySelector("#dateId").onblur = checkDate;
function checkDate() {
    var rex = /\d{4}[./]{1}(0[1-9]|1[012])[./]{1}(0[1-9]|[12][0-9]|3[01])/;
    let d = new Date(document.getElementById("dateId").value);
    let d1 = d.yyyymmdd();
    if (document.getElementById("dateId").value == "") {
        document.getElementById("DateIdSpan").innerHTML = "<img src='images/incorrect.png'/> 不可為空白";
    }
    else if (d.yyyymmdd() != document.getElementById("dateId").value) {
        document.getElementById("DateIdSpan").innerHTML = "<img src='images/incorrect.png'/> 格式錯誤";
    }
    //else if (!rex.test(document.getElementById("dateId").value)) {
    //    document.getElementById("DateIdSpan").innerHTML = "格式錯誤";
    //}
    //else if (!isExistDate(document.getElementById("dateId").value)) {
    //    document.getElementById("DateIdSpan").innerHTML = "日期無效";
    //}
    else {
        document.getElementById("DateIdSpan").innerHTML = "<img src='images/correct.png'/>";
    }
}

function isExistDate(dateStr) {
    var dateObj = dateStr.split('/'); // yyyy/mm/dd

    //列出12個月，每月最大日期限制
    var limitInMonth = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

    var theYear = parseInt(dateObj[0]);
    var theMonth = parseInt(dateObj[1]);
    var theDay = parseInt(dateObj[2]);
    var isLeap = new Date(theYear, 1, 29).getDate() === 29; // 是否為閏年?

    if (isLeap) {
        // 若為閏年，最大日期限制改為 29
        limitInMonth[1] = 29;
    }

    // 比對該日是否超過每個月份最大日期限制
    return theDay <= limitInMonth[theMonth - 1];
}

Date.prototype.yyyymmdd = function () {
    var mm = this.getMonth() + 1; // getMonth() is zero-based
    var dd = this.getDate();

    return [this.getFullYear(),
    (mm > 9 ? '/' : '/0') + mm,
    (dd > 9 ? '/' : '/0') + dd
    ].join('');
};