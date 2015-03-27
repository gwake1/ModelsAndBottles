var app = angular.module("modelsAndBottles", ["ngRoute"])
    .config(function($routeProvider, $locationProvider) {
        $routeProvider.when("/Home", { templateUrl: "/AngularJs/Home/hTemplate.html", controller: "WinesHomeController" });
        $routeProvider.when("/Wine", { templateUrl: "/AngularJs/Wine/wTemplate.html", controller: "WinesController" });
        $routeProvider.when("/ListofWines", { templateUrl: "/AngularJs/WinesList/wlTemplate.html", controller: "ListofWinesController" });
        $routeProvider.otherwise({
            redirectTo: "/Home"
        });
    });
app.controller("WinesController", function() {

});