app.factory("wineListService", function ($http, $q) {
 return {
     getWineList: function() {
         var deferred = $q.defer();
         $http.get("/api/WineLists").success(deferred.resolve).error(deferred.reject);
         return deferred.promise;
     }
 }   
});