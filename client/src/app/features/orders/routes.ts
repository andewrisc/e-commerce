import { Route } from "@angular/router";
import { authGuard } from "../../core/guards/auth.guard";
import { OrderComponent } from "./order/order.component";
import { OrderDetailedComponent } from "./order-detailed.component";
import { orderCompleteGuard } from "../../core/guards/order-complete.guard";
export const orderRoutes: Route[] = [
    { path: '', component: OrderComponent, canActivate: [authGuard, orderCompleteGuard] },
    { path: ':id', component: OrderDetailedComponent, canActivate: [authGuard] },
]