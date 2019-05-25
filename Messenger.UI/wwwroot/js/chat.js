"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/messengerHub").build();
var connectionEstablished = false;

connection.on("ReceiveMessage", function (userId, message) {

    if (receiverId == userId) {
        removeEmptyItem();

        var text = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var shownMessage = "<strong>" + receiverName + "</strong>: " + text;
        $('#messageList').append("<li class='w-100'><div class='row col-sm-12'><p class='w-100 mb-1 word-break'>" + shownMessage + "</p></div></li>");
    }

    updateScroll();
});

connection.start().then(function () {
    connectionEstablished = true;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {

    var text = document.getElementById("messageInput").value.trim();
    if (!text) {
        return;
    }

    if (!connectionEstablished) {
        swal("Error", "Connection is not established");
        return;
    }

    connection.invoke("SendMessage", senderId, receiverId, text).catch(function (error) {
        swal("Error", error.toString());
        return;
    });

    $("#messageInput").val('');
    removeEmptyItem();

    var shownMessage = "<strong>You</strong>: " + text;
    $('#messageList').append("<li class='w-100'><div class='row col-sm-12'><p class='w-100 mb-1 word-break'>" + shownMessage + "</p></div></li>");

    updateScroll();
    event.preventDefault();
});