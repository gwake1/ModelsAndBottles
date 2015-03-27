var app = angular.module("modelsAndBottles", ["ngRoute"])
.config(function($routeProvider, $locationProvider) {
    $routeProvider.when("/WineListsMVC/Index", { templateUrl: "/templates/WineList.html", controller: "WineListController" });
    $routeProvider.when("/WineListsMVC", { templateUrl: "/templates/WineList.html", controller: "WineListController" });
})
