var phonecatApp = angular.module('OrdersApp', []);

phonecatApp.controller('OrdersController', function PhoneListController($scope) {

    $scope.sortByManager = function (reverse) {

        $scope.orders.sort(function (a, b) {

            if (a.Manager > b.Manager) {
                return 1;
            }
            else if (a.Manager === b.Manager) {
                return 0;
            }
            else {
                return -1;
            }

        });

        if (reverse)
            $scope.orders.reverse();

    };

    $scope.sortByNumber = function (reverse) {

        $scope.orders.sort(function (a, b) {

            if (a.Number > b.Number) {
                return 1;
            }
            else if (a.Number < b.Number) {
                return -1;
            }

        });

        if (reverse)
            $scope.orders.reverse();

    };


    

    $scope.managers = {};

    $scope.orders = {};
    angular.element(document).ready(function () {


        

        $.ajax({
            url: "/api/managers",
            method: "GET",
            success: function (data) {

                $scope.managers = JSON.parse(data);
                $scope.$apply();

            },
        });



        $.ajax({
            url: "/api/get",
            method: "POST",
            success: function (data) {

                $scope.orders = JSON.parse(data);
                $scope.$apply();

            },

        });


    });





    $scope.addOrder = function (_note) {

        var e = document.getElementById("manager");
        var manager = e.options[e.selectedIndex].value;

        $.ajax({
            url: "/api/add",
            method: "POST",
            data: {
                manager: manager,
                note: _note,
            },
            success: function (data) {
                $scope.orders = JSON.parse(data);

                $("#note").val("");

                $scope.$apply();
            },
            error: function (data) {
                console.log(data);
            }

        });


    };



    $scope.editingOrder = {};
    $scope.openEditForm = function (number, note, manager, id) {

        $scope.editingOrder = { Number: number, Note: note, ID: id };

        $("#mngr").val(manager);
    };

    $scope.editOrder = function () {
        $.ajax({
            url: "/api/edit",
            method: "POST",
            data: {
                note: $scope.editingOrder.Note,
                id: $scope.editingOrder.ID,
                manager: $("#mngr").val()
            },
            success: function (data) {
                $scope.orders = JSON.parse(data);
                $scope.$apply();
            }


        });
    }


});