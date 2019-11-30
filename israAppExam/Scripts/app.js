'use strict';

angular.module('IsraSearchApp', [])
	.factory('isrSearch', isrSearchFactory)
	.controller('MainController', IsraController);

function isrSearchFactory($http) {
    var urlSearch = 'https://api.github.com/search/repositories?callback=JSON_CALLBACK&q=',

    	factory = {
    	    result: {},
    	    findDatafromgithub: findDatafromgithub
    	};
    return factory;

    function findDatafromgithub(searchData) {
        // call url with search text
        return $http.jsonp(urlSearch + searchData).then(onSuccess, onFail);
        // success return data
        function onSuccess(resp) {
            factory.result = resp.data;
            return resp.data;
        }
        // failed return data
        function onFail(resp) {           
            return {
                data: resp.data || 'בקשה נכשלה',
                status: resp.status
            };
        }
    }
}

function IsraController(isrSearch, $scope, $http) {
    var vm = this;
    vm.searchResult = {};

    angular.extend(this, {
        search: function (term) {
            isrSearch.findDatafromgithub(term || '').then(function (data) {
                // when success return data from url
                vm.searchResult = data;
            }, function (error) {
                // when failed return data from url                
                vm.searchResult = error;
            });
        }
    });

    $scope.AddToSession = function (jsondata) {        
        console.log(jsondata.item);
        var SaveData = $http({
            method: "POST",
            url: "/Home/SaveGitHubList",
            dataType: 'json',
            data: { id: jsondata.item.id, name: jsondata.item.name, url: jsondata.item.url, login: jsondata.item.owner.login, description: jsondata.item.description, watchers: jsondata.item.watchers, language: jsondata.item.language },
            headers: { "Content-Type": "application/json" }
        });

        SaveData.success(function (data, status) {
            console.log(data)
            console.log('success')
        });

        SaveData.error(function (data, status) {
            console.log(data)
            console.log('error')
        });
    };
}