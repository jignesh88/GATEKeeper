var app = angular.module("flightApp", ["ngRoute"]);

app.config(function ($routeProvider) {

    var routeConfig = {
        controller: 'flightController',
        templateUrl: '/app/modules/flight/templates/gateList.tmp.html',
        resolve: {
            store: function (fligthStorage) {
                // Get the correct module (API or localStorage).
                return fligthStorage.then(function (module) {
                    module.get(); // Fetch the todo records in the background.
                    return module;
                });
            }
        }
    };

    $routeProvider
        .when('/', routeConfig)
        .when('/:status', routeConfig)
        .otherwise({
            redirectTo: '/'
        });

});