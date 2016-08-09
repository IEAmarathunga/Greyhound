appGreyhound
.controller('ResetPasswordController', ['$scope', '$http', 'urls','$location', function ($scope, $http, urls, $location) {

    $scope.showContent = true;
    $scope.ResetPassword = function () {
        
        $scope.success = false;
        $scope.fail = false;

        var dataObj = {
            UserId: $location.search().userId,
            Code: $location.search().code,
            Password: $scope.password
        };

        $scope.navigateToPath = '#/';

        var httpRequest = $http({
            method: 'POST',
            url: urls.api + 'User/ResetPswd',
            data: JSON.stringify(dataObj)
        }).success(function (data, status) {
            $scope.success = true;
            $scope.showContent = false;
            $scope.message = resetPassword.success;
        })
        .error(function (data, status) {
            $scope.fail = true;
            $scope.message = JSON.stringify(data.message);
        });
    }

    $scope.validateEmpty = function () {
        $scope.incomplete = true;

        if (!$scope.resetPswdForm.password.$pristine && !$scope.resetPswdForm.confirmPassword.$pristine)
                        $scope.incomplete = false;
    }

    $scope.comparePasswords = function () {
        $scope.error = true;
        if ($scope.resetPswdForm.password.$dirty && $scope.resetPswdForm.confirmPassword.$dirty) {
            if ($scope.password == $scope.confirmPassword) {
                $scope.error = false;
            }
        }
        else
            $scope.error = false;
    }

    $scope.$watch('[password,confirmPassword]', function () {
        $scope.validateEmpty();
    })
    $scope.$watch('password', function () {
        $scope.comparePasswords();
    })
    $scope.$watch('confirmPassword', function () {
        $scope.comparePasswords();
    })
}])


