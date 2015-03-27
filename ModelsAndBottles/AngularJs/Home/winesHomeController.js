app.controller("WinesHomeController", function($scope, $location)
{
    $scope.addNewWine = function() {
        $location.path("/newWineForm");
    };
    $scope.viewWines = function() {
        $location.path("/WineListMVC");
    };
});