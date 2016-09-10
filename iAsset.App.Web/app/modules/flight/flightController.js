angular.module('flightApp')
	.controller('flightController', function TodoCtrl($scope, $routeParams, $filter, store) {
	    'use strict';

	    var self = this;

	    var gates = [];
        
	    self.title = 'Welcome to gate keeper..';
	    
	    self.gates = function () {
	        return store.getFlights({ id: 1, date: moment().format("YYYY-MM-DD") });
	    };


	    //$scope.$watch('todos', function () {
	    //    $scope.remainingCount = $filter('filter')(todos, { completed: false }).length;
	    //    $scope.completedCount = todos.length - $scope.remainingCount;
	    //    $scope.allChecked = !$scope.remainingCount;
	    //}, true);

	    //// Monitor the current route for changes and adjust the filter accordingly.
	    //$scope.$on('$routeChangeSuccess', function () {
	    //    var status = $scope.status = $routeParams.status || '';
	    //    $scope.statusFilter = (status === 'active') ?
		//		{ completed: false } : (status === 'completed') ?
		//		{ completed: true } : {};
	    //});

	    self.addFlight = function () {
	        var newTodo = {
	            title: $scope.newTodo.trim(),
	            completed: false
	        };

	        if (!newTodo.title) {
	            return;
	        }

	        $scope.saving = true;
	        store.insert(newTodo)
				.then(function success() {
				    $scope.newTodo = '';
				})
				.finally(function () {
				    $scope.saving = false;
				});
	    };

	    self.ediFlight = function (todo) {
	        
	    };

	    $scope.saveEdits = function (todo, event) {
	        // Blur events are automatically triggered after the form submit event.
	        // This does some unfortunate logic handling to prevent saving twice.
	        if (event === 'blur' && $scope.saveEvent === 'submit') {
	            $scope.saveEvent = null;
	            return;
	        }

	        $scope.saveEvent = event;

	        if ($scope.reverted) {
	            // Todo edits were reverted-- don't save.
	            $scope.reverted = null;
	            return;
	        }

	        todo.title = todo.title.trim();

	        if (todo.title === $scope.originalTodo.title) {
	            $scope.editedTodo = null;
	            return;
	        }

	        store[todo.title ? 'put' : 'delete'](todo)
				.then(function success() { }, function error() {
				    todo.title = $scope.originalTodo.title;
				})
				.finally(function () {
				    $scope.editedTodo = null;
				});
	    };
        
	    $scope.removeFlight = function (flight) {
	        store.delete(flight);
	    };

	    $scope.saveFlight = function (flight) {
	        store.put(flight);
	    };

	});
