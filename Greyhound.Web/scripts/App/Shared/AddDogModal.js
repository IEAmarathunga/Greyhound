appGreyhound.controller('AddDogController', ['$scope', '$http', 'urls', 'global', '$sanitize', 'Gender', 'day', '$sce', '$uibModalInstance', function ($scope, $http, urls, global, $sanitize, Gender, day, $sce, $uibModalInstance) {

    var newDog = [];
    var tempSire = false;
    var tempDam = false;
    var tempDog = false;
    var damhit = false;
    var count = 0;

    $scope.stepOne_show = true;
    $scope.dogNotFound_show = false;
    $scope.selectDog_radio = false;
    $scope.finalStep_show = false;
    $scope.addDamMsg1 = 'Step Three';
    $scope.addDamMsg2 = 'Now please fill in the name of the Dam';

    $scope.NameOfDog = false;
    $scope.dogResultTble = false;
    $scope.nameOfDogMessage = $sce.trustAsHtml('We are always happy if someone helps us with a new dog.<br/>To add a new dog to the Database, you have to fill out the next 4 Formulars.');
    $scope.sireTable_show = false;
    $scope.addSire_show = false;
    $scope.stepTwoMsg1 = 'Step Two';
    $scope.stepTwoMsg2 = 'Now Please fill in the name of the sire name';
    $scope.sireResultTble_show = false;
    var selectedDog = null;
    $scope.DayList = day;
    $scope.GenderList = Gender;

    $scope.selectedDog_as = {
        id: null,
        name : null
    }


    function getDogData(name) {
        return $http({
            method: 'GET',
            url: urls.api + 'SearchDogs/ByName/' + name
        })
    }

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    }

    $scope.confirmNameOfDog = function (name, type) {
        if (angular.isUndefined(name) || name.length == 0) {
            $scope.nameOfDogMessage = 'Please fill out the dog name';
        }
        else {
            if (name.length <= 3) {
                $scope.nameOfDogMessage = 'A name with less than 3 letters is no real name ! <br/> Please fill out the dog name ';
            }
            else {
                var promise = getDogData(name, 0);
                promise.success(function (data, status) {
                    $scope.NameOfDog = false;

                    if (data.length <= 0) {
                        $scope.dogNotFound_show = true;
                        $scope.dogNotFound_name = name;
                        $scope.dogNotFound_type = type;
                    }
                    else {
                        $scope.DogList = data;
                        $scope.stepOne_show = false;
                        $scope.dogNotFound_show = false;
                        $scope.dogResultTble = true;
                        $scope.dogSearchTerm = type;
                        $scope.searchedDog_mdl = name;
                    }
                })
                promise.error(function (status) {
                    console.log('ERROR PROMSE' + status.code);
                })
            }
        }
    }

    $scope.searchDog = function (dogName, term) {
        var promise = getDogData(dogName, term);
        promise.success(function (data, status) {
            if (data.length <= 0) {
                $scope.dogResultTble = false;
                $scope.dogNotFound_show = true;
                $scope.dogNotFound_name = dogName;
                $scope.dogNotFound_type = term;

            }
            else {
                $scope.DogList = data;
                $scope.dogNotFound_show = false;
                $scope.dogResultTble = true;
                $scope.dogSearchTerm = term;
            }
        });
        promise.error(function (status) {
            console.log(status.code);
        });
    }

    $scope.errorInDogName = function (name, id) {
        selectedDog = id;
        console.log('Term :' + $scope.dogSearchTerm);
        alert($scope.dogSearchTerm);

        if ($scope.dogSearchTerm == 'Dog') {
            $scope.dogResultTble = false;
            $scope.selectedDogError_show = true;
        }
        else if ($scope.dogSearchTerm == 'Sire') {
            newDog.sireId = id;
            $scope.dogResultTble = false;
            $scope.addSire_show = false;
            $scope.addDam_show = true;
            $scope.selectedDogError_show = false;
        }
        else if ($scope.dogSearchTerm == 'Dam') {
            newDog.damId = id;
            $scope.dogResultTble = false;
            $scope.addDam_show = false;
            $scope.selectedDogError_show = false;
            $scope.finalStep_show = true;
        }
        $scope.dogResultTble = false;
        $scope.selectedDog_as.name = name;
    }

    $scope.goToStepOne = function () {
        $scope.selectedDogError_show = false;
        $scope.dogResultTble = false;
        $scope.stepOne_show = true;
        $scope.dogName = null;
        $scope.selectedDog_as = {
            id: null,
            name: null
        }
    }

    $scope.stepTwo = function () {
        count++;
        if (count == 1) {
            tempDog = true;
        }
        if (count == 2) {
            tempSire = true;
        }
        if (count == 3) {
            tempDam == true;
        }

        if (tempDog == true && tempSire == false && tempDam == false) {
            $scope.dogResultTble = false;
            $scope.addSire_show = true;
        }

        if (tempDog == true && tempSire == true && tempDam == false) {
            $scope.dogResultTble = false;
            $scope.addSire_show = false;
            $scope.addDam_show = true;
        }

        if (damhit == true) {
            console.log('hit');
            $scope.stepOne_show = true;
            $scope.addDam_show = false;
        }

        //if ($scope.addDam_show == true) {
        //    console.log('qwe');
        //    $scope.dogResultTble = false;
        //    $scope.addDam_show = false;
        //    $scope.finalStep_show = true;
        //}

        console.log('DOG :' + tempDog);
        console.log('SIRE :' + tempSire);
        console.log('DAM :' + tempDam);
    }


    $scope.findSire = function (name, type) {
        if (angular.isUndefined(name) || name === '') {
            $scope.stepTwoMsg2 = 'Please fill out the Sire-name';
        }
        else {
            if (name.length <= 3) {
                $scope.stepTwoMsg2 = 'A name with less than 3 letters is now real name ! <br /> Please fill out the Sire name ';
            }
            else {
                var promise = getDogData(name);
                promise.success(function (data, status) {
                    if (data.length <= 0) {
                        $scope.addSire_show = false;
                        $scope.dogNotFound_show = true;
                        $scope.dogNotFound_type = type;
                        $scope.dogNotFound_name = name;
                    }
                    else {
                        tempSire = true;
                        $scope.searchedDog_mdl = name;
                        $scope.dogSearchTerm = type;
                        $scope.selectDog_radio = false;
                        $scope.dogResultTble = true;
                        $scope.addSire_show = false;
                        $scope.dogNotFound_show = false;
                        $scope.DogList = data;
                    }
                })
                promise.error(function (status) {
                    console.log(status.code);
                })
            }
        }
    }

    $scope.previousStep = function () {
        if (tempDog == false) {
            $scope.dogNotFound_show = false;
            $scope.addSire_show = false;
            $scope.NameOfDog = true;
            $scope.dogName = '';
        }
        else if (tempDog == true && tempSire == false && tempDam == false) { }
        else if (tempDog == true && tempSire == true && tempDam == false) {
            $scope.addDam_show = true;
            $scope.dogNotFound_show = false;
            $scope.damName = '';
        }
    }

    $scope.dogSuccess = function () {
        if (tempDog == false) {

        }
        else if (tempDog == true && tempSire == false && tempDam == false) { }
        else if (tempDog == true && tempSire == true && tempDam == false) {
            $scope.addDam_show = false;
            $scope.dogNotFound_show = false;
            //$scope.finalStep_show = true;
        }

        $scope.dogNotFound_show = false;
        $scope.addDam_show = true;
    }

    $scope.findDam = function (name, type) {
        if (angular.isUndefined(name) || name === '') {
            $scope.addDamMsg1 = 'Please fill out the Dam-name';
        }
        else {
            if (name.length <= 3) {
                $scope.addDamMsg2 = 'A name with less than 3 letters is now real name ! <br /> Please fill out the Dam name ';
            }
            else {
                var promise = getDogData(name, type);
                promise.success(function (data, status) {
                    if (data.length <= 0) {
                        $scope.addSire_show = false;
                        $scope.dogNotFound_show = true;
                        $scope.dogNotFound_type = type;
                        $scope.dogNotFound_name = name;
                        $scope.addDam_show = false;
                    }
                    else {
                        tempSire = true;
                        damhit = true;
                        $scope.searchedDog_mdl = name;
                        $scope.dogSearchTerm = type;
                        $scope.selectDog_radio = false;
                        $scope.dogResultTble = true;
                        $scope.addDam_show = false;
                        $scope.dogNotFound_show = false;
                        $scope.DogList = data;
                    }
                })
                promise.error(function (status) {
                    console.log(status.code);
                })
            }
        }
    }


    //$scope.editDog = function (dogName) {
    //    $http({
    //        method: 'POST',
    //        url: urls.api + 'SearchDogs/ById',
    //        data: JSON.stringify({Id:selectedDog})
    //    }).success(function (data, status) {
    //        console.log(data);
    //        $scope.selectedDogData = data[0];
    //        $scope.newDogName = $scope.selectedDogData.name;
    //        $scope.newColor = $scope.selectedDogData.color;
    //        $scope.newGender = $scope.selectedDogData.gender;

    //        //newGender = $scope.selectedDogData.gender;
    //        console.log('123 : '+$scope.selectedDogData.name);
    //        $scope.newAkaDogName = null;
    //    }).error(function (status) {

    //    })

    //    $scope.selectedDogError_show = false;
    //    $scope.editDog_show = true;

    //}



}]);