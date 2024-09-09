function pswchecker() {
    debugger;
    var psw = document.getElementById("txtPassword").value;
    $("#pswsms").fadeIn();
    $("#message").fadeIn();
    var patt = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@@#\$%\^&\*])(?=.{6,})/;
    if (psw.length > 6) {
        if (psw.match(patt)) {
            document.getElementById("txtPassword").classList.remove("is-invalid");
            document.getElementById("message").innerHTML = '<p class="text-success"><strong>Vaild Password</strong></p>';
            setTimeout(function () { $("#message").fadeOut(); }, 3000);
            setTimeout(function () { $("#pswsms").fadeOut(); }, 3000);

            return true;
        }
        else {
            $("#pswsms").show();
            $("#txtPassword").addClass('is-invalid');
            document.getElementById("message").innerHTML = '<p class="text-warning"><strong>Invaild Password</strong></p>';
           
            return false;
        }
    }
    else {
        $("#pswsms").show();
        $("#txtPassword").addClass('is-invalid');
        document.getElementById("message").innerHTML = '<p class="text-warning"><strong> Password Minimum 6 letter </strong></p>';


        return false;
    }
}