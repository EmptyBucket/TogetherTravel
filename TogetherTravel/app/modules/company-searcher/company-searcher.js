require("./company-searcher.css");
import Map from "../map/map.js";
import ProfileCard from "../profileCard/profile-card.js";
import PrivateChat from "../privateChat/privateChat.jsx";

export default function CompanySearcher(options) {
    const elem = options.elem;
    const usersUrl = options.usersUrl;
    const googleApiKey = options.googleApiKey;

    const mapElem = document.createElement("div");
    const profileElem = document.createElement("div");
    const privateChatElem = document.createElement("div");

    const myCompanyes = [];

    function selectUser(e) {
        const userId = this.get("userId");
        fetch(`${options.userUrl}?userId=${userId}`, { method: "POST" })
            .then(user => {
                var searchUser = myCompanyes.find(item => item.userId);
                if (!searchUser) {
                    searchUser = {
                        userId: userId,
                        profileCard: new ProfileCard({
                            elem: profileElem,
                            user: user
                        })
                    };
                    myCompanyes.push(searchUser);   
                }
                searchUser.profileCard.render();
            });
        $(elem)
            .html("")
            .append($("<div>", { "class": "container-fluid" })
                .append($("<div>", { "class": "row" })
                    .append($("<div>", { "class": "col-xs-6" })
                        .append(mapElem))
                    .append($("<div>", { "class": "col-xs-6" })
                        .append(profileElem)))
                .append($("<div>", { "class": "row" })
                    .append($("<div>", { "class": "col-xs-12" })
                        .append(privateChatElem))));
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
        //const privateChat = new PrivateChat({
        //    elem: privateChatElem
        //});
    }

    render();
};