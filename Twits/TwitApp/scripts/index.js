var Twit = angular.module('Twit', []);

Twit.controller('LoginTweet', function ($scope) {
    $scope.loggedIn = false;
    $scope.user = 'Anonymous';

    $scope.Login = function () {
        $scope.loggedIn = true;
    }
});