angular.module('testApp').directive('mySpinner', [function () {
    return {
        restrict: 'E',
        link: function (scope, e, a) {
            scope.srcGif = a.img;

            scope.$on("Loading", function (event, data) {
                scope.loading = data;
            });
        },
        template: "<div ng-show=\"loading\" ng-init=\"loading=false\" style=\"position: absolute; width: 100%; height: 100%;  opacity: 0.9; z-index: 9999; \"><div style=\"position: fixed; margin: auto; height: 100%; width: 100%; background-color: #F5F5F5;\"><img style=\"position: fixed; top: 45%; left: 45%; display: block;  \" ng-src=\"{{srcGif}}\" /></div></div>"

    };

}]);

