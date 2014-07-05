var Twit = angular.module('Twit', ['ngRoute'])
.service('GetService', function ($http, $log) {
    this.TweetsByTwits = function (IdArray, tweets) {

        //loop through the IdArray array and load each one into the twits array
        for (var id in IdArray) {
            $http.get('/api/twit/' + IdArray[id])
            .success(function (twit, status) {
                $log.info('GET twit:');
                $log.info(twit);
                tweets.concat(twit.Tweets);
            })
            .error(function () {
                $log.error('Connection Error');
            })
        }

        return tweets;
    }

    this.Tweets = function (IdArray) {
        $log.info('Tweets was called with IdArray=' + IdArray)
        var tweets = [];
        //loop through the IdArray array and load each one into the tweets array
        for (var id in IdArray) {
            $log.info('id=' + id + ' IdArray=' + IdArray);
            $http.get('/api/tweet/' + IdArray[id])
            .success(function (tweet, status) {
                tweets.push(tweet);
            })
            .error(function () {
                $log.error('Connection Error');
            })
        }

        return tweets;
    }
})

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
    .when('/Tweets', {
        templateUrl: 'Tweets.html',
        caseInsensitiveMatch: true,
        controller: 'TweetController'
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

                // Load tweets
                $location.path('/tweets');
            }
            else { $location.path('/notfound'); }
        })
        .error(function (data, status) {
            $location.path('/notfound');
        })

    }
});

Twit.controller('People', function ($scope, $location, $http, $log, $rootScope) {
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

    //filter out twits that aren't followers of current logged-in user
    $scope.isFollower = function (id) {
        if ($scope.justFollowers) {
            $log.info("Twit Id " + id);
            return $rootScope.user.FollowerIds.indexOf(id) > -1;
        }

        else {
            return true;
        }
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

Twit.controller('TweetController', function ($rootScope, $location, $scope, $log, $http) {
    if ($rootScope.user) {
        var twitIds = [$rootScope.user['Id']].concat($rootScope.user['FollowingIds']);

        var TweetObj = function (tweet, img) {
            this.Tweet = tweet;
            this.Image = img;
        }

        $scope.Tweets = [];

        for (var id in twitIds) {
            $http.get('/api/twit/' + twitIds[id])
                .success(function (twit) {
                    if (twit) {
                        for (var t in twit.Tweets) {
                            $scope.Tweets.push(new TweetObj(twit.Tweets[t], twit.ImgUrl));
                        }
                    }
                })
                .error($log.error('Connection Error'));
        }
    }

    else {
        $location.path('/');
    }

});

