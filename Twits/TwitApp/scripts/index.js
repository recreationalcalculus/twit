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
        //check to see if there is an id matching what was entered
        $http.get('/api/twit/' + $scope.idNumber)
        .success(function (data, status) {
            //if the id matches, check that the right name was entered too
            if (data['Name'].toLowerCase() == $scope.logName.toLowerCase()) {
                //set global user to point at the person who just logged in
                $rootScope.user = data;
                $log.info(data);
                //create array for followers
                var following = [];
                //loop through the FollowerIds array and load each one into the followers array
                for (var id in $rootScope.user['FollowingIds']) {
                    $log.info(id);
                    $http.get('/api/twit/' + $rootScope.user['FollowingIds'][id])
                    .success(function (follower, status) {
                        following.push(follower);
                        $log.info($scope.following);
                    })
                    .error(function () {
                        $log.error('Connection Error');
                    })
                }
                // populate the Following panel
                $scope.Following = following;

                // show the Following panel and tweet panel
                $rootScope.loggedIn = true;
            }
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
        //populate Followers panel


        //switch to tweet panel & reveal follower panel
        $scope.showLoading = false;
    })
    .error(function (data, status) {
        $location.path('/notfound');
    });
});

/*
Twit.controller('Followers', function ($scope, $http, $rootScope, $log) {
    $scope.Followers = [];
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