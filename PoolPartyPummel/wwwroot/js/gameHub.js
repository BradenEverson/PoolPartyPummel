document.getElementById("send").disabled = true;
var images = ["tube1.png", "tube2.png", "tube3.png", "tube4.png"];
var canvasContext;
var timer;
var canvas;
var connection = new signalR.HubConnectionBuilder().withUrl("./GameHub").build();
var count = 0;
function join(joinCode, userName) {
    document.getElementById("splashAudio").play();
    connection.invoke("joinGroup", userName, joinCode).catch(function (err) {
        return console.error(err);
    });
    event.preventDefault();
}
connection.on("newUser", function (name) {
    count++;
    document.getElementById("usersOnline").innerHTML = count + " users online"
    document.getElementById("body").innerHTML = name + " just joined the party!";
    $("#alert").modal('show');
    initializeNewTube();
});
function initializeNewTube() {
    canvas = document.getElementById("pool");
    canvasContext = canvas.getContext("2d");
    timer = setInterval(drawTube(images[Math.floor(Math.random() * images.length)]), 10);
}
function drawTube(source) {
    canvasContext.clearRect(0, 0, canvas.width, canvas.height);
    canvasContext.drawImage("./images/tubes/" + source, 0,0);
}
connection.on("newMessage", function (user, message) {
    document.getElementById("message").value = "";
    var ul = document.getElementById("chat");
    var li = document.createElement("li");
    li.innerHTML = "<h6 class='text-info'>" + user + "</h6>" + message;
    li.setAttribute("class", "list-group-item");
    li.setAttribute("style", "margin:2px");
    ul.appendChild(li);
});
connection.start().then(function () {
    document.getElementById("send").disabled = false;
    document.getElementById("poolAmbience").play();
    document.getElementById("joiner").click();
}).catch(function (err) {
    return console.error(err);
});
function send(name, guid) {
    var message = document.getElementById("message").value;
    connection.invoke("sendMessage", name, message, guid).catch(function (err) {
        return console.error(err);
    });
    event.preventDefault();
}