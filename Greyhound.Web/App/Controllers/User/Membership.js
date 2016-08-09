appGreyhound
.controller('MembershipController', ['$scope', '$http', 'urls', function ($scope, $http, urls) {

    //fill country drop down
    var httpRequest = $http({
        method: 'GET',
        url: urls.api + 'MasterData/Countries'

    }).success(function (data, status) {
        $scope.countryDetails = data;
        //$scope.cmbCountry = $scope.countryDetails[0];
    })
    .error(function (error) {
        $scope.status = 'Unable to load Country Details: ' + error.message;
        console.log($scope.status);
    }); 

    //fill membership drop down
    var httpRequest = $http({
        method: 'GET',
        url: urls.api + 'MasterData/MemberTypes'

    }).success(function (data, status) {
        $scope.MemberTypes = data;
        //$scope.cmbCountry = $scope.countryDetails[0];
    })
    .error(function (error) {
        $scope.status = 'Unable to load Membership Details: ' + error.message;
        console.log($scope.status);
    });

    $scope.cmbCountry = 1;
    $scope.cmbMemberType = 1;

    $scope.showmembership = true;
    $scope.registerMember = function () {
        
        $scope.success = false;
        $scope.fail = false;

        var dataObj = {
            FirstName: $scope.fname,
            LastName: $scope.lname,
            Email: $scope.email,
            State: $scope.state,
            ContactNo: $scope.contact,
            CountryId: $scope.cmbCountry,
            MemberTypeId: $scope.cmbMemberType
        };

        $scope.navigateToPath = '#/';

        var httpRequest = $http({
            method: 'POST',
            url: urls.api + 'User/PostMem',
            data: JSON.stringify(dataObj)
        }).success(function (data, status) {
            $scope.success = true;
            $scope.showmembership = false;
            $scope.message = membership.success;        
        })
        .error(function (data, status) {
            $scope.fail = true;
            $scope.message = JSON.stringify(data.message);
        });

    }

    $scope.validateEmpty = function () {
        $scope.incomplete = true;

        if (!$scope.membershipForm.fname.$invalid && $scope.membershipForm.fname.$dirty)
            if (!$scope.membershipForm.lname.$invalid && $scope.membershipForm.lname.$dirty)
                if (!$scope.membershipForm.contact.$invalid && $scope.membershipForm.contact.$dirty)
                    if (!$scope.membershipForm.email.$invalid && $scope.membershipForm.email.$dirty)
                        $scope.incomplete = false;
    }

    $scope.comparePasswords = function () {
        $scope.error = true;
        if ($scope.membershipForm.password.$dirty && $scope.membershipForm.confirmPassword.$dirty) {
            if ($scope.password == $scope.confirmPassword) {
                $scope.error = false;
            }
        }
        else
            $scope.error = false;
    }

    $scope.$watch('[fname,lname,email,contact]', function () {
        $scope.validateEmpty();
    })   
}])


