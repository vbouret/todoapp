import { ModuleWithProviders }  from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { TodoListComponent }    from "./components/todolist.component";
import { TodoDetailComponent } from "./components/tododetail.component";

const appRoutes: Routes = [
    {
        path: '',
        component: TodoListComponent
    },
    {
        path: 'edit/:id',
        component: TodoDetailComponent
    },

];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);

