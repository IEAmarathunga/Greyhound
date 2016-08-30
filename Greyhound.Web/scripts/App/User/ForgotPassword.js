appGreyhound
.controller('ForgotPasswordCtrl', ['$scope', '$http', 'urls', function ($scope, $http, urls) {
        
    $scope.showContent = true;
    $scope.SendEmail = function () {

        $scope.success = false;
        $scope.fail = false;

        var dataObj = {
            Email: $scope.email
        };

        $scope.navigateToPath = '#/';
        console.log(JSON.stringify(dataObj));
        var httpRequest = $http({
            method: 'POST',
            url: urls.api + 'User/ForgotPswd',
            data: JSON.stringify(dataObj)
            
        }).success(function (data, status) {
            $scope.success = true;
            $scope.showContent = false;
            $scope.message = registration.success;                
        })
        .error(function (data, status) {
            $scope.fail = true;            
            $scope.message = data.message;
        });
    }

    $scope.validateEmpty = function () {
        $scope.incomplete = true;

        if (!$scope.ForgotPasswordForm.email.$invalid && $scope.ForgotPasswordForm.email.$dirty)
            $scope.incomplete = false;
    }
        
    $scope.$watch('email', function () {
        $scope.validateEmpty();
    })    
}])


