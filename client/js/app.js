angular.module('myApp', ['ui-router'])

.config(function($stateProvider, $urlRouterProvider) {
 
  //
  // Now set up the states
  $stateProvider
    .state('app', {
      url: "/app",
      abstract: true,
      templateUrl: "templates/home.html",
      controller: 'AppCtrl'
    });

     //
  // For any unmatched url, redirect to /state1
  $urlRouterProvider.otherwise("app/index");
});