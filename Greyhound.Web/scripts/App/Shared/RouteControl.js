/// <reference path="../../Views/Tracks/TrackCountryDetails.html" />
/// <reference path="../DogSearch/DogSearch.js" />
appGreyhound

//.constant("greyJS",{
//    "DogSearch.html" : ""
//})

.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    ////check browser support
    //if (window.history && window.history.pushState) {        
    //    //don't wanna set base URL
    //    $locationProvider.html5Mode(true);
    //}

    $routeProvider.caseInsensitiveMatch = true;
    $routeProvider.
    
         when('/Forum', {
             templateUrl: 'App/Views/Forum/MainPage.html',
             controller: ''
         }).
         when('/Discussion', {
             templateUrl: 'App/Views/Forum/Discussion.html',
             controller: ''
         }).
         when('/UserProfile', {
             templateUrl: 'App/Views/Forum/UserProfile.html',
             controller: ''
         }).


        //tracks
        when('/Tracks', {
            templateUrl: 'App/Views/Tracks/Track.html',
            controller: ''
        }).
        when('/Stadium', {
            templateUrl: 'App/Views/Tracks/Stadium.html',
            controller: ''
        }).


        when('/Home', {
            templateUrl: 'App/Views/Shared/Content.html',
            controller: ''
        }).

         //user welcome
        when('/Welcome', {
            templateUrl: 'App/Views/User/Welcome.html',
            controller: ''
        }).

         //user logout
        when('/Logout', {
            templateUrl: 'App/Views/User/Logout.html',
            controller: ''
        }).

        //dog search
        when('/DogSearch/', {
            controller: '',
            templateUrl: 'App/Views/Dog/DogSearch.html'
            /*templateUrl: function (params) {
                return '../Content/View/Dog/DogSearch.html';
            }*/
            
        }).
        //dog pedigree
         when('/Pedigree/:dogId?', {
             templateUrl: 'App/Views/Dog/Pedigree.html',
             controller: ''
         }).
            
        //user reigster
        when('/Register',{
            templateUrl: 'App/Views/User/Register.html',
            controller: ''
        }).

        //user membership
        when('/Membership', {
            templateUrl: 'App/Views/User/Membership.html',
            controller: ''
        }).

        //user login
        when('/Login', {
            templateUrl: 'App/Views/User/Login.html',
            controller: ''
        }).

        //user forgot password
        when('/ForgotPassword', {
            templateUrl: 'App/Views/User/ForgotPassword.html',
            controller: ''
        }).

        //user reset password
        when('/ResetPassword', {
            templateUrl: 'App/Views/User/ResetPassword.html',
            controller: ''
        }).

        when('/RegistrationSuccess', {
            templateUrl: 'App/Views/User/RegisteredSuccess.html',
            controller: ''
        }).

        when('/Tattoo', {
            templateUrl: 'App/Views/Dog/TattooSearch.html',
            controller: ''
        }).

         when('/TattooSearch', {
             templateUrl: 'App/Views/Dog/TattooResult.html',
             controller: ''
         }).

         when('/Races', {
             templateUrl: 'App/Views/Race/Races.html',
             controller: ''
         }).

        when('/Add-Race', {
            templateUrl: 'App/Views/Race/AddRace.html',
            controller: ''
        }).

         when('/Coursing', {
             templateUrl: 'App/Views/Coursing/Coursing.html',
             controller: ''
         }).

        when('/RaceResult', {
            templateUrl: 'App/Views/Race/RaceResult.html',
            controller:''
        }).

        when('/RaceDetails', {
            templateUrl: 'App/Views/Race/RaceDetails.html',
            controller:''
        }).

         when('/Coursing', {
             templateUrl: 'App/Views/Coursing/Coursing.html',
             controller: ''
         }).

        when('/Kennels', {
            templateUrl: 'App/Views/Kennels/KennelsView.html',
            controller: ''
        }).

        when('/KennelDetails', {
            templateUrl: 'App/Views/Kennels/KennelDetails.html',
            controller: ''
        }).

        when('/Kennels/AddKennel', {
            templateUrl: 'App/Views/Kennels/AddKennel.html',
            controller: ''
        }).

        //when('/Tracks/:countryId?/:stadiumId?', {
        //    templateUrl: 'App/Views/Tracks/StadiumDetails.html',//'App/Views/Tracks/TracksDetails.html',
        //    controller: ''
        //}).

        //when('/Tracks/Country', {
        //    templateUrl: 'App/Views/Tracks/TrackCountryDetails.html',
        //    controller: ''
        //}).
         
        

        when('/RaceDetails/FullMeeting', {
            templateUrl: 'App/Views/Race/FullMeeting.html',
            controller:''
        }).

        when('/AddKennel', {
            templateUrl: 'App/Views/Kennels/AddKennel.html',
            controller: ''
        }).

         when('/Classifieds', {
             templateUrl: 'App/Views/Classifieds/Classifieds.html',
             controller: ''
         }).

        when('/Classifieds/pups-for-sale', {
            templateUrl: 'App/Views/Classifieds/PupsForSale.html',
            controller: ''
        }).

        when('/Classifieds/dogs-for-sale', {
            templateUrl: 'App/Views/Classifieds/DogsForSale.html',
            controller: ''
        }).

        when('/Classifieds/bussiness-ads', {
            templateUrl: 'App/Views/Classifieds/BusinessAds.html',
            controller: ''
        }).

         when('/Classifieds/private-ads', {
             templateUrl: 'App/Views/Classifieds/PrivateAds.html',
             controller: ''
         }).

        when('/Classifieds/litter-ads', {
            templateUrl: 'App/Views/Classifieds/PlaceLitterAd.html',
            controller: ''
        }).

        when('/Classifieds/place-dog-ads', {
            templateUrl: 'App/Views/Classifieds/PlaceDogAd.html',
            controller: ''
        }).

        when('/Classifieds/place-misc-ads', {
            templateUrl: 'App/Views/Classifieds/PlaceMiscAd.html',
            controller: ''
        }).

        when('/Active-Sires', {
            templateUrl: 'App/Views/Active-Sires/Active-Sires.html',
            controller: ''
        }).

        when('/Dog-view/', {
            templateUrl: 'App/Views/Dog/Dog-view.html',
            controller: ''
        }).

        when('/Sire-Pages/Add-New-Sire', {
            templateUrl:'App/Views/Sire-Pages/Add-New-Sire.html',
            controller:''
        }).

        when('/Sire-Pages', {
            templateUrl: 'App/Views/Sire-Pages/Sire-Pages-List.html',
            controller: ''
        }).

        when('/Sire-Pages/Sire-Details', {
            templateUrl: 'App/Views/Sire-Pages/Sire-Details.html',
            controller: ''
        }).

        when('/Sire-Pages/New-Sire-Details/:dogId?', {
            templateUrl: 'App/Views/Sire-Pages/New-Sire-Details.html',
            controller: ''
        }).

        when('/Race-Cards', {
            templateUrl: 'App/Views/RaceCards/RaceCards.html',
            //templateUrl: 'App/Views/Sire-Pages/Add-New-Sire.html',
            controller: ''
        }).

        when('/Private-Messages', {
            templateUrl: 'App/Views/PrivateMessages/Home.html',
            controller: ''
        }).

        when('/Videos', {
            templateUrl: 'App/Views/Library/Videos.html',
            controller: ''
        }).

        when('/Photos', {
            templateUrl: 'App/Views/Library/Photos.html',
            controller: ''
        }).

        when('/Ask-The-Vet/Home', {
            templateUrl: 'App/Views/Ask-The-Vet/Home.html',
            controller: ''
        }).

        when('/Newsletter', {
            templateUrl: 'App/Views/Newsletter/Newsletter.html',
            controller: ''
        }).

        when('/Newsletter/Article/:id?', {
            templateUrl: 'App/Views/Newsletter/Article.html',
            controller: ''
        }).


        when('/AboutUs', {
            templateUrl: 'App/Views/AboutUs.html',
            controller: ''
        }).

        when('/Links', {
            templateUrl: 'App/Views/Links.html',
            controller: ''
        }).

        when('/Library', {
            templateUrl: 'App/Views/Library/Library.html',
            controller: ''
        }).

        when('/Site-Usage', {
            templateUrl: 'App/Views/SiteUsage.html',
            controller: ''
        }).

         when('/Management', {
             templateUrl: 'App/Views/Management/Home.html',
             controller: ''
         }).

        when('/Test', {
            templateUrl: 'App/Views/Test.html',
            controller: ''
        }).

         when('/Statistics', {
             templateUrl: 'App/Views/Statistics/Statistics.html',
             controller: ''
         }).

        when('/Testmating', {
            templateUrl: 'App/Views/Testmating/Testmating_home.html',
            controller: ''
        }).

        when('/Testmating/Future-Litter', {
            templateUrl: 'App/Views/Testmating/FutureLitter.html',
            controller: ''
        }).
        
        //home page
        otherwise({
            redirectTo: '/',
            templateUrl: 'App/Views/Shared/Content.html',
            controller: ''
        });
}])

//.controller('ctrlODL', ['$scope', '$http', 'urls', function ($scope, $http, urls) {    
//    var fileref = document.createElement('script')
//    fileref.setAttribute("type", "text/javascript")
//    fileref.setAttribute("src", 'Content/scripts/DogSearch/DogSearch.js')
//    console.log(document);
//}])

//.directive('greyHff', function (urls) {
//    return {
//        restrict: 'A',
//        templateUrl: urls.domain + "Content/View/Shared/Footer.html"
//    };
//})