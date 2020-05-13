var pattern_2char = /..+/i;
var pattern_nonChi = /[^(\u4E00-\u9FFF)]/i;
var pattern_hasSpace = /\s/i;

document.querySelector("#tName").addEventListener("blur", Check_Name);

function Check_Name() {
    var C_Name = document.getElementById("tName").value;
    var msgName = document.getElementById("mName");
    var imgName = document.getElementById("imgName");
    //-----------------------------------------------
    console.log(`輸入為: ${C_Name}`);
    console.log(`兩個字以上為:${pattern_2char.test(C_Name)}`);
    console.log(`含中文以外字元為:${pattern_nonChi.test(C_Name)}`);
    console.log(`含空格為:${pattern_hasSpace.test(C_Name)}`);

    if (!pattern_2char.test(C_Name)) {
        imgName.setAttribute("src", "image/icons8-error-16.png");
        msgName.innerHTML = "請輸入兩個字以上!";
    } else if (pattern_hasSpace.test(C_Name)) {
        imgName.setAttribute("src", "image/icons8-error-16.png");
        msgName.innerHTML = "不能包含空格!";
    } else if (pattern_nonChi.test(C_Name)) {
        imgName.setAttribute("src", "image/icons8-error-16.png");
        msgName.innerHTML = "只能輸入中文字!";
    } else {
        imgName.setAttribute("src", "image/icons8-checkmark-16.png");
        msgName.innerHTML = "";
    }
}