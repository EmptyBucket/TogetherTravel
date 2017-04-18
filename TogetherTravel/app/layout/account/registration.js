require("./registration.css");
require("jquery-ajax-unobtrusive");

(function() {
    const modalContainer = document.getElementById("modalContainer");

    function disableRegistrationFormBtns() {
        const registrationForm = document.forms.registrationForm;
        registrationForm.elements.submitBtn.disabled = true;
        registrationForm.elements.cancelBtn.disabled = true;
    }

    function enableRegistrationFormBtns() {
        const registrationForm = document.forms.registrationForm;
        registrationForm.elements.submitBtn.disabled = false;
        registrationForm.elements.cancelBtn.disabled = false;
    }

    function registrationBegin() {
        disableRegistrationFormBtns();
    }

    function registrationSuccess() {
        const registrationForm = document.forms.registrationForm;
        if (registrationForm.getElementsByClassName("field-validation-error").length ||
            registrationForm.getElementsByClassName("validation-summary-errors").length ||
            registrationForm.getElementsByClassName("input-validation-error").length) {
            enableRegistrationFormBtns();
        }
        else {
            const completeRegistrationMessage = document.createElement("div");
            completeRegistrationMessage.textContent = "You have successfully registered";
            completeRegistrationMessage.classList.add("alert", "alert-info",
                "complete-registration-message");
            document.body.appendChild(completeRegistrationMessage);
            setTimeout(function() {
                completeRegistrationMessage.classList.add("complete-registration-message_hidden");
            }, 0);
            setTimeout(function() {
                    completeRegistrationMessage.parentElement.removeChild(completeRegistrationMessage);
                },
                5000);
            $(modalContainer).modal("hide");
        }
    }

    function registrationFail() {
        enableRegistrationFormBtns();
    }

    window.registrationBegin = registrationBegin;
    window.registrationSuccess = registrationSuccess;
    window.registrationFail = registrationFail;
}());
