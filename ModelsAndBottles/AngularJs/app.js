var app = angular.module("ModelsAndBottles", ['ngRoute'])
.config(function($routeProvider, $locationProvider) {
    $routeProvider.when('/WineListsMVC', { templateUrl: '/templates/WineList.html', controller: 'WineListController' });
})
