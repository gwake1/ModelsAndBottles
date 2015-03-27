app.controller("WinesController", function ($scope, wineService) {
    wineService.getWines().then(function (wWine) {
        $scope.wine = wWine;
        console.log(wWine);
    });
    $scope.submitForm = function() {
        $scope.addNewWine = angular.copy($scope.newWine);
    };
    $scope.cancelForm = function() {
        
    }
});