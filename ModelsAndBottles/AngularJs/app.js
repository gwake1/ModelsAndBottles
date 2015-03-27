var app = angular.module("modelsAndBottles", ["ngRoute"])
    .config(function($routeProvider, $locationProvider) {
        $routeProvider.when("/Home", { templateUrl: "/AngularJs/Home/hTemplate.html", controller: "WinesHomeController" });
        $routeProvider.when("/Wine", { templateUrl: "/AngularJs/Wine/wTemplate.html", controller: "WinesController" });
        $routeProvider.when("/WineListsMVC", { templateUrl: "/AngularJs/WineList/WineList.html", controller: "WineListController" });
        $routeProvider.otherwise({
            redirectTo: "/Home"
        });
    });
