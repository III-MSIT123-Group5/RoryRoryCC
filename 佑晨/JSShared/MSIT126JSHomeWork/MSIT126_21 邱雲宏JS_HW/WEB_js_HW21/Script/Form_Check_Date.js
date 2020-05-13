var pattern_DateFormat = /^[0-9]{4}[/][0-9]{1,2}[/][0-9]{1,2}$/i
var pattern_hasSpace = /\s/i
//var pattern_month_nonZero = /[/]0(?=[1-9][/])/g   /*0開頭月份*/
var pattern_date_nonZero = /[/]0(?=[1-9]\b)/g //0開頭月日 數字結尾 2位

document.querySelector("#tDate").addEventListener("blur", Check_Date);

function Check_Date() {

    var get_Date = document.getElementById("tDate").value;
    var C_Date = get_Date.replace(/[/]0(?=[1-9]\b)/g, "/");//--除去0
    var msgDate = document.getElementById("mDate");
    var imgDate = document.getElementById("imgDate");
    var parseDate = Date.parse(C_Date);//----數值
    var msec_ToDate = new Date(parseDate); //---日期
    var newC_Date = `${msec_ToDate.getFullYear()}/${msec_ToDate.getMonth() + 1}/${msec_ToDate.getDate()}`;
    //----------------------------------------------
    console.log(`輸入為${C_Date}`);
    console.log(`含空格為:${pattern_hasSpace.test(C_Date)}`);
    console.log(`parseDate為${Date.parse(C_Date)}`);
    console.log(`msec_ToDate為${msec_ToDate}`);
    console.log(`轉換後日期為${newC_Date}`);

    if (!pattern_DateFormat.test(C_Date)) {
        //imgDate.setAttribute("src", "image/icons8-error-16.png");
        imgDate.src = "image/icons8-error-16.png";
        msgDate.innerHTML = "格式輸入不正確";
    } else if (pattern_hasSpace.test(C_Date)) {
        //imgDate.setAttribute("src", "image/icons8-error-16.png");
        imgDate.src = "image/icons8-error-16.png";
        msgDate.innerHTML = "不能包含空格";
    } else if (C_Date != newC_Date) {
        //imgDate.setAttribute("src", "image/icons8-error-16.png");
        imgDate.src = "image/icons8-error-16.png";

        msgDate.innerHTML = "無此日期!";
    } else {
        //imgDate.setAttribute("src", "image/icons8-checkmark-16.png");
        imgDate.src = "image/icons8-checkmark-16.png";
        msgDate.innerHTML = "";
    }

}
