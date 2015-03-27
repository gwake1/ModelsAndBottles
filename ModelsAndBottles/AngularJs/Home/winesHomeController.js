app.controller("WinesHomeController", function($scope, $location)
    {
    $scope.wineList = function() {
        $location.path("/ListofWines");
    };
});