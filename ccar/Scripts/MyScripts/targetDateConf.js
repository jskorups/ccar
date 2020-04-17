$(".btnAdd").click(function () {

    var time1 = document.getElementById('kespa').value;

    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!

    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm;
    }
    var time2 = yyyy + '-' + mm + '-' + dd;

    if (time1 < time2) {
        myFunction();

    }

    function myFunction() {
        confirm("CCAR: You sure want to set target date before today?");
    }
});