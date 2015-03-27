app.controller("ListofWinesController", function ($scope, $location, wineListService) {
    wineListService.getWineList().then(function(wlWine) { $scope.wine = wlWine;
        console.log(wlWine);
    });

    $scope.addNewWine = function () {
        $location.path("/newWineForm");
    };

});