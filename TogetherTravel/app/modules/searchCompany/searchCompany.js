require("./search-company.css");
import Map from "../map/map.js";
import Profile from "../profile/profile.js";
import PrivateChat from "../privateChat/privateChat.jsx"

export default function SearchCompany(options) {
    const elem = options.elem;
    const mapElem = document.createElement("div");
    const usersUrl = options.usersUrl;
    const googleApiKey = options.googleApiKey;
    const profileElem = document.createElement("div");
    const privateChatElem = document.createElement("div");

    function cancelSelectUser() {
        
    }

    function selectUser(e) {
        console.log(e);
    }

    function render() {
        elem.classList.add("search-company");
        elem.appendChild(mapElem);

        const map = new Map({
            elem: mapElem,
            usersUrl: usersUrl,
            googleApiKey: googleApiKey,
            markerClick: selectUser
        });
        const profile = new Profile({
            elem: profileElem
        });
        //const privateChat = new PrivateChat({
        //    elem: privateChatElem
        //});
    }

    render();
}