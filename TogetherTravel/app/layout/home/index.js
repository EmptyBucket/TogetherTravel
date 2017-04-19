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

    const searchCompanyElem = document.getElementById("searchCompany");
    const usersUrl = searchCompanyElem.dataset.usersUrl;
    const googleApiKey = searchCompanyElem.dataset.googleApiKey;
    const searchCompany = new SearchCompany({
        elem: searchCompanyElem,
        usersUrl: usersUrl,
        googleApiKey: googleApiKey
    });
}());