angular.module('testApp').factory('httpService', ["$q", "$http", "mySpinnerService", function ($q, $http, mySpinnerService) {

    var doQuery = function (methodFunc) {
        mySpinnerService.start();
        var deferred = $q.defer();
        methodFunc()
            .success(deferred.resolve)
            .error(deferred.reject)
        .finally(function () {
            mySpinnerService.stop();
        })

        return deferred.promise;
    };

    return {
        get: function (url) { return doQuery(function () { return $http.get(url); }) }
    };

}]);