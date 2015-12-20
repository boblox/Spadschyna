angular.module("umbraco").controller("grid.coloured_header.controller", function ($scope) {
    if ($scope.control.value == null) {
        $scope.control.value = {
            colour: "orange"
        }
    }
});