var Twit = angular.module('Twit', ['ngRoute']);

Twit.config(function ($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: 'blank.html'
    })
    .when('/Twit/:Id', {
        templateUrl: 'Twit.html',
        caseInsensitiveMatch: true,
        controller: 'TwitController'
    })
    .when('/Twit/:Id/Tweets', {
        templateUrl: 'TwitTweets.html',
        caseInsensitiveMatch: true,
        controller: 'TwitTweetController'
    })
    .when('/notfound', {
        templateUrl: 'error.html',
        caseInsensitiveMatch: true
    })
    .otherwise({
        redirectTo: '/notfound'
    });
});

Twit.controller('LoginTweet', function ($scope) {
    $scope.loggedIn = false;
    $scope.user = 'Anonymous';

    $scope.Login = function () {
        $scope.loggedIn = true;
    }
});

Twit.controller('People', function ($scope, $location, $http) {
    $scope.showLoading = true;
    $scope.img = "ImgUrl";
    $http({ method: 'GET', url: '/api/twit' })
    .success(function (data, status) {
        $scope.people = data;
        $scope.showLoading = false;
        
    });

    $scope.go = function (id) {
        $location.path('twit/' + id);
    }

});

Twit.controller('TwitController', function ($scope, $http, $location, $routeParams) {
    $scope.showLoading = true;
    $http.get('/api/twit/' + $routeParams.Id)
    .success(function (data, status) {
        $scope.twit = data;
        $scope.showLoading = false;
    })
    .error(function (data, status) {
        $location.path('/notfound');
    });

    $scope.tweets = function () {
        $location.path('/Twit/'+$scope.twit.Id+'/Tweets')
    }
});

Twit.controller('TwitTweetController', function ($scope, $http, $location, $routeParams) {
    $scope.showLoading = true;
    $http.get('/api/twit/' + $routeParams.Id)
    .success(function (data, status) {
        $scope.twit = data;
        $scope.showLoading = false;
    })
    .error(function (data, status) {
        $location.path('/notfound');
    });
});