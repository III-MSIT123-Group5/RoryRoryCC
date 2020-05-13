//==========日期輸出
//============年=====================
let year = document.getElementById("datePickYear");
var str = "";
for (let i = 2010; i <= 2020; i++) {
    str += `<option value="${i}">${i}年</option>`;
}
year.innerHTML = str;
//================月
let month = document.getElementById("datePickMon");
str = "";
for (let i = 01; i <= 12; i++) {
    str += `<option value="${i}">${i}月</option>`;
}
month.innerHTML = str;
//================日 方法
function date() {
    let date = document.getElementById("datePickDate");
    str = "";
    switch (parseInt(month.value)) {
        case 1: case 3: case 5: case 7: case 8: case 10: case 12:
            for (let i = 01; i <= 31; i++) {
                str += `<option value="${i}">${i}日</option>`;

            } break;
        case 4: case 6: case 9: case 11:
            for (let i = 01; i <= 30; i++) {
                str += `<option value="${i}">${i}日</option>`;
            } break;
        case 2:
            if (difYear() == 1)
                for (let i = 01; i <= 28; i++) {
                    str += `<option value="${i}">${i}日</option>`;
                }
            else
                for (let i = 01; i <= 29; i++) {
                    str += `<option value="${i}">${i}日</option>`;
                } break;
    }
    date.innerHTML = str;

}


//========判斷閏年
function difYear() {
    let year = document.getElementById("datePickYear").value;
    if (year % 4 != 0 || (year % 100 == 0 && year % 400 != 0)) {
        return 1;
    }
    else {
        return 0;
    }
}
//=======事件
year.addEventListener("change", date);
month.addEventListener("change", date);
document.getElementById("inputbtn").addEventListener("click", inputdate)

//======寫入
function inputdate() {
    let text = document.getElementById("inputdateText");
    text.value += `您選擇的日期:${year.value}年${month.value}月${document.getElementById("datePickDate").value}日\n`;
          }