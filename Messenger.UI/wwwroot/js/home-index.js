
$(document).ready(function () {
    getUserList();
});

function getUserList() {
    $.ajax({
        url: '/api/User/GetList',
        success: function (data) {
            console.log(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}