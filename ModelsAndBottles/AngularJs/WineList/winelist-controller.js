wineModule.controller('WineListController', function($scope, $http,wineListData) {
    $scope.wine = $http.get()
});