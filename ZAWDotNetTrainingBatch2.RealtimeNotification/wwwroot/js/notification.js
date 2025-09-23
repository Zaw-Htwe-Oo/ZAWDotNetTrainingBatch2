"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/notificationHub")
    .build();

let count = 0;
let announcements = [];

connection.on("ReceiveAnnouncement", function (title, content) {
    count++;
    document.getElementById("notificationCount").textContent = count;

    announcements.push({ title, content });
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("showListBtn").addEventListener("click", function () {
    const list = document.getElementById("announcementList");
    list.innerHTML = "";

    announcements.forEach(a => {
        const li = document.createElement("li");
        li.innerHTML = `<strong>${a.title}</strong>: ${a.content}`;
        list.appendChild(li);
    });
});
