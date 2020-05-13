document.write("<h2 style='font-family:微軟正黑體;'>九九乘法表</h2>");
document.write("<table id='table1' style='border : 1px solid gary;'>");
    var table = document.querySelector("table");
    let x=2 ;
    var str="<tr>";
    for(let i=2; i<10 ; i++){
        if(x<i){
            str+="</td><td id='td1'>"
        }
        x = i;
        str +="<td id='td1'>"
        for(let j =1 ; j<10 ; j++){
            str+= i + "x" + j + "=" + i*j + "<br>"
            
        }       
    }
    str+="</tr>";
    // console.log(str);
    table.innerHTML = str;
    document.write("</table>"); 

