require("./profile.css");
export default function Profile(options) {
    const elem = options.elem;

    function render() {
        elem.classList.add("profile");
    }

    render();
}