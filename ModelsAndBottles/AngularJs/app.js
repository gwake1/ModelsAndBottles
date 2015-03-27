var app = angular.module("modelsAndBottles", ["ngRoute", "ngResource"])
    .config(function($routeProvider, $locationProvider) {
        $routeProvider.when("/Home", { templateUrl: "/AngularJs/Home/hTemplate.html", controller: "WinesHomeController" });
        $routeProvider.when("/Wine", { templateUrl: "/AngularJs/Wine/wTemplate.html", controller: "WinesController" });
        $routeProvider.when("/WineInventory", { templateUrl: "/AngularJs/WinesList/wlTemplate.html", controller: "WineInventoryController" });
    $routeProvider.when("/WineInventory/:Id", { templateUrl: "/AngularJs/WineDetail/wdTemplate.html", controller: "WineDetailController" });
        $routeProvider.otherwise({
            redirectTo: "/Home"
        });
    });
app.controller("WinesController", function ($rootScope, $scope, WinesService, $location) {
    $scope.submitNewWine = function(newWine) {
        WinesService.put(newWine);
        $location.path("/WineInventory");
    };
});
app.factory("WinesService", function($resource) {
    return {
        put: function (wine) {
            //var vintage.WineVintage.VintageMaturityId = 7;
            //vintage.Terroir.Region = wine.Terroir.Region;
            //vintage.Terroir.Country = wine.Terroir.Country;
            //vintage.Terroir.Appelation = wine.Terroir.Appelation;
            //vintage.WineList.Name = wine.Name;
            //vintage.WineVintage.VintageYear = wine.Year;
            //Vintage.WineVintage.Rating
            //vintage.WineVintage.WineList.Name = wine.Name;
            //$resource("api/VintageMaturities").save(vintage);
        }
    }
});

app.controller("WineInventoryController", function ($scope, $location, wineListService) {
    wineListService.getWineList().then(function (wlWine) {
        $scope.wine = wlWine;
        console.log(wlWine);
    });
    $scope.getWine = function(id) {
        $location.path("/WineInventory/" + id);
    }

    $scope.addNewWine = function () {
        $location.path("/newWineForm");
    };
});
app.factory("wineListService", function ($http, $q) {
    return {
        getWineList: function () {
            var deferred = $q.defer();
            $http.get("/api/WineLists").success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});

app.controller("WineDetailController", function($scope, $q, $http, $location, $routeParams, wineDetailService) {
    var id = $routeParams.Id;
    $http.get('api/Wines/' + id).success(function(data) {
        $scope.wine = data;
        console.log(data);
    }).error(function (err) { console.log(err); });

    //wineDetailService.getWineDetail(id).then(function(wdWine) {
    //    $scope.wine = wdWine;
    //    console.log(wdWine);
    //});
});
app.factory("wineDetailService", function($http, $q) {
    return {
        getWineDetail: function(id) {
            var deferred = $q.defer();
            $http.get("/api/WineLists/" + id).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
        
}
});