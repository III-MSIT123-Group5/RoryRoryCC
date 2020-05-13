function CreateTable() {
    let table = document.querySelector("#table");
    table.style.borderCollapse = "collapse";
    table.className = "margin";
    let tr, td;
    for(let j = 1; j<10;j++){
        tr = document.createElement("tr");
        table.appendChild(tr);
        for(let i = 2; i<10;i++){
            td = document.createElement("td");
            td.style.border = "1px black solid";
            td.style.color = "blue";
            
            td.innerHTML = `${i} * ${j} = ${i*j}`;
            tr.appendChild(td);
        }
    }
}

function CheckName(){
        var name = document.getElementById("name").value;
        var spanVal = document.getElementById("idsp1");
        var str = /[^\u4e00-\u9fa5]/;
        var reg = new RegExp(str);
        if (name == "") {
            spanVal.innerHTML = "不可空白";
            spanVal.style.color ="red"
        } 
        else if (reg.test(name)) {
            spanVal.innerHTML = "必須為中文";
            spanVal.style.color ="red"
        } 
        else {
            spanVal.innerHTML = "正確";
            spanVal.style.color ="green"
        }
} 


function passwordCheck(){

    var pwdObj = document.getElementById("password").value;
        var pwdlen = pwdObj.length;
        var spanVal = document.getElementById("idsp2");
        var str = /^(?=.*[A-Za-z])(?=.*[0-9])(?=.*[!@#$%^&*]).{6,}$/;
        var reg = new RegExp(str);
        if (pwdObj == "") {
            spanVal.innerHTML = "不可空白";
            spanVal.style.color ="red"
        } else if (pwdlen > 6) {
            if (!reg.test(pwdObj)) {
                spanVal.innerHTML = "必須包含英文字母、數字、特殊字元";
                spanVal.style.color ="red"
                console.log(pwdObj);
            } else {
                spanVal.innerHTML = "正確";
                spanVal.style.color ="green"
            }
        } else {
            spanVal.innerHTML = "密碼長度需大於六";
            spanVal.style.color ="red"
        }

}



var validateDate = function (originalYear, originalMonth, originalDay) {
    var date = new Date(originalYear, originalMonth - 1, originalDay);
    var year = date.getFullYear();
    var month = date.getMonth() -  1;
    var day = date.getDate();
    return year == originalYear && month == originalMonth && day == originalDay;
    } 



    function tdate() {

        var timeObj = document.getElementById("date").value
        var idsp3 = document.getElementById("idsp3");
        var year = timeObj.substr(0, 4)
        var month = timeObj.substr(5, 2)
        var day = timeObj.substr(8, 2)

        if (timeObj == "") {
            idsp3.innerHTML = "日期不可為空白";


        } else if (timeObj.length == 10) {
            var re3 = /^([0-9]{4})[./-]{1}([0-9]{1,2})[./]{1}([0-9]{1,2})$/;

            if (re3.test(timeObj)) {
                var d = new Date(timeObj);
                var theyear = d.getFullYear();
                var themonth = d.getMonth() + 1;
                var date1 = d.getDate();

                if ((day == date1) && (month == themonth) && (year == theyear)) {
                    idsp3.innerHTML = "日期格式正確";
                    idsp3.style.color ="green"
                } else {
                    idsp3.innerHTML = "日期格式錯誤";
                    idsp3.style.color ="red"
                }
            }
        }
        else
            idsp3.innerHTML = "請輸入正確格式";
            idsp3.style.color ="red"


    }

