function checking_password() {
   
    var new_psswd = document.getElementById("txtPassword").value;
    var confirm_psswd = document.getElementById("txtConfirmPassword").value; 
   if (confirm_psswd == " ") {
        $("#txtConfirmPassword").addClass('is-invalid');
        document.getElementById("nameErrMsg1").innerHTML = '<small class="text-danger"><strong> Confirm Password Field Cannot Empty....</strong></small>';
        return false;
    }
    else if (new_psswd != confirm_psswd) {
        $("#txtPassword").addClass('is-invalid');
        $("#txtConfirmPassword").addClass('is-invalid');
        document.getElementById("nameErrMsg1").innerHTML = '<small class="text-danger"><strong>Password and Confirm password not matched....</strong></small>';
        return false;
    }
    else if (new_psswd === confirm_psswd) {
        //$("#txtPassword").addClass('is-valid');
        //$("#txtConfirmPassword").addClass('is-valid');
        document.getElementById("txtPassword").classList.remove("is-invalid");
        document.getElementById("txtConfirmPassword").classList.remove("is-invalid");
       
        document.getElementById("nameErrMsg1").innerHTML = ' ';
        return true;
    }
}