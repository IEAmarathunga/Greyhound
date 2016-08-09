appGreyhound
.controller('WelcomeController', ['$scope', 'global', '$rootScope', '$window', '$http','urls', function ($scope, global, $rootScope, $window, $http,urls) {

    //if login success, get user info
    //get cookie
    //var token = $window.localStorage['BearerToken'];
    
    //if (email!=null && email!="") {   
        //var dataObj = {
        //    "Email": $window.localStorage['email']
        //    //"Id": global.pedgireeId
        //};

        ////console.log(token);
        //var httpRequest = $http({
        //    method: 'POST',
        //    url: urls.api + "User/GetUserInfo/",
        //    //headers: { 'authorization': token },          
        //    data: JSON.stringify(dataObj)
        //}).success(function (data, status) {

        //    $window.localStorage['username'] = data.firstName + " " + data.lastName;
        //})
        //.error(function (response) {
        //    alert(response);
        //});
    //console.log("username is: " + $window.localStorage['username']);
    $scope.userName = $window.localStorage['userName'];
    $rootScope.LoggedIn = $window.localStorage['LoggedIn'];
    $rootScope.userName = $window.localStorage['username'];
    //}
    
    $scope.goHome = function () {

        $scope.navigateToPath = '#/Home';
        window.location = $scope.navigateToPath;
    }
}])

//.controller('HeaderTopController', ['$scope', 'global', function ($scope, global) {
//    console.login('im fired');
//    $scope.LoggedIn = global.isLogged;
//    $scope.userName = global.userName;
//    //$scope.$apply();
//}]);

//.directive('greyHeader', function (urls, global) {
//    return {
//        restrict: 'EA',
//        //transclude: true,
//        link: function (scope, element, attrs) {
//            console.log('im in');
//        }
//    };
//})
