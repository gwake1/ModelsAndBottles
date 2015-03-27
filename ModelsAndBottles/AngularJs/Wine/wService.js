app.factory("wineService", function ($http, $q) {
    return {
        getWines: function () {
            var deferred = $q.defer();
            $http.get("/api/Wines").success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});