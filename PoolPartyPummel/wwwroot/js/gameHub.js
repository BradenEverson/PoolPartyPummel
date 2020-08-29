var connection = new signalR.HubConnectionBuilder().withUrl("./GameHub").build();

 function join(joinCode, userName) {
    connection.invoke("joinGroup", userName, joinCode).catch(function (err) {
        return console.error(err);
    });
    event.preventDefault();
}

connection.start().then(function () {
    document.getElementById("joiner").click();
}).catch(function (err) {
    return console.error(err);
});

