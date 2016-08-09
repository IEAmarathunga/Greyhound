appGreyhound
.controller('LoginController', ['$scope', '$window', '$http', 'urls', function ($scope, $window, $http, urls) {
    //, 'authService' , authService
    var tokenKey = 'accessToken';
    
    $scope.login = function(){
               
        
        $scope.success = false;
        $scope.fail = false;

        var loginData = {
            grant_type: 'password',
            UserName: $scope.username,
            password: $scope.password
        };

        /*authService.login($scope.loginData).then(function (response) {

            $location.path('/orders');

        },
         function (err) {
             $scope.message = err.error_description;
         });
         */
        $.ajax({
            type: 'POST',
            async: false,
            url: '/Token',
            data: loginData
        }).done(function (data) {
            //self.user(data.userName);
            // Cache the access token in session storage.
            //sessionStorage.setItem(tokenKey, data.access_token);
            $window.localStorage.removeItem('BearerToken');
            $window.localStorage['BearerToken'] = data.access_token;
            //console.log('new token: ' + $window.localStorage['BearerToken']);

            $window.localStorage['LoggedIn'] = true;

            var dataObj = {
                "Email": $scope.username
                //"Id": global.pedgireeId
            };

            //console.log(token);
            var httpRequest = $http({
                method: 'POST',
                async: false,
                url: urls.api + "User/GetUserInfo/",
                headers: { 'authorization': 'Bearer ' + data.access_token },
                data: JSON.stringify(dataObj)
            }).success(function (data, status) {

                console.log(data);
                $window.localStorage['userId'] = data.id;
                $window.localStorage['userName'] = data.firstName + " " + data.lastName;
                $window.localStorage['UserCountryId'] = data.countryId;
                $window.localStorage['UserCountry'] = data.country;
                //console.log($window.localStorage['username']);
                $scope.navigateToPath = '#/Welcome';
                window.location = $scope.navigateToPath;
                window.location.reload();
                //console.log();
            })
            .error(function (response) {
                alert(response);
            });

            //$window.localStorage['email'] = $scope.username;

            //global.isLogged = true;
            //global.userName = $scope.username;
            //$scope.$apply();
            
                    
            
            //}).error(function (data, status) {
        }).error(function (response) {
            //$scope.fail = true;
            //$scope.message = JSON.stringify(data.message);
            var json = JSON.parse(response['responseText']);
            var result = JSON.stringify(json['error_description']);
            alert(result);
            /*$scope.fail = true;
            $scope.message = result;
            console.log(result);*/

        });
              
        

        //
        
        /*
        var loginData = {
            Email: $scope.username,
            Password: $scope.password
        };

        var httpRequest = $http({
            method: 'POST',
            url: urls.api + 'User/Login',
            data: JSON.stringify(loginData)
        }).success(function (data, status) {
            $scope.success = true;
            $scope.showRegistration = false;
            $scope.message = registration.success;               
        })
        .error(function (data, status) {
            $scope.fail = true;
            $scope.message = JSON.stringify(data.message);
        }); */
        
    }

   
    $scope.$watch('[username,password]', function () {
        $scope.validateEmpty();
    })

    $scope.validateEmpty = function () {
        
        $scope.incomplete = true;
        if (!$scope.loginForm.username.$pristine && !$scope.loginForm.password.$pristine)
            if (!angular.isUndefined($scope.username)) 
            if(!angular.isUndefined($scope.password))
                        $scope.incomplete = false;
    }

}])

//.directive('greyheader',userService, function (userService) {
//    return {
//        restrict: 'EA',
//        transclude: true,
//        link: function (scope, element, attrs) {

//            scope.$watch("userService.xxx", function () {
//                console.log(userService.xxx);
//            });
//        }
//    };
//})
    //.directive('myCustomer', function () {
    //    return {
    //        template: 'Name: {{customer.name}} Address: {{customer.address}}'
    //    };
//});
//.controller('HeaderTopController', ['$scope', '$window', '$http', 'urls', 'global', 'userService', '$rootScope', function ($scope, $window, $http, urls, global, userService, $rootScope) {
//    $scope.userService = userService;
//    $rootScope.$watch('[xxx]', function () {
//        console.log('changed2');
//    })
//}])

//.service('userService',['global', function (global) {
//    //this.xxx = "hi, ";//+ global.userName;
//    //console.log(global.userName);
//    var productList = [];

//    var addProduct = function (newObj) {
//        productList.push(newObj);
//    };

//    var getProducts = function () {
//        return productList;
//    };

//    return {
//        addProduct: addProduct,
//        getProducts: getProducts
//    };

//}]);
//.service('userService', ['$rootScope', function ($rootScope) {
//    this.xxx = "Hello";//+ global.userName;
//    $rootScope.$watch('[xxx]', function () {
//        console.log('changed3');
//    })
//}]);