require("./login.css");

(function () {
    const loginForm = document.forms.loginForm;
    const modalContainer = document.getElementById("modal-contaienr");

    function disableLoginBtns() {
        loginForm.elements.loginBtn.disable = true;
        loginForm.elements.cancelBtn.disable = true;
    }

    function enableLoginBtns() {
        loginForm.elements.loginBtn.disable = false;
        loginForm.elements.cancelBtn.disable = false;
    }

    function beginLogin() {
        disableLoginBtns();
    }

    function successLogin() {
        if (loginForm.getElementsByClassName("field-validation-error").length ||
            loginForm.getElementsByClassName("validation-summary-errors").length ||
            loginForm.getElementsByClassName("input-validation-error").length) {
            enableLoginBtns();
        } else {
            modalContainer.modal("hide");
        }
    }

    function failLogin() {
        disableLoginBtns();
    }

    window.beginLogin = beginLogin;
    window.successLogin = successLogin;
    window.failLogin = failLogin;
}());