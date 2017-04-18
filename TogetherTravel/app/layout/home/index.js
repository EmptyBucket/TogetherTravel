require("./index.css");
import SearchCompany from "../../modules/searchCompany/searchCompany.js";

(function() {
    var visibleYSize = Math.max(
        document.documentElement.offsetHeight,
        document.body.offsetHeight,
        document.documentElement.clientHeight,
        document.body.clientHeight);
    var animatedSheet = document.getElementsByClassName("header__animated-sheet")[0];
    var maxAnimatedSheetOffset = 60;
    var isMaxAnimatedSheetOffset = false;
    document.addEventListener("scroll",
        function(e) {
            var pageYOffset = window.pageYOffset;
            var scrolledPercent = pageYOffset / visibleYSize;
            if (scrolledPercent < 0.2) {
                isMaxAnimatedSheetOffset = false;
                var sheetOffset = scrolledPercent * 100 * 3;
                animatedSheet.style.backgroundPositionY = sheetOffset + "%";
            } else if (!isMaxAnimatedSheetOffset) {
                isMaxAnimatedSheetOffset = true;
                animatedSheet.style.backgroundPositionY = maxAnimatedSheetOffset + "%";
            }
        });

    var menu = document.getElementsByClassName("menu")[0];
    var isWhiteBackground = false;
    document.addEventListener("scroll",
        function(e) {
            if (window.pageYOffset > 0) {
                if (!isWhiteBackground) {
                    isWhiteBackground = true;
                    menu.classList.add("menu_moved");
                }
            } else if(isWhiteBackground) {
                isWhiteBackground = false;
                menu.classList.remove("menu_moved");
            }
        });

    const searchCompanyElem = document.getElementById("searchCompany");
    const usersUrl = searchCompanyElem.dataset.usersUrl;
    const googleApiKey = searchCompanyElem.dataset.googleApiKey;
    const searchCompany = new SearchCompany({
        elem: searchCompanyElem,
        usersUrl: usersUrl,
        googleApiKey: googleApiKey
    });

    const modalContainer = document.getElementById("modalContainer");
    const accountContainer = document.getElementById("accountContainer");
    const registerUrl = accountContainer.dataset.registrationUrl;
    const loginUrl = accountContainer.dataset.loginUrl;

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
}());