angular.module('flightApp')
	.factory('flightStorage', function ($http, $injector) {
	    'use strict';
	    return $http.get('/api/gate')
			.then(function () {
			    return $injector.get('api');
			});
	})

	.factory('api', function ($http) {
	    'use strict';

	    var store = {
	        gates: [],

	        addFlight: function (flight) {
	            var orig = store.gates;
	            return $http.post('/api/gate/addFlight', flight)
					.then(function success(resp) {
					    flight.flightId = resp.flight.flightId;
					    store.gates.push(todo);
					    return store.gates;
					}, function error() {
					    angular.copy(orig, store.gates);
					    return store.gates;
					});
	        },
	        removeFlight: function (flight) {
	            var orig = store.gates;
	            store.gates.splice(store.gates.indexOf(flight), 1);
	            return $http.post('/api/gate/remoteFlight', flight)
					.then(function success(resp) {
					    return store.gates;
					}, function error() {
					    angular.copy(orig, store.gates);
					    return store.gates;
					});
	        },
	        updateFlight: function (flight) {
	            var orig = store.gates.slice(0);

	            return $http.put('/api/gates/updateFlight', todo)
					.then(function success() {
					    return store.gates;
					}, function error() {
					    angular.copy(orig, store.gates);
					    return orig;
					});
	        },
	        addGate: function (gate) {

	        },
	        getFlights: function (data) {
	            console.log(data);
	            var vars = Object.keys(data).map(function (key) { return key + '=' + data[key]; }).join("&");
	            console.log(vars);
	            return $http.get('/api/gate?'+ vars)
					.then(function (resp) {
					    angular.copy(resp.data, store.gates);
					    console.log(store.gates);
					    return store.gates;
					});
	        },
	    };

	    return store;
	});

	
