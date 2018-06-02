import FacilityListPage from "../pages/facility/pages/facility-list/facility-list"
import DoctorListPage from "../pages/facility/pages/doctor-list/doctor-list"

import * as routeGuards from "./route-guards";

export default [
    {
        path: "/facilities",
        component: FacilityListPage,
        beforeEnter: (to, from, next) => {
            routeGuards.validateRoute(to, from, next);
        }
    },
    {
        path: "/doctors",
        component: DoctorListPage,
        beforeEnter: (to, from, next) => {
            routeGuards.validateRoute(to, from, next);
        }
    }
];
