var Twit = angular.module('Twit', []);

Twit.controller('LoginTweet', function ($scope) {
    $scope.loggedIn = false;
    $scope.user = 'Anonymous';

    $scope.Login = function () {
        $scope.loggedIn = true;
    }
});

Twit.controller('People', function ($scope, $http) {
    $scope.showLoading = true;
    $scope.img = "ImgUrl";
    $http({ method: 'GET', url: '/api/twit' })
    .success(function (data, status) {
        $scope.people = data;
        //console.log('before: $scope.loading=' + $scope.loading);
        $scope.showLoading = false;
        //console.log('after: $scope.loading=' + $scope.loading);
    });
 
});