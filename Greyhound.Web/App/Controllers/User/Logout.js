appGreyhound
.controller('LogoutController', ['$scope', '$window', '$http', 'urls', 'global', '$rootScope', '$route', function ($scope, $window, $http, urls, global, $rootScope, $route) {

    $scope.logout = function () {
        
        $window.localStorage.removeItem('BearerToken');
        
        $scope.navigateToPath = '#/Logout';
        window.location = $scope.navigateToPath;

        $window.localStorage['LoggedIn'] = false;
        $window.localStorage['userName'] = "";

        $rootScope.LoggedIn = false;
        $rootScope.userName = $window.localStorage['userName'];


        window.location.reload();
    }
    $scope.login = function () {

        $scope.navigateToPath = '#/Login';
        window.location = $scope.navigateToPath;
    }

    $scope.dogSearch = function (dogName) {

        console.log('WE : '+$window.localStorage['dogSearchName']);

        $window.localStorage['dogSearchName'] = dogName;
        $scope.navigateToPath = '#/DogSearch';
        window.location = $scope.navigateToPath;


    }
}])

//appGreyhound
//.controller('HeaderTopController', ['$scope', 'global', function ($scope, global) {
//    global.isLogged = false;
//    global.userName = "";
//    //$scope.$apply();
//}]);