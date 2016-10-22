"use strict";
var router_1 = require("@angular/router");
var todolist_component_1 = require("./components/todolist.component");
var tododetail_component_1 = require("./components/tododetail.component");
var appRoutes = [
    {
        path: '',
        component: todolist_component_1.TodoListComponent
    },
    {
        path: 'edit/:id',
        component: tododetail_component_1.TodoDetailComponent
    },
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map