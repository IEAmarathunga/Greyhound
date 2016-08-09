//var appGreyhound = angular.module('appGreyhound', ['ngRoute'])
//filter for dogs

appGreyhound
.controller('filterDogsCtrl', ['$scope', '$location', '$http','$window','urls', 'global',function ($scope, $location, $http,$window, urls, global) {
        $scope.viewClass = function () {
            alert($('#searchDogTab').attr('class'));
        }

        $scope.validateName = function () {
            if ($scope.txtname == '') {
                $scope.nameRequiredErrorMessage = true;
            }
            else
                $scope.nameRequiredErrorMessage = false;
        }

        $scope.filterDogDetails = function (name) {

            if (typeof ($scope.txtname) == 'undefined' || name.length < 3) {
                if (typeof ($scope.txtname) == 'undefined') {
                    $scope.errorMsg = " Dog name is required";
                    $scope.nameRequiredErrorMessage = true;
                }
                else if (name.length < 3) {
                    $scope.errorMsg = "Search term must have at least 3 characters";
                    $scope.nameRequiredErrorMessage = true;
                }
            }
            else if ($scope.nameRequiredErrorMessage == false) {
                //$scope.tableState = true;
                $scope.nameRequiredErrorMessage = false;
                
                $window.localStorage['dogSearchName'] = $scope.txtname;
                $scope.navigateToPath = '#/DogSearch';
                window.location = $scope.navigateToPath;

            }

                //if (!angular.isUndefined(dataObj.name))
                //    $scope.navigateToPath += '?name=' + dataObj.name

                //if (!angular.isUndefined(dataObj.gender))
                //    $scope.navigateToPath += '&gender=' + dataObj.gender;

                //if (!angular.isUndefined(dataObj.colorID))
                //    $scope.navigateToPath += '&colorId=' + dataObj.colorID;

                //if (!angular.isUndefined(dataObj.Year))
                //    $scope.navigateToPath += '&year=' + dataObj.Year;

                //if (!angular.isUndefined(dataObj.LandID))
                //    $scope.navigateToPath += '&landId=' + dataObj.LandID;

                //if (!angular.isUndefined(dataObj.BreedID))
                //    $scope.navigateToPath += '&breedId=' + dataObj.BreedID;


                // $location.search({});
            }
        }])

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

 //.controller('HeaderTopController', ['$scope', 'global', '$window', '$rootScope', function ($scope, global, $window, $rootScope) {
 //    $rootScope.userName = $window.localStorage['username'];
 //    $rootScope.LoggedIn = $window.localStorage['LoggedIn'];
    
 //   }])

//isuru commented this header controller......
//date : 2016-02-23
//reason: not using anywhere
/*
    .controller('HeaderController', ['$scope', '$location', '$anchorScroll', function ($scope, $location, $anchorScroll) {

        console.log('header fired');

        $scope.goToHome = function () {
            $('#searchDogTab').removeClass('current');
            $('#adoptDogTab').addClass('current');
            //$('#searcgDogTab').click();
            eventFire(document.getElementById('tab2'), 'click');
            //alert(window.locaton.href)

            //$location.path()
        }

        function eventFire(el, etype) {
            if (el.fireEvent) {
                el.fireEvent('on' + etype);
            } else {
                var evObj = document.createEvent('Events');
                evObj.initEvent(etype, true, false);
                el.dispatchEvent(evObj);
            }
        }

    }])
*/
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

.controller('MainController', ['$scope', '$http', 'urls', function ($scope, $http, urls) {


    $scope.goToDogSearch = function () {
        console.log(window.location.toString());


        if (window.location.toString() != 'http://localhost:50802/#/Home') {
            window.location = urls.domain + '#/Home';
            $("#adoptDogTab").removeClass("current");
            $("#searchDogTab").addClass("current");
        }
        else if ($("#adoptDogTab").hasClass("current")) {
            $("#adoptDogTab").removeClass("current");
            $("#searchDogTab").addClass("current");
        }
    }

    //fill color drop down    
    var httpRequest = $http({
        method: 'GET',
        url: urls.api + 'MasterData/DogColors'

    }).success(function (data, status) {
        $scope.ColorList = data;
    })
    .error(function (error) {
        $scope.status = 'Unable to load Color Details: ' + error.message;
        console.log($scope.status);
    });

    $scope.changedValue = function (item) {
        $scope.$parent.colorDetails = item;
    }

    //fill birth year drop down
    var httpRequest = $http({
        method: 'GET',
        url: urls.api + 'MasterData/AgeGroup'

    }).success(function (data, status) {
        $scope.AgeList = data;
        //console.log($scope.yearDetails);
    })
    .error(function (error) {
        $scope.status = 'Unable to load Year Details: ' + error.message;
        console.log($scope.status);
    });

    $scope.changedValue = function (item) {
        $scope.$parent.yearDetails = item;
    }

    //fill land drop down
    var httpRequest = $http({
        method: 'GET',
        url: urls.api + 'MasterData/Countries'

    }).success(function (data, status) {
        $scope.LandList = data;

    })
   .error(function (error) {
       $scope.status = 'Unable to load Land Details: ' + error.message;
       console.log($scope.status);
   });
    $scope.changedValue = function (item) {
        $scope.$parent.landDetails = item;
    }

    //fill breed drop down
    var httpRequest = $http({
        method: 'GET',
        url: urls.api + 'MasterData/Breeds'

    }).success(function (data, status) {
        $scope.breedDetails = data;
    })
    .error(function (error) {
        $scope.status = 'Unable to load Breed Details: ' + error.message;
        console.log($scope.status);
    });
    $scope.changedValue = function (item) {
        $scope.$parent.breedDetails = item;
    }
}])

.controller('FindAdoptController', ['$scope', '$http', 'urls', function ($scope, $http, urls) {
    var colorHttp = $http({
        method: 'GET',
        url: urls.api + 'masterData/DogColors'
    }).success(function (data, status) {
        $scope.ColorList = data;
    }).error(function (status) {
        console.log('ERROR : ' + status.code);
    })

    var agrGroupsHttp = $http({
        method: 'GET',
        url: urls.api + 'masterData/AgeGroup'
    }).success(function (data, status) {
        $scope.AgeGroup = data;
    }).error(function (status) {
        console.log('ERROR : ' + status.code);
    })

    var countriesHttp = $http({
        method: 'GET',
        url: urls.api + 'masterData/Countries'
    }).success(function (data, status) {
        $scope.CountryList = data;
    }).error(function (status) {
        console.log('ERROR :' + status.code);
    })
}]);

//function scrollNav() {
//    $('.nav a').click(function () {
//        //Toggle Class
//        $(".active").removeClass("active");
//        $(this).closest('li').addClass("active");
//        var theClass = $(this).attr("class");
//        $('.' + theClass).parent('li').addClass('active');
//        //Animate
//        $('html, body').stop().animate({
//            scrollTop: $($('#dogSearch').attr('href')).offset().top - 160
//        }, 400);
//        return false;
//    });
//    $('.scrollTop a').scrollTop();
//}



