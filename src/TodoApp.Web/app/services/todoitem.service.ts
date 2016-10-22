import { Injectable } from "@angular/core";
import { Headers, Http, Response } from "@angular/http";

import { TodoItem } from "../model/todoitem";

import { Observable }     from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/catch';

//Service class for interaction with the WebAPI - using Promises
@Injectable()
export class TodoItemService {
    private apiURL = 'api/todo'; //WebAPI url

    constructor(private http: Http) {

    }
    getTodoItems(): Promise<TodoItem[]> {
        return this.http.get(this.apiURL)
            .toPromise()
            .then(response => response.json() as TodoItem[])
            .catch(this.handleError);                  
    }
    
    getTodoItem(id: string): Promise<TodoItem> {
        return this.http.get(this.apiURL + "/" + id)
            .toPromise()
            .then(response => response.json())            
            .catch(this.handleError);
    }

    createTodoItem(item: TodoItem): Promise<boolean> {
        return this.http.post(this.apiURL, item)
            .toPromise()
            .then(function () { return true })
            .catch(this.handleError);
    }

    updateTodoItem(item: TodoItem): Promise<boolean> {
        return this.http.put(this.apiURL + "/" + item.id, item)
            .toPromise()
            .then(function () { return true })
            .catch(this.handleError);
    }

    deleteTodoItem(id: string): Promise<boolean> {
        return this.http.delete(this.apiURL + "/" + id)
            .toPromise()
            .then(function () { return true })
            .catch(this.handleError);
    }

    toggleTodoItemCompleted(id: string): Promise<boolean> {
        return this.http.post(this.apiURL + "/toggleStatus/" + id, "")
            .toPromise()
            .then(function () { return true })
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('TodoItemService - An error occurred', error);
        return Promise.reject(error.message || error);
    }
}