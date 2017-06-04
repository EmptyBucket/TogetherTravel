require("./movable-navbar.css");
require("./movable-navbar_moving.css");

export default function MovableNavBar(options) {
    const { elem, registerUrl, loginUrl, modalContainer } = options;

    elem.getElementsByClassName("navbar__registration-btn")[0]
        .addEventListener("click",
            function(e) {
                $.get(registerUrl,
                    function(html) {
                        $(modalContainer).html(html);
                        $(modalContainer).modal("toggle");
                    });
            });

    elem.getElementsByClassName("navbar__login-btn")[0]
        .addEventListener("click",
            function(e) {
                $.get(loginUrl,
                    function(html) {
                        $(modalContainer).html(html);
                        $(modalContainer).modal("show");
                    });
            });

    let isWhiteBackground = false;
    document.addEventListener("scroll",
        function(e) {
            if (window.pageYOffset > 0) {
                if (!isWhiteBackground) {
                    isWhiteBackground = true;
                    elem.classList.add("navbar-movable_moving");
                }
            } else if (isWhiteBackground) {
                isWhiteBackground = false;
                elem.classList.remove("navbar-movable_moving");
            }
        });
}