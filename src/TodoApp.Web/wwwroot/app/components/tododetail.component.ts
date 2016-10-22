import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params } from "@angular/router";
import { Location } from "@angular/common";

import { TodoItem } from "../model/todoitem";
import { TodoItemService } from "../services/todoitem.service";

@Component({
    moduleId: module.id,
    selector: 'tododetail',
    templateUrl: 'tododetail.component.html',
    providers: [TodoItemService]
})
export class TodoDetailComponent implements OnInit {
    todoItem: TodoItem;
    isSaved: boolean;
    isError: boolean;

    constructor(private todoItemService: TodoItemService, private route: ActivatedRoute, private location: Location) {

    }
    ngOnInit(): void {
        this.route.params.forEach((params: Params) => {
            let id = params['id'];
            this.loadTodoItem(id);
        });

        this.isSaved = false;
        this.isError = false;
    }

    loadTodoItem(id: string): void {
        this.todoItemService.getTodoItem(id)
            .then(todoItem => this.todoItem = todoItem);
    }

    goBack(): void {
        this.location.back();
    }

    setErrorAlert(): void {
        this.isSaved = false;
        this.isError = true;
    }
    setSucessAlert(): void {
        this.isSaved = true;
        this.isError = false;
    }
    saveTodoItem(): void {
        this.todoItemService.updateTodoItem(this.todoItem)
            .then(result => this.setSucessAlert())
            .catch(error => this.setErrorAlert());
    }
}