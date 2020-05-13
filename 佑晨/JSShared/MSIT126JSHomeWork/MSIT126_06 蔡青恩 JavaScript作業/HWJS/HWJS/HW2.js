let UserName = document.getElementById("UserName");
let PassWord = document.querySelector("#PassWord");
let date = document.querySelector("#Date");
UserName.addEventListener("input", conFirmUserName);
PassWord.addEventListener("input", conFirmPassWord);
date.addEventListener("input", conFirmDate);
document.getElementById("confirm").addEventListener("click", () => UserName.value != "" && PassWord.value != "" && date.value != ""&&q1==q2==q3==1 ? alert ("資料已送出"):alert("請填好資料"));
document.getElementById("cancel").addEventListener("click", () => UserName.value = PassWord.value = date.value = "");
let q1,q2,q3 = 0;
function conFirmUserName() {
    
    var showusername = document.getElementById("showusername");
    var chinese = /[^\u4e00-\u9fa5]/;
    let str = `<img src="image/wrong.png"/ >`;
    if (UserName.value == "") {
        str += "Error";
    }

    else if (UserName.value.split("").length < 2 || chinese.test(UserName.value)) {
        str += "Error";
    }

    else
        str = `<img src="image/ok.png"/ > ` + "Right";
    showusername.innerHTML = str;
    q1 = 1;
}

function conFirmPassWord() {
   
    var showpassword = document.querySelector("#showpassword");
    var num = /\d+/;
    var eng = /[A-Za-z]+/;
    var spec = /\W+/;
    let str = `<img src="image/wrong.png"/ >`;
    if (PassWord.value == "") {
        str += "Error";
    }

    else if (PassWord.value.split("").length < 6) {
        str += "Error";
    }

    else if (!num.test(PassWord.value)) {
        str += "Error";
    }

    else if (!eng.test(PassWord.value)) {
        str += "Error";
    }

    else if (!spec.test(PassWord.value)) {
        str += "Error";
    }

    else
        str = `<img src="image/ok.png"/ > ` + "Right";
    showpassword.innerHTML = str;
    q2 = 1;
}

function conFirmDate() {
    var rge = /^[0-9]{4}[/]{1}\d{1,2}[/]{1}\d{1,2}$/;
   
    var datetime = new Date(date.value).getFullYear() + "/" + (new Date(date.value).getMonth() + 1) + "/" + new Date(date.value).getDate();
    var checkdatetime = date.value;
    var showDate = document.querySelector("#showDate");

    console.log(datetime);
    console.log(checkdatetime);
    if (!rge.test(date.value)) {
        showDate.innerHTML = `<img src="image/wrong.png"/ >ERROR`;
    }

    else if (datetime != checkdatetime) {
        showDate.innerHTML = `<img src="image/wrong.png"/ >ERROR`;
    }

    else {
    showDate.innerHTML = `<img src="image/ok.png"/ >Right `;
        q3 = 1;
    }
}