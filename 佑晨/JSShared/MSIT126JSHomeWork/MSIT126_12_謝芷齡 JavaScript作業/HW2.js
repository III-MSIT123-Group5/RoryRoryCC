document.write("<h2 style='font-family:微軟正黑體;'>表單驗證</h2>");
document.write("<form action='#' method='get' enctype='multipart/form-data'>");
document.write("<fieldset>");
document.write("<legend>Form Check</legend>");
document.write("<div class='st1'><label class='t1' for='account'>姓名:</label><input type='text' name='account' id='account' placeholder='請輸入姓名' size='20' onblur='checkName()' /><span id='namesp'></span>");
document.write("<br><span class='sp2'>1.不可空白 , 2.至少兩個字以上 , 3.必須全部為中文字</span></div>");
document.write("<div class='st1'><label class='t1' for='pwd'>密碼:</label><input type='password' name='pwd' id='idPwd' onblur='checkPwd()' /><span id='idsp'></span>")
document.write("<br><span class='sp2'>1.不可空白 , 2.至少六個字且必須包含英文字母 數字及特殊符號</span></div>");   
document.write("<div class='st1'><label class='t1' for='date'>日期:</label><input type='text' name='date' id='date' onblur='checkDate()' /><span id='datesp'></span>")
document.write("<br><span class='sp2'>格式 : 西元年/月/日 yyyy/MM/dd</span></div>");   
document.write("<div class='sub'><input id='btn' type='submit' value='送出' /><input id='btn' type='reset' value='清空' onclick='clear()'/></div>")
document.write("</fieldset>")   

function clear() {
    var spContent3 = document.getElementById("datesp");
    var spContent1 = document.getElementById("namesp");
    var spContent = document.getElementById("idsp");
    spContent3.innerHTML = "";
    spContent1.innerHTML = "";
    spContent.innerHTML = "";
}

function isnotExistDate(dateStr) {
    var dateObj = new Date(Date.parse(dateStr)); // yyyy/mm/dd
    var limitInMonth = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    var theYear = dateObj.getFullYear();
    var theMonth = dateObj.getMonth();
    var theDay = dateObj.getDate();
    var isLeap = new Date(theYear, 1, 29).getDate() === 29;
  
    if (isLeap) {
      limitInMonth[1] = 29;
    }
  
    return theDay <= limitInMonth[theMonth - 1];
}

function checkDate(){
    var dateVal = document.getElementById("date").value;
    console.log(dateVal);
    var spContent3 =  document.getElementById("datesp");
    // console.log(dateVal);
    var regdate="[0-9]{4}[./]{1}(0[1-9]|1[012])[./]{1}(0[1-9]|[12][0-9]|3[01])";
    var regdatetest = new RegExp(regdate);
    if(!regdatetest.test(dateVal)){
        spContent3.style.color = "red";
        spContent3.innerHTML = "<img src='Image/close.png' width=16px/>格式錯誤";
    }else if(isnotExistDate(dateVal)){
        spContent3.style.color = "red";
        spContent3.innerHTML = "<img src='Image/close.png' width=16px/>日期錯誤";
    }
    else{
        spContent3.style.color = "green";
        spContent3.innerHTML = "<img src='Image/circle.png' width=16px/>";
    }
}


function checkName(){
    var nameVal= document.getElementById("account").value;
    var spContent1 =  document.getElementById("namesp");
    var namelen = nameVal.length;
    var regname="[^\u4e00-\u9fa5]";
    var regnametest = new RegExp(regname);
    if(nameVal==""){
        spContent1.style.color = "red";
        spContent1.innerHTML = "<img src='Image/close.png' width=16px/>此欄必填";
    } else if (namelen < 2) {
        spContent1.style.color = "red";
        spContent1.innerHTML = "<img src='Image/close.png' width=16px/>至少輸入2個字";
    }else if(regnametest.test(nameVal)){
        spContent1.style.color = "red";
        spContent1.innerHTML = "<img src='Image/close.png' width=16px/>請輸入中文";
    }else{
        spContent1.style.color = "green";
        spContent1.innerHTML = "<img src='Image/circle.png' width=16px/>";
    }

}



function checkPwd(){
    var pwdVal = document.getElementById("idPwd").value;

    //判斷元素值是否為空白，密碼長度是否大於6
    var spContent = document.getElementById("idsp");
    var pwdlength = pwdVal.length;
    if (pwdVal == "") {
        spContent.style.color = "red";
        spContent.innerHTML = "<img src='Image/close.png' width=16px/>此欄必填";
    } else if (pwdlength < 6) {
        spContent.style.color = "red";
        spContent.innerHTML = "<img src='Image/close.png' width=16px/>至少為6碼";

    }

    //如果長度是否大於6，判斷是否包含字母、數字、特殊符號
    var ck="";
    var str = "[@/'\"#$%&^*]+";
    var reg = new RegExp(str);
    var regnum = new RegExp('\\d');
    if (pwdlength >= 6) {
        if (reg.test(pwdVal)) 
            ck += "1"; //正確
          else 
            ck += "4";
        
        if (regnum.test(pwdVal)) 
            ck += "1";
         else 
            ck += "3";
        
        for (let i = 0; i < pwdlength; i++) {
            var char = pwdVal.charAt(i).toUpperCase();
            if (!char >= "A" && !char <= "Z") {
                ck += "2"; //錯誤 :不是英文
            } else {
                ck += "1"; //正確
            }
        }
        var cksplit = ck.split("");
        console.log(cksplit);
        console.log(cksplit.includes("2"));
        console.log(cksplit.includes("3"));
        console.log(cksplit.includes("4"));
        if (cksplit.includes("2") || cksplit.includes("3") || cksplit.includes("4")) {
            spContent.style.color = "red";
            spContent.innerHTML = "<img src='Image/close.png' width=16px/>";
            if (cksplit.includes("2")) {
                spContent.innerHTML += "    必須含英文";
            }
            if (cksplit.includes("3")) {
                spContent.innerHTML += "    必須含數字";
            }
            if (cksplit.includes("4")) {
                spContent.innerHTML += "    必須含符號";
            }
        } else {
            spContent.style.color = "green";
            spContent.innerHTML = "<img src='Image/circle.png' width=16px/>";
        }

        

    }      
}   
            