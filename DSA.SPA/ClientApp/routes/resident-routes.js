import AddRelativePage from "../pages/resident/pages/add-relative/add-relative";
import ResidentDetailsPage from "../pages/resident/pages/resident-details/resident-details";
import ResidentListPage from "../pages/resident/pages/resident-list/resident-list";
import ResidentContactListPage from "../pages/resident/pages/resident-contact/resident-contact-list";

import * as routeGuards from "./route-guards";

export default [{
        path: "/resident-list",
        component: ResidentListPage,
        beforeEnter: (to, from, next) => {
            routeGuards.validateRoute(to, from, next);
        }
    },
    {
        path: "/resident-contacts",
        component: ResidentContactListPage,
        beforeEnter: (to, from, next) => {
            routeGuards.validateRoute(to, from, next);
        }
    },
    {
        path: "/add-relative",
        component: AddRelativePage,
        beforeEnter: (to, from, next) => {
            routeGuards.validateRoute(to, from, next);
        }
    },
    {
        path: "/resident-details/:id",
        props: true,
        component: ResidentDetailsPage,
        beforeEnter: (to, from, next) => {
            routeGuards.validateRoute(to, from, next);
        }
    }
];
