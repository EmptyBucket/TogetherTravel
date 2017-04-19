require("./layout.css");
require("../../base/body.css");
require("font-awesome-webpack");

(function() {
    const modalContainer = document.getElementById("modalContainer");
    const accountContainer = document.getElementById("accountContainer");
    const registerUrl = accountContainer.dataset.accountRegistrationUrl;
    const loginUrl = accountContainer.dataset.accountLoginUrl;

    document.getElementById("registrationButton")
        .addEventListener("click",
            function(e) {
                $.get(registerUrl,
                    function(html) {
                        $(modalContainer).html(html);
                        $(modalContainer).modal("toggle");
                    });
            });

    document.getElementById("loginButton")
        .addEventListener("click",
            function(e) {
                $.get(loginUrl,
                    function(html) {
                        $(modalContainer).html(html);
                        $(modalContainer).modal("show");
                    });
        });

    var menu = document.getElementsByClassName("navbar")[0];
    var isWhiteBackground = false;
    document.addEventListener("scroll",
        function (e) {
            if (window.pageYOffset > 0) {
                if (!isWhiteBackground) {
                    isWhiteBackground = true;
                    menu.classList.add("navbar-movable_moving");
                }
            } else if (isWhiteBackground) {
                isWhiteBackground = false;
                menu.classList.remove("navbar-movable_moving");
            }
        });
}());