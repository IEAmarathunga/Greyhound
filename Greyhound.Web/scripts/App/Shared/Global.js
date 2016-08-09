/// <reference path="Header.html" />
var appGreyhound = angular.module('appGreyhound', ['ngSanitize', 'ngRoute', 'angularUtils.directives.dirPagination', 'ui.bootstrap', 'vcRecaptcha'])

.run(function ($http, $window) {
    var token = $window.localStorage['BearerToken'];
    $http.defaults.headers.common.Authorization = 'Bearer ' + token;
})

//HEADER AND FOOTER
.directive('greyHeader', function (urls) {

    return {
        restrict: 'A',
        templateUrl: urls.domain + "App/Views/Shared/Header.html",
        controller: 'HeaderController'        
    };
})

.controller('HeaderController', ['$scope', '$window', '$http', 'urls', '$rootScope', function ($scope, $window, $http, urls, $rootScope) {    
    if (angular.isDefined($window.localStorage['userName']))
    if ($window.localStorage['userName'] != "") {
        $scope.userName = $window.localStorage['userName'];
        $rootScope.LoggedIn = true;
    }
    else
        $rootScope.LoggedIn = false;
    
}])

.directive('greyFooter', function (urls) {
    return {
        restrict: 'A',
        templateUrl: urls.domain + "App/Views/Shared/Footer.html"
    };
})

.directive('classifiedsPagesLink', function () {
    return {
        restrict: 'E',
        template: ' <div class="row text-center ">'+
                        '<div class="btn-group  btn-group-md" role="group" aria-label="...">'+
                        '<a ng-href="#/Classifieds/pups-for-sale"><button type="button" class="btn btn-default">Pups for sale</button></a>'+
                        '<a ng-href="#/Classifieds/dogs-for-sale"><button type="button" class="btn btn-default" ng-click="">Dogs for sale</button></a>'+
                        '<a ng-href="#/Classifieds/private-ads"><button type="button" class="btn btn-default" ng-click="">Private ads</button></a>'+
                        '<a ng-href="#/Classifieds/bussiness-ads"><button type="button" class="btn btn-default" ng-click="">Business adds</button></a>'+
                        '<a ng-href="#/Classifieds/litter-ads"><button type="button" class="btn btn-default" ng-click="">Place Litter ads</button></a>'+
                        '<a ng-href="#/Classifieds/place-dog-ads"><button type="button" class="btn btn-default">Place Dog ads</button></a>'+
                        '<a ng-href="#/Classifieds/place-misc-ads"><button type="button" class="btn btn-default">Place misc ads</button></a>'+
                        '</div><div class="clearfix"></div>{{test123}}</div>'
    }
})

.directive('classifiedAdd', function () {
    return {
        restrict: 'E',
        template: '<div class="row text-center"><img class="img-responsive" src="../../../Content/Ads%20Images/classifieds.jpg" /><div class="clearfix"></div></div>'
    }
})


.factory('urls', function ($location) {
    var protocol = $location.protocol() + "://";
    var host = $location.host();
    var port = $location.port();

    if (angular.isDefined(port)) {
        port = ":" + port;
        this.domain = protocol + host + port + '/';
    }
    else {
        this.domain = protocol + host + '/';
    }
    var urls = {
        domain: this.domain,
        api: this.domain + "api/"
    };

    return urls;
})


.factory('global', function () {
    var grey = {};

    //DOG SEARCH
    grey.searchedName;
    grey.dogCount;
    grey.searchedDogs;

    //PEDIGREE
    grey.pedgireeId;

    //TATTOO
    grey.tattooDogs;

    //USER
    //grey.userId;
    //grey.userName;
    //grey.userCountryId;
    //grey.userCountryName;

    return grey;
})

.factory('Gender', function () {
    return [
        { name: 'All', value: 0 },
        { name: 'Male', value: 1 },
        { name: 'Female', value: 2 }        
    ]
})

.factory('day', function () {
    return [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31];
})

.factory('pagination', function () {
    return {
        get: function (data, offset, limit) {
            return data.slice(offset, offset + limit);
        },
    }
})

.service('modalService', ['$modal',
    function ($modal) {

        var modalDefaults = {
            backdrop: true,
            keyboard: true,
            modalFade: true,
            templateUrl: '/app/partials/modal.html'
        };

        var modalOptions = {
            closeButtonText: 'Close',
            actionButtonText: 'OK',
            headerText: 'Proceed?',
            bodyText: 'Perform this action?'
        };

        this.showModal = function (customModalDefaults, customModalOptions) {
            if (!customModalDefaults) customModalDefaults = {};
            customModalDefaults.backdrop = 'static';
            return this.show(customModalDefaults, customModalOptions);
        };

        this.show = function (customModalDefaults, customModalOptions) {
            //Create temp objects to work with since we're in a singleton service
            var tempModalDefaults = {};
            var tempModalOptions = {};

            //Map angular-ui modal custom defaults to modal defaults defined in service
            angular.extend(tempModalDefaults, modalDefaults, customModalDefaults);

            //Map modal.html $scope custom properties to defaults defined in service
            angular.extend(tempModalOptions, modalOptions, customModalOptions);

            if (!tempModalDefaults.controller) {
                tempModalDefaults.controller = function ($scope, $modalInstance) {
                    $scope.modalOptions = tempModalOptions;
                    $scope.modalOptions.ok = function (result) {
                        $modalInstance.close(result);
                    };
                    $scope.modalOptions.close = function (result) {
                        $modalInstance.dismiss('cancel');
                    };
                }
            }
            return $modal.open(tempModalDefaults).result;
        };
    }])

.service('ManagementMailServiceModal', ['$modal',

    function ($modal) {
        var modalDefaults = {
            bacakdrop: true,
            keyboard: true,
            modalFade: true,
            templateUrl: '/app/partials/managementEmailModal.html'
        }

        var modalOptions = {
            closeButtonText: 'Close',
            actionButtonText: 'Ok',
            headerText: 'Proceed?',
            bodyText: 'Perform this action?'
        };

        this.showModal = function (customModalDefaults, customModalOptions) {
            if (!customModalDefaults) customModalDefaults = {};
            customModalDefaults.backdrop = false;
            return this.show(customModalDefaults, customModalOptions);
        }

        this.show = function (customModalDefaults, customModalOptions) {
            //Create temp objects to work with since we're in a singleton service
            var tempModalDefaults = {};
            var tempModalOptions = {};

            //Map angular-ui modal custom defaults to modal defaults defined in service
            angular.extend(tempModalDefaults, modalDefaults, customModalDefaults);

            //Map modal.html $scope custom properties to defaults defined in service
            angular.extend(tempModalOptions, modalOptions, customModalOptions);

            if (!tempModalDefaults.controller) {
                tempModalDefaults.controller = function ($scope, $modalInstance) {
                    $scope.modalOptions = tempModalOptions;
                    $scope.modalOptions.ok = function (result) {
                        $modalInstance.close(result);
                    };
                    $scope.modalOptions.close = function (result) {
                        $modalInstance.dismiss('cancel');
                    };
                }
            }
            return $modal.open(tempModalDefaults).result;
        };
    }])

.service('classifiedsPriceRange', [function () {
    var temp = [{
        min: 0,
        max: 500,
        name: '0-500'
    }, {
        min: 501,
        max: 1000,
        name: '501-1000'
    }, {
        min: 1001,
        max: 2000,
        name: '1001-2000'
    }, {
        min: 2001,
        max: 5000,
        name: '2001-5000'
    }, {
        min: 5001,
        max: -1,
        name: '5000+'
    }]

    return temp;

}])

.service('EmailModalService', ['$modal', function ($modal) {
    this.openModal = function (to, title) {
        var modalInstance = $modal.open({
            templateUrl: '/App/Views/Classifieds/Email_Modal.html',
            controller: function ($scope, $http) {
                $scope.recipent = to;
                $scope.adName = title;
                $scope.subject = 'In regards to:' + title;
            }

        });
    }
}])

.factory('AddDogService', ['$modal', function ($modal) {
    return {
        openModal: function () {
            var modalInstance = $modal.open({
                templateUrl: 'App/Views/Dog/AddDog_modal.html',
                controller: 'AddDogController'
            })
        }
    }
}])

.factory('DownloadsSignUp', ['$modal', function ($modal) {
    return {
        OpenModal: function () {
            var modalInstance = $modal.open({
                templateUrl: 'App/Views/Shared/SignUp_modal.html',
                size: 'sm',
                controller: ['$scope', '$http', 'urls', '$modalInstance', function ($scope, $http, url, $modalInstance) {
                    $scope.checkSignup = function (fname, email) {
                        if (!fname && !email) {
                            var registerHttp = $http({
                                method: 'GET',
                                url: urls.api + ''
                            }).success(function (data, status) {
                                return data;
                            }).error(function (status) {
                                return status;
                            })
                        }
                    }
                }]
            })
        }
    }
}])

.factory('DownloadsLogin', ['$modal', function ($modal) {
    return {
        openModal: $modal.open({
            templateUrl: '',
            controller: ['$scope', '$http', 'urls', function ($scope, $http, urls) {
                $scope.checkLogin = function (username, password) {
                    if (!username && !password) {
                        var loginHttp = $http({
                            method: 'GET',
                            url: urls.api + ''
                        }).success(function (data, status) {
                            return data;
                        }).error(function (status) {
                            return null;
                        });
                    }
                }
            }]
        })
    }
}])
.service('fileUpload', ['$http', function ($http) {
    this.post = function (uploadUrl, file) {
        var formData = new FormData();
        formData.append('file', file);
        $http.post(uploadUrl, formData, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        }).success(function (data, status) {
            console.log(data);
        })
        .error(function (status) {
            console.log(status);
        })
    }
}])
.directive('fileModel', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;

            element.bind('change', function () {
                scope.$apply(function () {
                    modelSetter(scope, element[0].files[0]);
                });
            });
        }
    };
}])
.directive('imagesViewer', ['$parse', function () {
    return {
        restrict: 'E',
        scope: { data: '=' },
        templateUrl: 'App/Views/Shared/ImagesViewer.html',
        controller: function ($scope, $attrs, $parse) {
            console.log($scope.data);
            var imgObj = [];
            for (var i in $scope.data) {
                imgObj.push($scope.data[i].url);
            }

            $scope.img = {
                currIndex: 0,
                currImageSrc: '',
                images: imgObj,
                loadImage: function () {
                    this.currImageSrc = this.images[this.currIndex];
                },
                back: function () {
                    console.log(this.images.length);
                    this.currIndex--;
                    if (this.currIndex < 0) { this.currIndex = this.images.length - 1; }
                    this.loadImage();
                },
                next: function () {
                    console.log(this.images.length);
                    this.currIndex++;
                    if (this.currIndex >= this.images.length) { this.currIndex = 0; }
                    this.loadImage();
                }
            }
            $scope.img.loadImage();
        }
    }
}])

.directive('folderTree', function ($compile) {
    return {
        restrict: 'E',
        scope: { family: '=' },
        template:
            '<p>{{family.name}}</p>' +
            '<ul>' +
                '<li ng-repeat="child in family.children">' +
                    '<folder-tree></folder-tree>' +
                '</li>' +
            '</ul>',
        compile: function (tElement, tAttrs) {
            var contents = tElement.contents().remove();
            var compiledContents;
            return function (scope, iElement, iAttr) {
                if (!compiledContents) {
                    compiledContents = $compile(contents);
                }
                compiledContents(scope, function (clone, scope) {
                    iElement.append(clone);
                });
            };
        },
        controller: function ($scope) {
            $scope.treeFamily = function () {

            }
        }
    }
})

.directive('classifiedsCountryLinks', ['$http', 'urls', function ($http, urls) {
    return {
        restrict: 'E',
        scope: { data: '=' },
        template: '<div class="row text-center">' +
                        ' <div class="btn-group  btn-group-lg" role="group" aria-label="...">' +
                            '<button type="button" class="btn btn-default" ng-repeat="country in CountryList" ng-click="loadAd(country.groupId)">{{country.groupName}}<span class="badge" style="font-size:10px;">({{country.adsCount}})</span></button>' +
                        '</div>' +
                    '</div>',
        controller: function ($scope, $http, urls) {
            //initial loading
            var countries = $http({
                method: 'GET',
                url: urls.api + 'Classifieds/PupCountries',
            }).success(function (data, status) {
                $scope.CountryList = data;
                if (data.length > 0) {
                    //$scope.loadAd($scope.CountryList[0].groupId);
                    //console.log($scope.CountryList[0].groupId);
                    //var loadCalssifiedsByCountry = $http({
                    //    method: 'GET',
                    //    url:urls.api+ ''
                    //}).success(function (data, status) {
                    //    console.log(data);
                    //}).error(function (status) {
                    //    console.log('Classifieds_loadCalssifiedsByCountry_ERROR : ' + status.code);
                    //});
                }
            }).error(function (status) {
                console.log('Classifieds_initalLoadingOfCountries_Error :' + status.code);
            });

            console.log('123 : ' + $scope.LitterList);

            $scope.test = '1234';


            //$scope.loadAd = function (id) {
            //    console.log(id);
            //    var adsByCountry = $http({
            //        method: 'GET',
            //        url: urls.api + 'Classifieds/PupCountriesByGroup/' + id
            //    }).success(function (data, status) {
            //        console.log(data);
            //        $scope.LitterList = data;
            //        console.log($scope)
            //    }).error(function (status) {
            //        console.log('ClassifiedsCountryLinksDIRECTIVE_loadAd_Error :'+status.code);
            //    });
            //}
        }
    }

}]);


