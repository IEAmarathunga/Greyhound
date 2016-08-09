appGreyhound
.controller('RegistrationController', ['$scope', '$window', '$http', 'urls', 'vcRecaptchaService', function ($scope, $window, $http, urls, vcRecaptchaService) {
      
    //fill country drop down
    var httpRequest = $http({
        method: 'GET',
        url: urls.api + 'MasterData/Countries'

    }).success(function (data, status) {
        $scope.countryDetails = data;
    })
    .error(function (error) {
        $scope.status = 'Unable to load Land Details: ' + error.message;
        console.log($scope.status);
    });
    $scope.showRegistration = true;
        
    $scope.registerUser = function(){
        
        $scope.success = false;
        $scope.fail = false;

        var dataObj = {
            Email: $scope.email
        };
        console.log("email: " + String($scope.email));
        var httpRequest = $http({
            method: 'POST',
            async:false,
            url: urls.api + 'User/CheckEmail',
            data: JSON.stringify(dataObj)
        }).success(function (data, status) {
                      
            if (!angular.isDefined($scope.RecaptchaResponse)) { //if string is empty                
                $scope.fail = true;
                $scope.message = "Please resolve the captcha and submit!";
                return;
            }

            var dataObj = {
                FirstName: $scope.fname,
                LastName: $scope.lname,
                Email: $scope.email,
                Password: $scope.password,
                CountryId: $scope.cmbCountry,
                CaptchaValue : $scope.RecaptchaResponse
            };

            console.log('recap obj:' + dataObj);
            $scope.navigateToPath = '#/';

            var httpRequest = $http({
                method: 'POST',
                async:false,
                url: urls.api + 'User/PostReg',
                data: JSON.stringify(dataObj)
            }).success(function (data, status) {
                $scope.success = true;
                $scope.showRegistration = false;
                $scope.message = registration.success;

            })
        .error(function (data, status) {
            $scope.fail = true;
            $scope.message = JSON.stringify(data.message);
        });

        })
    .error(function (data, status) {
        $scope.fail = true;
        $scope.success = false;
        $scope.message = JSON.stringify("Email Already Exists");
    });
        
    }

    $scope.validateEmpty = function () {
        $scope.incomplete = true;
       
        //if (!(angular.isUndefined($scope.chkTerms)) && $scope.chkTerms == "YES")
        
        //else
        //    console.log('not checked');
        //if (!$scope.success) {           
        //    $scope.message = JSON.stringify("Email Already Exists");
        //}
        //else {        
            if (!$scope.registrationForm.password.$pristine && !$scope.registrationForm.confirmPassword.$pristine)
                if (!$scope.registrationForm.fname.$invalid && $scope.registrationForm.fname.$dirty)
                    if (!$scope.registrationForm.lname.$invalid && $scope.registrationForm.lname.$dirty)
                        if (!$scope.registrationForm.email.$invalid && $scope.registrationForm.email.$dirty)                           
                            if (!angular.isUndefined($scope.chkTerms) && $scope.chkTerms) {
                                $scope.incomplete = false;
                            }

            //console.log($scope.incomplete);
        
    }

    $scope.comparePasswords = function () {
        $scope.error = true;        
        if ($scope.registrationForm.password.$dirty && $scope.registrationForm.confirmPassword.$dirty) {
            if ($scope.password == $scope.confirmPassword) {
                $scope.error = false;
            }
       }
        else
            $scope.error = false;
    }

    $scope.$watch('[fname,lname,email,password,confirmPassword,chkTerms]', function () {
        $scope.validateEmpty();
    })
    $scope.$watch('password', function () {
        $scope.comparePasswords();
    })
    $scope.$watch('confirmPassword', function () {
        $scope.comparePasswords();
    })

    $scope.checkExistance = function (registrationForm) {
        
        if (!$scope.registrationForm.email.$invalid && $scope.registrationForm.email.$dirty){

            var dataObj = {
                Email: $scope.email                
            };
            console.log("email: " + String($scope.email));
            var httpRequest = $http({
                method: 'POST',
                url: urls.api + 'User/CheckEmail',
                data: JSON.stringify(dataObj)
            }).success(function (data, status) {
                $scope.success = true;
                $scope.fail = false;
                $scope.message = "valid email";        
            })
        .error(function (data, status) {
            $scope.fail = true;
            $scope.success = false;
            $scope.message = JSON.stringify("Email Already Exists");
        });
        }
    }
}])


