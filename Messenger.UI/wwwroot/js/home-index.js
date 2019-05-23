
$(document).ready(function () {
    getUserList();
});

function getUserList() {
    $.ajax({
        url: '/api/User/GetList',
        success: function (data) {
            showUserList(data);
        },
        error: function () {
            swal("Error", "Some error was occurred while processing your request!");
        }
    });
}

function showUserList(userList) {

    userList.forEach(function (item) {
        var li = document.createElement("li");
        li.id = item.id;
        document.getElementById("userList").appendChild(li);

        var link = document.createElement("a");
        link.href = "#";
        link.textContent = item.userName;
        document.getElementById(item.id).appendChild(link);
    });
}