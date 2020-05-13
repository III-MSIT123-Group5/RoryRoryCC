document.getElementById("Name1").onblur = CheckInput;

function CheckInput() {
    var name = document.getElementById("Name1").value;
    var nameError = document.getElementById("checkNameError");
    var rex = /[^\u4e00-\u9fff]/;
    if (!name == "") {
        if (!rex.test(name) && name.length >=2) {
            nameError.style.color = "Blue";
            nameError.innerText = "正確";
        }
        else {
            nameError.style.color = "Red";
            nameError.innerText = "姓名必須轉入中文字及至少兩個";
        }
    }
    else {
        nameError.style.color = "Red";
        nameError.innerText = "姓名不能是空的";
    }
}


document.getElementById("Password1").onblur = checkPW;

function checkPW() {
    var pw = document.getElementById("Password1").value;
    var passwordError = document.getElementById("checkPWError");
    var pwRexNum = /[0-9]/;
    var pwRexAph = /[a - zA - Z]/;
    var pwRexMark = /[!@#\$%\^&\*]/;

    if (!pw == "") {
        if (pw.match(pwRexNum) && pw.length >= 6 && pw.match(pwRexAph) && pw.match(pwRexMark)) {
            passwordError.style.color = "Blue";
            passwordError.innerText = "正確";
            
        }
        else {
            passwordError.style.color = "Red";
            passwordError.innerText = "你輸入的密碼格式不正確";
        }
    }
    else {
        passwordError.style.color = "Red";
        passwordError.innerText = "你輸入的密碼格式不正確";
    }


}

document.getElementById("DateOfBirth1").onblur = checkBirth;

function checkBirth() {

    var birth = document.getElementById("DateOfBirth1").value;
    var checkBirthError = document.getElementById("checkBirthError");
    var birthReg = new RegExp("^([0-9]{4})[./]{1}([0-9]{1,2})[./]{1}([0-9]{1,2})$");

    if (birth != "") {
        if (birth.match(birthReg)) {
            var array = birth.split('/');
            var y = parseInt(array[0]);
            var m = parseInt(array[1]);
            var d = parseInt(array[2]);
            console.log(y);
            console.log(m % 2);
            console.log(d);

            if (m <= 7) {
                if (m % 2 == 1) {
                    if (d > 31 || d <0) {
                        checkBirthError.style.color = "Red";
                        checkBirthError.innerText = "你輸入的日期不正確";
                    }
                    else {
                        checkBirthError.style.color = "Blue";
                        checkBirthError.innerText = "正確";
                    }
                }
                else if (m == 2) {
                    if (y % 4 == 0) {
                        if (d <= 29 && d > 0) {
                            checkBirthError.style.color = "Blue";
                            checkBirthError.innerText = "正確";
                        }
                        else {
                            checkBirthError.style.color = "Red";
                            checkBirthError.innerText = "你輸入的日期不正確";
                        }
                    }
                    else {
                        if (d <= 28 && d > 0) {
                            checkBirthError.style.color = "Blue";
                            checkBirthError.innerText = "正確";
                        }
                        else {
                            checkBirthError.style.color = "Red";
                            checkBirthError.innerText = "你輸入的日期不正確";
                        }
                    }

                }
                else {
                    if (m % 2 == 0) {
                        if (d <= 30 && d > 0) {
                            checkBirthError.style.color = "Blue";
                            checkBirthError.innerText = "正確";
                        }
                        else {
                            checkBirthError.style.color = "Red";
                            checkBirthError.innerText = "你輸入的日期不正確";
                        }
                    }
                }
            }
            else {
                if (m > 12) {
                    checkBirthError.style.color = "Red";
                    checkBirthError.innerText = "你輸入的月份不正確";
                }
                else {
                    if (m % 2 == 0) {
                        if (d > 31 && d > 0) {
                            checkBirthError.style.color = "Red";
                            checkBirthError.innerText = "你輸入的日期不正確";
                        }
                        else {
                            checkBirthError.style.color = "Blue";
                            checkBirthError.innerText = "正確";
                        }
                    }
                    else {
                        if (d > 30 && d > 0) {
                            checkBirthError.style.color = "Red";
                            checkBirthError.innerText = "你輸入的日期不正確";
                        }
                        else {
                            checkBirthError.style.color = "Blue";
                            checkBirthError.innerText = "正確";
                        }
                    }
                }
            }
        }
        else {
                checkBirthError.style.color = "Red";
                checkBirthError.innerText = "你輸入的格式不正確";
        }
    }
    else {
        checkBirthError.style.color = "Red";
        checkBirthError.innerText = "你輸入的格式不正確";
    }
}


//function checkBirth() {

//    var birth = document.getElementById("DateOfBirth1").value;
//    var checkBirthError = document.getElementById("checkBirthError");
//    var birthReg = new RegExp("^([0-9]{4})[./]{1}([0-9]{1,2})[./]{1}([0-9]{1,2})$");

//    if (birth != "") {
//        if (birth.match(birthReg)) {
//            checkBirthError.style.color = "Blue";
//            checkBirthError.innerText = "正確";
//        }
//        else {
//            checkBirthError.style.color = "Red";
//            checkBirthError.innerText = "你輸入的格式不正確";
//        }
//    }
//    else {
//        checkBirthError.style.color = "Red";
//        checkBirthError.innerText = "你輸入的格式不正確";
//    }
//}