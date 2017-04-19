require("./login.css");

(function() {
    function disableLoginBtns() {
        const loginForm = document.forms.loginForm;
        loginForm.elements.loginBtn.disable = true;
        loginForm.elements.cancelBtn.disable = true;
    }

    function enableLoginBtns() {
        const loginForm = document.forms.loginForm;
        loginForm.elements.loginBtn.disable = false;
        loginForm.elements.cancelBtn.disable = false;
    }

    function beginLogin() {
        disableLoginBtns();
    }

    function successLogin() {
        const loginForm = document.forms.loginForm;
        if (loginForm.getElementsByClassName("field-validation-error").length ||
            loginForm.getElementsByClassName("validation-summary-errors").length ||
            loginForm.getElementsByClassName("input-validation-error").length) {
            enableLoginBtns();
        } else {
            const completeLoginMessage = document.createElement("div");
            completeLoginMessage.textContent = "You have successfully registered";
            completeLoginMessage.classList.add("alert",
                "alert-info",
                "complete-login-message");
            document.body.appendChild(completeLoginMessage);
            setTimeout(function() {
                    completeLoginMessage.classList.add("complete-login-message_hidden");
                },
                0);
            setTimeout(function() {
                    completeLoginMessage.parentElement.removeChild(completeLoginMessage);
                },
                5000);
            const homeIndexUrl = loginForm.dataset.homeIndexUrl;
            location.assign(homeIndexUrl);
        }
    }

    function failLogin() {
        disableLoginBtns();
    }

    window.beginLogin = beginLogin;
    window.successLogin = successLogin;
    window.failLogin = failLogin;
}());