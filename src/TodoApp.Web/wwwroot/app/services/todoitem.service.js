"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
require('rxjs/add/operator/toPromise');
require('rxjs/add/operator/catch');
//Service class for interaction with the WebAPI - using Promises
var TodoItemService = (function () {
    function TodoItemService(http) {
        this.http = http;
        this.apiURL = 'api/todo'; //WebAPI url
    }
    TodoItemService.prototype.getTodoItems = function () {
        return this.http.get(this.apiURL)
            .toPromise()
            .then(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    TodoItemService.prototype.getTodoItem = function (id) {
        return this.http.get(this.apiURL + "/" + id)
            .toPromise()
            .then(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    TodoItemService.prototype.createTodoItem = function (item) {
        return this.http.post(this.apiURL, item)
            .toPromise()
            .then(function () { return true; })
            .catch(this.handleError);
    };
    TodoItemService.prototype.updateTodoItem = function (item) {
        return this.http.put(this.apiURL + "/" + item.id, item)
            .toPromise()
            .then(function () { return true; })
            .catch(this.handleError);
    };
    TodoItemService.prototype.deleteTodoItem = function (id) {
        return this.http.delete(this.apiURL + "/" + id)
            .toPromise()
            .then(function () { return true; })
            .catch(this.handleError);
    };
    TodoItemService.prototype.toggleTodoItemCompleted = function (id) {
        return this.http.post(this.apiURL + "/toggleStatus/" + id, "")
            .toPromise()
            .then(function () { return true; })
            .catch(this.handleError);
    };
    TodoItemService.prototype.handleError = function (error) {
        console.error('TodoItemService - An error occurred', error);
        return Promise.reject(error.message || error);
    };
    TodoItemService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], TodoItemService);
    return TodoItemService;
}());
exports.TodoItemService = TodoItemService;
//# sourceMappingURL=todoitem.service.js.map