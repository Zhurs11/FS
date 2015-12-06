angular.module('testApp').factory('mySpinnerService', ["$rootScope", function ($rootScope) {
    return {
        start: function () {

            $rootScope.$broadcast("Loading", true);
        },
        stop: function () {
            $rootScope.$broadcast("Loading", false);
        }
    };
}]);