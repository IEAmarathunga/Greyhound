//appGreyhound
//.controller('AddDogController', ['$scope', '$http', 'urls', 'global', '$modalInstance',
//    function ($scope, $http, urls, global, modalService) {

//        // Jquery -----------------

//        $('#addDog').on('hidden.bs.modal', function (e) {
//            $(this)
//              .find("input,textarea,select")
//                 .val('')
//                 .end()
//              .find("input[type=checkbox],input[type=radio]")
//                 .prop("checked", "")
//                 .end();
//        })
//        // Jquery -----------------


//        $scope.cancel = function () {
//            $modalInstance.dismiss('cancel');
//        }

//        var dogSelected = damSelected = sireSelected = false;
//        var modalBackup = $('#addDog').clone();

//        $scope.dogNameModal = true;
//        $scope.dogNameMessage1 = 'We are always happy if someone helps us with a new dog.';
//        $scope.dogNameMessage2 = 'To add a new dog to the Database, you have to fill out the next 4 Formulars.';
//        $scope.dbExistMessage = false;

//        $scope.removeModal = function () {
//            $scope.Dog.age = '';
//        }

//        $scope.validateDogName = function (name) {
//            if (angular.isUndefined(name) || name == ' ') {
//                $scope.dogNameMessage1 = '';
//                $scope.dogNameMessage2 = '';
//            }

//            if (name.length <= 3) {
//                $scope.dogNameMessage1 = 'A name with less than 3 letters  is no real name !';
//                $scope.dogNameMessage2 = 'Please fill out the dog name';
//            }

//            else {
//                var httpRequest = $http({
//                    method: 'GET',
//                    url: urls.api + 'SearchDogs/ByName/' + name,
//                }).success(function (data, status) {
//                    if (data.length <= 0) {
//                        $scope.dogResultMessage = true;
//                    }
//                    else {
//                        dogSelected = true;
//                        $scope.dogResultMessage = false;
//                        $scope.dogList = data;
//                        $scope.dogResultTable = true;
//                        $scope.dogNameModal = false;
//                    }
//                }).error(function (data, status) {
//                    console.log(status.code);
//                })
//            }
//        }
//        $scope.goToTheSire = function () {
//            console.log('goToTheSire');
//            $scope.dogNameModal = false;
//        }

//        $scope.goToTheBeginig = function () {
//            console.log('goToTheBeginig');
//            $scope.dogNameModal = true;
//            $scope.dogResultMessage = false;
//            $scope.dogNameMessage1 = 'We are always happy if someone helps us with a new dog.';
//            $scope.dogNameMessage2 = 'To add a new dog to the Database, you have to fill out the next 4 Formulars.';
//        }

//        $scope.alreadyInDbMessage = function () {
//            $scope.dbExistMessage = true;
//            $scope.dogResultTable = false;
//        }

//        $scope.goToStepTwo = function () {
//            if (sireSelected == true) {
//                console.log('Sire Selected');
//            }

//            $scope.dogResultTable = false;
//            $scope.goToStepTwo = false;
//            $scope.stepTwo = true;
//        }
//        var getDog = function (name) {
//            $http({
//                method: 'GET',
//                url: urls.api + 'SearchDogs/ByName/' + name
//            }).success(function (data, status) {
//                if (data.length <= 0) {
//                    $scope.dogName = name;
//                    scope.dogResultMessage = true;
//                }
//            }).error();
//        }

//        $scope.checkSire = function (name) {
//            $http({
//                method: 'GET',
//                url: urls.api + 'SearchDogs/ByName/' + name
//            }).success(function (data, status) {

//                if (data.length <= 0) {
//                    $scope.stepTwo = false;
//                    $scope.dogResultMessage = true;
//                }
//                else {
//                    sireSelected = true;

//                    if (data[0].gender != 1) {
//                        $scope.dogResultMessage = true;
//                    }
//                    else {
//                        $('#dogOption').prop('checked', false);
//                        $scope.stepTwo = false;
//                        $scope.dogList = data;
//                        $scope.dogResultTable = true;
//                    }
//                }
//            }).error(function (status) {
//                console.log(status.code);
//            });
//        }

//        $scope.saveDog = function (Dog) {
//            console.log(Dog);
//        }

//        $scope.checkSire = function () {
//            if (angular.isUndefined($scope.sireName) || $scope.sireName == ' ') {
//                $scope.dogMessage1 = 'We are always happy if someone helps us with a new dog.';
//                $scope.dogMessage2 = 'To add a new dog to the Database, you have to fill out the next 4 Formulars.';
//            }

//            if ($scope.sireName.length <= 3) {
//                $scope.dogMessage1 = 'A name with less than 3 letters  is no real name !';
//                $scope.dogMessage2 = 'Please fill out the dog name';
//            }

//            console.log($scope.dogName);
//        }

//        $scope.deleteCustomer = function () {

//            var custName = $scope.customer.firstName + ' ' + $scope.customer.lastName;


//            var modalOptions = {
//                closeButtonText: 'Cancel',
//                actionButtonText: 'Delete Customer',
//                headerText: 'Delete ' + custName + '?',
//                bodyText: 'Are you sure you want to delete this customer?'
//            };

//            modalService.showModal({}, modalOptions).then(function (result) {
//                dataService.deleteCustomer($scope.customer.id).then(function () {
//                    $location.path('/customers');
//                }, processError);
//            });
//        }

//    }])
appGreyhound.controller('HeaderDownController', ['$scope', '$http', 'urls', 'global', 'AddDogService', function ($scope, $http, urls, global, AddDogService) {
        $scope.animationsEnabled = true;

        $scope.open = function () {
            console.log('Open Called');
            AddDogService.openModal();
        };
    }]);
