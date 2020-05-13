
    function changeArticle(tid){
        //console.log(tid);
        var q = document.getElementById(tid).id;
        //console.log(q);
        if(q=="t1"){
            var i =document.getElementById("panel-1").style;
            i.display="block";
            var i2 =document.getElementById("panel-2").style;
            i2.display="none";
            var i3 =document.getElementById("panel-3").style;
            i3.display="none";
            var i4 =document.getElementById("panel-4").style;
            i4.display="none";
            var i5 =document.getElementById("panel-5").style;
            i5.display="none";
        }else if(q=="t2"){
            var i =document.getElementById("panel-1").style;
            i.display="none";
            var i2 =document.getElementById("panel-2").style;
            i2.display="block";
            var i3 =document.getElementById("panel-3").style;
            i3.display="none";
            var i4 =document.getElementById("panel-4").style;
            i4.display="none";
            var i5 =document.getElementById("panel-5").style;
            i5.display="none";
        }else if(q=="t3"){
            var i =document.getElementById("panel-1").style;
            i.display="none";
            var i2 =document.getElementById("panel-2").style;
            i2.display="none";
            var i3 =document.getElementById("panel-3").style;
            i3.display="block";
            var i4 =document.getElementById("panel-4").style;
            i4.display="none";
            var i5 =document.getElementById("panel-5").style;
            i5.display="none";
        }
        else if(q=="t4"){
            var i =document.getElementById("panel-1").style;
            i.display="none";
            var i2 =document.getElementById("panel-2").style;
            i2.display="none";
            var i3 =document.getElementById("panel-3").style;
            i3.display="none";
            var i4 =document.getElementById("panel-4").style;
            i4.display="block";
            var i5 =document.getElementById("panel-5").style;
            i5.display="none";
        }
        else if(q=="t5"){
            var i =document.getElementById("panel-1").style;
            i.display="none";
            var i2 =document.getElementById("panel-2").style;
            i2.display="none";
            var i3 =document.getElementById("panel-3").style;
            i3.display="none";
            var i4 =document.getElementById("panel-4").style;
            i4.display="none";
            var i5 =document.getElementById("panel-5").style;
            i5.display="block";
        }
    }
