import UserListPage from "../pages/user/pages/user-list/user-list";

import * as routeGuards from "./route-guards";

export default [{
        path: "/user-list",
        component: UserListPage,
        beforeEnter: (to, from, next) => {
            routeGuards.validateRoute(to, from, next);
        }
    }
];
