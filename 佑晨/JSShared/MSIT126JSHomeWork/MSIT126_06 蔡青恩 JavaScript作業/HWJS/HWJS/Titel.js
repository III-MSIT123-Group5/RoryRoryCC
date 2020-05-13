let titel = [
    ` <a class="titel" href="HW1_99times.html">九九乘法表</a>`,
    `<a class="titel" href="HW2_password.html">密碼驗證</a>`,
    `<a class="titel" href="HW3_starselect.html">選擇評價</a>`,
    ` <a class="titel" href="HW4_switchPic.html">更換圖片</a>`,
    `<a class="titel" href="HW5_datePick.html">選擇日期</a>`]
for (let i = 0; i < titel.length; i++) {
    document.getElementById("titel").innerHTML += titel[i];
}