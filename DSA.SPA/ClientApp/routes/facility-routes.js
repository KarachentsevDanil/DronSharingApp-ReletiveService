import FacilityListPage from "../pages/facility/pages/facility-list/facility-list"
import DoctorListPage from "../pages/facility/pages/doctor-list/doctor-list"
import AnalyzesListPage from "../pages/facility/pages/analyzes-list/analyzes-list"
import DepartmentListPage from "../pages/facility/pages/department-list/department-list"
import ManipulationListPage from "../pages/facility/pages/manipulation-list/manipulation-list"
import DrugListPage from "../pages/facility/pages/drug-list/drug-list"

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
    },
    {
        path: "/departments",
        component: DepartmentListPage,
        beforeEnter: (to, from, next) => {
            routeGuards.validateRoute(to, from, next);
        }
    },
    {
        path: "/analyzes",
        component: AnalyzesListPage,
        beforeEnter: (to, from, next) => {
            routeGuards.validateRoute(to, from, next);
        }
    },
    {
        path: "/manipulations",
        component: ManipulationListPage,
        beforeEnter: (to, from, next) => {
            routeGuards.validateRoute(to, from, next);
        }
    },
    {
        path: "/drugs",
        component: DrugListPage,
        beforeEnter: (to, from, next) => {
            routeGuards.validateRoute(to, from, next);
        }
    }
];
