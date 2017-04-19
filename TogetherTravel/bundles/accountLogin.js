webpackJsonp([3],{

/***/ 151:
/***/ (function(module, exports, __webpack_require__) {

// style-loader: Adds some css to the DOM by adding a <style> tag

// load the styles
var content = __webpack_require__(237);
if(typeof content === 'string') content = [[module.i, content, '']];
// add the styles to the DOM
var update = __webpack_require__(16)(content, {});
if(content.locals) module.exports = content.locals;
// Hot Module Replacement
if(false) {
	// When the styles change, update the <style> tags
	if(!content.locals) {
		module.hot.accept("!!../../../node_modules/css-loader/index.js!../../../node_modules/autoprefixer-loader/index.js?browsers=last 2 version!./login.css", function() {
			var newContent = require("!!../../../node_modules/css-loader/index.js!../../../node_modules/autoprefixer-loader/index.js?browsers=last 2 version!./login.css");
			if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
			update(newContent);
		});
	}
	// When the module is disposed, remove the <style> tags
	module.hot.dispose(function() { update(); });
}

/***/ }),

/***/ 155:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


__webpack_require__(151);

(function () {
    function disableLoginBtns() {
        var loginForm = document.forms.loginForm;
        loginForm.elements.loginBtn.disable = true;
        loginForm.elements.cancelBtn.disable = true;
    }

    function enableLoginBtns() {
        var loginForm = document.forms.loginForm;
        loginForm.elements.loginBtn.disable = false;
        loginForm.elements.cancelBtn.disable = false;
    }

    function beginLogin() {
        disableLoginBtns();
    }

    function successLogin() {
        var loginForm = document.forms.loginForm;
        if (loginForm.getElementsByClassName("field-validation-error").length || loginForm.getElementsByClassName("validation-summary-errors").length || loginForm.getElementsByClassName("input-validation-error").length) {
            enableLoginBtns();
        } else {
            var completeLoginMessage = document.createElement("div");
            completeLoginMessage.textContent = "You have successfully registered";
            completeLoginMessage.classList.add("alert", "alert-info", "complete-login-message");
            document.body.appendChild(completeLoginMessage);
            setTimeout(function () {
                completeLoginMessage.classList.add("complete-login-message_hidden");
            }, 0);
            setTimeout(function () {
                completeLoginMessage.parentElement.removeChild(completeLoginMessage);
            }, 5000);
            var homeIndexUrl = loginForm.dataset.homeIndexUrl;
            location.assign(homeIndexUrl);
        }
    }

    function failLogin() {
        disableLoginBtns();
    }

    window.beginLogin = beginLogin;
    window.successLogin = successLogin;
    window.failLogin = failLogin;
})();

/***/ }),

/***/ 237:
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__(13)(undefined);
// imports


// module
exports.push([module.i, ".complete-login-message {\r\n    position: fixed;\r\n    right: 0;\r\n    bottom: 0;\r\n    margin: 0;\r\n    -ms-opacity: 1;\r\n    opacity: 1;\r\n    z-index: 10000;\r\n    transition: opacity 5s ease-in-out;\r\n}\r\n\r\n.complete-login-message_hidden {\r\n    -ms-opacity: 0;\r\n    opacity: 0;\r\n}\r\n", ""]);

// exports


/***/ })

},[155]);
//# sourceMappingURL=accountLogin.js.map