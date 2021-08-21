var app = angular.module('app');
app.controller('RegisterController', function ($window,$http,$scope,$location, $rootScope, $stateParams, $state, LoginService) {
    $rootScope.title = "AngularJS Login Sample";
 
    $scope.formSubmit = function () {
        //console.log("truus" + $scope.username);
        var username = $scope.username;
        var password = $scope.password;
        var email = $scope.email;
        var request = $http({
            method: "Post",
            url: "http://localhost/ZwartsApi/api/authenticate/register",
            headers: { 'Content-Type': 'application/json' },
            data: { 'username': username,'email':email, 'password': password }
        });
      
        request.success(function (data) {
            var response = data;
            //console.log("truus" + JSON.stringify(response));
            if (response != '' || response != undefined && response != '') {
                $scope.error = '';
                $scope.username = '';
                $scope.password = '';
                $scope.email = '';
                if (response.Status = "Successfully registered") {
                    alert("Registered successfully!!");
                    $state.transitionTo('login');
                } else {
                    $scope.error = "Incorrect username/password !";
                }
            } else {
                $scope.error = "Incorrect username/password !";
            }

        }).error(function (data) {
           // console.log("error" + JSON.stringify(data));
            $scope.error = data.Message;

        });

       
    };
});