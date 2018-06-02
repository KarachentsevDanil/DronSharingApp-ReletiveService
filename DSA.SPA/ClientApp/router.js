import Vue from "vue";
import VueRouter from "vue-router";
import HomePage from './pages/layout/home-page'
import LoginPage from "./pages/auth/pages/login";

import authorizationRoutes from "./routes/authorization-routes";
import facilityRoutes from "./routes/facility-routes";
import residentRoutes from "./routes/resident-routes";
import userRoutes from "./routes/user-routes";

Vue.use(VueRouter);

const routes = [{
        path: "/home",
        component: HomePage
    },
    ...authorizationRoutes,
    ...facilityRoutes,
    ...residentRoutes,
    ...userRoutes,
    {
        path: "*",
        component: LoginPage
    }
];

let router = new VueRouter({
    mode: "history",
    routes
});

export default router;
