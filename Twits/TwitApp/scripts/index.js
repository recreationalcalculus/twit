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

Twit.controller('LoginTweet', function ($scope, $http, $location, $rootScope, $log) {
    $rootScope.loggedIn = false;
    $scope.user = 'Anonymous';

    $scope.Login = function () {
        $log.info($scope.idNumber);
        $http.get('/api/twit/' + $scope.idNumber)
        .success(function (data, status) {
            $rootScope.user = data;
            $log.info(data);
            if (data['Name'].toLowerCase() == $scope.logName.toLowerCase()) { $rootScope.loggedIn = true; }
            else { $location.path('/notfound'); }
        })
        .error(function (data, status) {
            $location.path('/notfound');
        })

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
        $location.path('/Twit/' + $scope.twit.Id + '/Tweets')
    }
});

Twit.controller('TwitTweetController', function ($scope, $log, $http, $location, $routeParams) {
    $log.info('TwitTweetController called');
    $scope.showLoading = true;

    $http.get('/api/twit/' + $routeParams.Id)
    .success(function (data, status) {
        $scope.twit = data;
        $log.info(data);
        for (tweet in data.Tweets) {
            $log.info(data.Tweets);
        }
        $scope.showLoading = false;
    })
    .error(function (data, status) {
        $location.path('/notfound');
    });
});

/*
Twit.controller('Followers', function ($scope, $http, $rootScope, $log) {
    $scope.Followers = [];
    $scope
    for (var id in $rootScope.user['FollowerIds']) {
        $http.get('/api/twit/' + id)
        .success(function (data, status) {
            $scope.Followers.push(data);
            $log.info($scope.Followers);
        })
        .error(function () {
            $log.error('Connection Error');
        })
    }

});
*/