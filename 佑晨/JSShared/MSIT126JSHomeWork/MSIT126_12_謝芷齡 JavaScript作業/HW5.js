function getDay(dateStr) {
    var dateObj = new Date(Date.parse(dateStr)); // yyyy/mm/dd
    var limitInMonth = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    var theYear = dateObj.getFullYear();
    var theMonth = dateObj.getMonth();
    var isLeap = new Date(theYear, 1, 29).getDate() === 29;
  
    if (isLeap) {
      limitInMonth[1] = 29;
    }
  
    return limitInMonth[theMonth];
}

document.write("<h2 style='font-family:微軟正黑體;'>2010~2020日期</h2>");

document.write("<select name='chooseYear'  id='yearid' >");
document.write("<option id='optionid' value=''>年</option>");
var str = "";
for(let i=2010;i<2021 ; i++){
    str+=`<option id='optionid' value='${i}'>${i}</option>`
}
document.write(str);
document.write("</select>")
document.write("<span id='optionid'>年</span>")

document.write("<select name='chooseMonth'  id='monthid' onblur='start()'>");
document.write("<option id='optionid' value=''>月</option>");
var strM = "";
for(let i=1;i<13 ; i++){
    strM+=`<option id='optionid' value='${i}'>${i}</option>`
}
document.write(strM);
document.write("</select>")
document.write("<span id='optionid'>月</span>")
var str = "請選擇日期";
var Year ="";
var Month ="";
function start(){
    
    Year = document.getElementById("yearid").value;
    Month = document.getElementById("monthid").value;
    if(Year!="" && Month!=""){
        var YM = Year+"/"+Month;
        //console.log(YM);
        var MaxDay = getDay(YM);
        //console.log(MaxDay);
    }

     let selector = document.getElementById("Dayid");
     selector.length = 0
      for(let i=1;i<MaxDay+1 ; i++){
        selector.options.add(new Option(`${i}`,`${i}`))
        
     }
    
    
}

document.write("<select name='chooseDay'  id='Dayid' onblur='showdate()' >");
document.write("<option id='optionid' value='' >日</option>");
document.write("</select>")
document.write("<span id='optionid'>日</span>")
document.write("<fieldset id='hw5fieldset'>");
document.write("<legend>Information</legend>");

document.write(`<p id='p'>${str}</p>`);
var p = document.getElementById("p");

document.write("</fieldset>");

function showdate(){
    var Day= document.getElementById("Dayid").value;
    str = `<p>您選擇的日期是${Year}年${Month}月${Day}日</p>`;
    p.innerHTML=str;
}
