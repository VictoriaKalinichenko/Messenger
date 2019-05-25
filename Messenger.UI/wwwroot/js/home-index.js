
var senderId;
var senderName;

var receiverId;
var receiverName;

$(document).ready(function () {
    getUserList();

    senderId = $('#Id').val();
    senderName = $('#UserName').val();
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
        $(".list-group").append('<a href="javascript:void(0);" class="list-group-item list-group-item-action" id="' + item.id + '" name="user-list-item">' + item.userName + '</a>');
    });

    $("[name='user-list-item']").bind('click', function (event) {
        receiverId = event.target.id;
        receiverName = event.target.textContent;

        $("[name='user-list-item']").removeClass('active');
        $("#" + event.target.id).addClass('active');

        enableSendingMessages();
        getMessageList();
    });
}

function getMessageList() {
    $.ajax({
        url: '/api/User/GetMessageList',
        data: {
            senderId: senderId,
            receiverId: receiverId
        },
        success: function (data) {
            showMessageList(data);
        },
        error: function () {
            swal("Error", "Some error was occurred while processing your request!");
        }
    });
}

function enableSendingMessages() {
    $('#sendButton').prop('disabled', false);
    $('#messageInput').prop('disabled', false);
}

function showMessageList(messageList) {
    if (messageList.length == 0) {
        $('#messageList').html("<li class='w-100' id='empty-message-list'><div class='row col-sm-12'><p class='w-100 empty-text text-center'>The message list is empty</p></div></li>");
        return;
    }

    $('#messageList').html('');

    messageList.forEach(function (item) {
        var shownMessage;

        if (item.senderId == senderId) {
            shownMessage = "<strong>You</strong>: " + item.text;
            $('#messageList').append("<li class='w-100'><div class='row col-sm-12'><p class='w-100 mb-1 word-break'>" + shownMessage + "</p></div></li>");
        }

        if (item.senderId == receiverId) {
            shownMessage = "<strong>" + receiverName + "</strong>: " + item.text;
            $('#messageList').append("<li class='w-100'><div class='row col-sm-12'><p class='w-100 mb-1 word-break'>" + shownMessage + "</p></div></li>");
        }
    });

    updateScroll();
}

function removeEmptyItem() {
    var children = $('#messageList').children();

    if (children[0].id == 'empty-message-list') {
        $('#messageList').html('');
    }
}

function updateScroll() {
    var element = document.getElementById("messageBox");
    element.scrollTop = element.scrollHeight;
}