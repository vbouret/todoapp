import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";

import { routing } from "./app.routing";

import { AppComponent } from "./components/app.component";
import { TodoListComponent } from "./components/todolist.component";
import { TodoDetailComponent } from "./components/tododetail.component";

import { TodoItemService } from "./services/todoitem.service";


@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        routing
    ],
    declarations: [
        AppComponent,
        TodoListComponent,
        TodoDetailComponent
    ],
    providers: [
        TodoItemService
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }