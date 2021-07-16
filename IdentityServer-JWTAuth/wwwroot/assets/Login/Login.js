$(document).ready(function () {
    $('#btnLogin').click(function () {
        ValidateForm();
    })
});

function ValidateForm() {
    if (!$('#loginForm').valid()) {
        return false;
    }
}