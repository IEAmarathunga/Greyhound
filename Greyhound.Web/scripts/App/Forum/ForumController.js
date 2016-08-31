appGreyhound.controller('ForumController', ['$uibModal','$scope', function ($uibModal, $scope) {
    $scope.showMannual = function () {
        $uibModal.open({
            animation: true,
            templateUrl: 'App/Views/Forum/ForumMannual.html',
            controller: '',
            size: 'lg'
        });
    }
}]);