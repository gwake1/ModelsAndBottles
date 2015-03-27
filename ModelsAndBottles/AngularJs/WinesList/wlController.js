app.controller("WineInventoryController", function ($scope, $location, wineListService) {
    wineListService.getWineList().then(function(wlWine) { $scope.wine = wlWine;
        console.log(wlWine);
    });

    $scope.addNewWine = function () {
        $location.path("/newWineForm");
    };

});