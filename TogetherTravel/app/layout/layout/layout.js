require("../../base/body.css");
require("font-awesome-webpack");
import MovableNavbar from "../../modules/movable-navbar/movable-navbar.js";

(function() {
    const navbar = document.getElementsByClassName("navbar")[0];
    const registerUrl = navbar.dataset.accountRegistrationUrl;
    const loginUrl = navbar.dataset.accountLoginUrl;
    const modalContainer = document.getElementById("modalContainer");
    const movableNavBar = MovableNavbar({
        elem: navbar,
        registerUrl: registerUrl,
        loginUrl: loginUrl,
        modalContainer: modalContainer
    });
}());