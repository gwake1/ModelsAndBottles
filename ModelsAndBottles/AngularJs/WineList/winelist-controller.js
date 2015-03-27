app.controller('WineListController', function($scope, wineListService) {
    wineListService.get().then(function(wine) { $scope.wine = wine;
        console.log(wine);
    });
});