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
var router_1 = require("@angular/router");
var todoitem_1 = require("../model/todoitem");
var todoitem_service_1 = require("../services/todoitem.service");
var TodoListComponent = (function () {
    function TodoListComponent(router, todoItemService) {
        this.router = router;
        this.todoItemService = todoItemService;
        this.newTodoItem = new todoitem_1.TodoItem();
    }
    TodoListComponent.prototype.ngOnInit = function () {
        this.refreshTodoItems();
    };
    TodoListComponent.prototype.refreshTodoItems = function () {
        var _this = this;
        this.todoItemService.getTodoItems()
            .then(function (result) { return _this.processResult(result); });
    };
    TodoListComponent.prototype.createTodoItem = function () {
        var _this = this;
        this.todoItemService.createTodoItem(this.newTodoItem)
            .then(function (result) { return _this.refreshTodoItems(); })
            .catch(function (result) { return alert("Unable to create"); });
    };
    TodoListComponent.prototype.deleteTodoItem = function (id) {
        var _this = this;
        this.todoItemService.deleteTodoItem(id)
            .then(function (result) { return _this.refreshTodoItems(); })
            .catch(function (result) { return alert("Unable to delete"); });
    };
    TodoListComponent.prototype.processResult = function (result) {
        this.todoItemList = result;
    };
    TodoListComponent.prototype.toggleStatus = function (id) {
        var _this = this;
        this.todoItemService.toggleTodoItemCompleted(id)
            .then(function (result) { return _this.refreshTodoItems(); })
            .catch(function (result) { return alert("Update failed"); });
    };
    TodoListComponent.prototype.editTodoItem = function (id) {
        this.router.navigate(['/edit', id]);
    };
    TodoListComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'todolist',
            templateUrl: 'todolist.component.html',
            providers: [todoitem_service_1.TodoItemService]
        }), 
        __metadata('design:paramtypes', [router_1.Router, todoitem_service_1.TodoItemService])
    ], TodoListComponent);
    return TodoListComponent;
}());
exports.TodoListComponent = TodoListComponent;
//# sourceMappingURL=todolist.component.js.map