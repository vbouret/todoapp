import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { TodoItem } from "../model/todoitem";
import { TodoItemService } from "../services/todoitem.service";

@Component({
    moduleId: module.id,
    selector: 'todolist',
    templateUrl: 'todolist.component.html',
    providers: [TodoItemService]
})
export class TodoListComponent implements OnInit {
    todoItemList: TodoItem[];
    newTodoItem: TodoItem;

    constructor(private router: Router, private todoItemService: TodoItemService) {
        this.newTodoItem = new TodoItem();
    }

    ngOnInit(): void {
        this.refreshTodoItems();
    }

    refreshTodoItems(): void {
        this.todoItemService.getTodoItems()
            .then(result => this.processResult(result));
    }

    createTodoItem(): void {
        this.todoItemService.createTodoItem(this.newTodoItem)
            .then(result => this.refreshTodoItems())
            .catch(result => alert("Unable to create"));
    }

    deleteTodoItem(id: string): void {
        this.todoItemService.deleteTodoItem(id)
            .then(result => this.refreshTodoItems())
            .catch(result => alert("Unable to delete"));
    }

    processResult(result: TodoItem[]): void {
        this.todoItemList = result;
    }

    toggleStatus(id: string): void {
        this.todoItemService.toggleTodoItemCompleted(id)
            .then(result => this.refreshTodoItems())
            .catch(result => alert("Update failed"));
    }

    editTodoItem(id: string): void {
        this.router.navigate(['/edit', id]);
    }
}