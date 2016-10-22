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
var common_1 = require("@angular/common");
var todoitem_service_1 = require("../services/todoitem.service");
var TodoDetailComponent = (function () {
    function TodoDetailComponent(todoItemService, route, location) {
        this.todoItemService = todoItemService;
        this.route = route;
        this.location = location;
    }
    TodoDetailComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params.forEach(function (params) {
            var id = params['id'];
            _this.loadTodoItem(id);
        });
        this.isSaved = false;
        this.isError = false;
    };
    TodoDetailComponent.prototype.loadTodoItem = function (id) {
        var _this = this;
        this.todoItemService.getTodoItem(id)
            .then(function (todoItem) { return _this.todoItem = todoItem; });
    };
    TodoDetailComponent.prototype.goBack = function () {
        this.location.back();
    };
    TodoDetailComponent.prototype.setErrorAlert = function () {
        this.isSaved = false;
        this.isError = true;
    };
    TodoDetailComponent.prototype.setSucessAlert = function () {
        this.isSaved = true;
        this.isError = false;
    };
    TodoDetailComponent.prototype.saveTodoItem = function () {
        var _this = this;
        this.todoItemService.updateTodoItem(this.todoItem)
            .then(function (result) { return _this.setSucessAlert(); })
            .catch(function (error) { return _this.setErrorAlert(); });
    };
    TodoDetailComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'tododetail',
            templateUrl: 'tododetail.component.html',
            providers: [todoitem_service_1.TodoItemService]
        }), 
        __metadata('design:paramtypes', [todoitem_service_1.TodoItemService, router_1.ActivatedRoute, common_1.Location])
    ], TodoDetailComponent);
    return TodoDetailComponent;
}());
exports.TodoDetailComponent = TodoDetailComponent;
//# sourceMappingURL=tododetail.component.js.map