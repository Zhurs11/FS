angular.module('testApp').controller('directoryCtrl', ["$scope", "directoryService", function ($scope, directoryService) {

    $scope.directories = [];
    $scope.files = [];
    $scope.currentPass = '';
    $scope.lessCount = 0;
    $scope.betweenCount = 0;
    $scope.moreCount = 0;

    $scope.getDirectories = function (path) {
        directoryService.getDirs(path).then(function (data) {
            $scope.directories = data.Directories;
            $scope.files = data.Files;
            $scope.currentPass = data.CurrentPath;
            $scope.lessCount = data.FilesCount.LessCount;
            $scope.betweenCount = data.FilesCount.BetweenCount;
            $scope.moreCount = data.FilesCount.MoreCount;
        }, function () {
            alert('WTF');
        });
    };

    $scope.up = function () {
        var s = "";
        var path = $scope.currentPass.split('\\');
        if (path[1] !== "") {
            path.pop();
            s = path.join('\\')
            if (path.length == 1) {
                s = path[0] + '\\';
            }
        }

        $scope.getDirectories(s);
    };

    $scope.getDirectories("");
}]);


angular.module('testApp').factory('directoryService', ["httpService", function (httpService) {
    return {
        getDirs: function (path) {
            return httpService.get('/api/DirectoryApi/?path=' + path);
        }
    };
}]);