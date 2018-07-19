var myapp = angular.module("myModule", []);
myapp.controller("TestController", TestController);
function TestController($scope) {
    //$scope.name = "Ha Thanh Dung";
    //$scope.class = "GCS0402";
    //var students =
    //[
    //    {
    //        Name: "Ha Thanh Dung12",
    //        Class: "GCS0402",
    //        Number: "GS140103"
    //        },
    //    {
    //        Name: "Ha Thanh Dung",
    //        Class: "GCS0401",
    //        Number: "GS140023"
    //        },
    //    {
    //        Name: "Ha Thanh 32",
    //        Class: "GCS0492",
    //        Number: "GS140043"
    //        },
    //    {
    //        Name: "Ha Thanh Dung6",
    //        Class: "GCS04032",
    //        Number: "GS140033"
    //        },
    //    {
    //        Name: "Ha Thanh Dung7",
    //        Class: "GCS04022",
    //        Number: "GS140023"
    //    }
    //    ];
    var students =
        [
            {
                Name: "Ha Thanh Dung12",
                Class: "GCS0402",
                Number: "GS140103",
                country: [
                    { name: "VietNam" },
                    { name: "Ho Chi Minh" },
                    { name: "Quang Ngai" }
                ]
            },
            {
                Name: "Ha Thanh Dung",
                Class: "GCS0401",
                Number: "GS140023",
                country: [
                    { name: "VietNam" },
                    { name: "Ho Chi Minh" },
                    { name: "Quang Ngai" }
                ]
            },
            {
                Name: "Ha Thanh 32",
                Class: "GCS0492",
                Number: "GS140043",
                country: [
                    { name: "VietNam" },
                    { name: "Ho Chi Minh" },
                    { name: "Quang Ngai" }
                ]
            },
            {
                Name: "Ha Thanh Dung6",
                Class: "GCS04032",
                Number: "GS140033",
                country: [
                    { name: "VietNam" },
                    { name: "Ho Chi Minh" },
                    { name: "Quang Ngai" }
                ]
            },
            {
                Name: "Ha Thanh Dung7",
                Class: "GCS04022",
                Number: "GS140023",
                country: [
                    { name: "VietNam" },
                    { name: "Ho Chi Minh" },
                    { name: "Quang Ngai" }
                ]
            }
        ];
    var technologies = [
        { Name: "Asp.net Mvc", Likes: 0, Dislike: 0,Status:true },
        { Name: "PHP", Likes: 0, Dislike: 0,Status:false },
        { Name: "Java Swing", Likes: 0, Dislike: 0, Status: false },
        { Name: "Ruby on Rails", Likes: 0, Dislike: 0, Status: true }
        ];

    $scope.techonology = technologies;
    $scope.increaseLike = function(technology) {
        technology.Likes++;
    }
    $scope.increaseDisLike = function (technology) {
        technology.Dislike++;
    }

}

myapp.filter('status', function() {
    return function(input) {
        if (input == true) {
            return "Kích Hoạt";
        } else {
            return "Khóa";
        }
    }
});