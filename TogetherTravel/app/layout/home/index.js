import ComparySearcher from "../../modules/company-searcher/company-searcher.js";
import HeaderAnimator from "../../modules/header-animator/header-animator.js";

(function() {
    const headerAnimator = new HeaderAnimator({
        elem: document.getElementsByClassName("header__animated-sheet")[0],
        maxAnimatedSheetOffsetPercentage: 0.2,
        maxScrolledWindowOffsetPercentage: 0.3
    });
    
    const searchCompanyElem = document.getElementsByClassName("company-searcher")[0];
    const usersUrl = searchCompanyElem.dataset.usersUrl;
    const googleApiKey = searchCompanyElem.dataset.googleApiKey;
    const companySearcher = new ComparySearcher({
        elem: searchCompanyElem,
        usersUrl: usersUrl,
        googleApiKey: googleApiKey
    });
}());