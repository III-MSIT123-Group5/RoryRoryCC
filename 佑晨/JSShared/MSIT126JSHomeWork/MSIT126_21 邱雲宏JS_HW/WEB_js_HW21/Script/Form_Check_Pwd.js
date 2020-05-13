var pattern_6char = /(?=^.{6,}$)(?=.*[A-z])(?=.*[0-9])(?=.*[!@#$%^&*])^.*$/i;
var pattern_hasSpace = /\s/i;

document.querySelector("#tPwd").addEventListener("blur", Check_Pwd);

function Check_Pwd() {
    var C_Pwd = document.getElementById("tPwd").value;
    var msgPwd = document.getElementById("mPwd");
    var imgPwd = document.getElementById("imgPwd");
    //---------------------------------------------
    console.log(`輸入為: ${C_Pwd}`);
    console.log(`六個字以上為:${pattern_6char.test(C_Pwd)}`);
    console.log(`含空格為:${pattern_hasSpace.test(C_Pwd)}`);

    if (!pattern_6char.test(C_Pwd)) {
        imgPwd.setAttribute("src", "image/icons8-error-16.png");
        msgPwd.innerHTML = "至少6個字且必須包含英文字母、數字、特殊字元[!@#$%^&*]";
    } else if (pattern_hasSpace.test(C_Pwd)) {
        imgPwd.setAttribute("src", "image/icons8-error-16.png");
        msgPwd.innerHTML = "不能包含空格!";
    } else {
        imgPwd.setAttribute("src", "image/icons8-checkmark-16.png");
        msgPwd.innerHTML = "";
    }
}
