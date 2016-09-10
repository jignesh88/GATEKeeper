var app = angular.module("flightApp", ["ngRoute"]);

app.config(function ($routeProvider) {

    var routeConfig = {
        controller: 'flightController',
        controllerAs : 'vm',
        templateUrl: '/app/modules/flight/templates/gateList.tmp.html',
        resolve: {
            store: function (flightStorage) {
                return flightStorage.then(function (module) {
                    console.log(module);
                    module.getFlights({ id: 1, date: moment().format("YYYY-MM-DD") });
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