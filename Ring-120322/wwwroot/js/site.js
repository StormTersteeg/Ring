// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var play_audio = false;
var audio_on = document.getElementById("audio_on");
var audio_ping = document.getElementById("audio_ping");
var audio_message = document.getElementById("audio_message");
var users = []

function AnimateBadge(elem) {
    elem.classList.remove("badge-info")
    elem.classList.add("badge-success")

    setTimeout(o => {
        elem.classList.add("badge-info")
        elem.classList.remove("badge-success")
    }, 3000)
}

function Ring(elem, user) {
    $.get(`/l/notify/${user}/${username}`, function () {});
    AnimateBadge(elem)
}

function Message(elem, user) {
    var message = encodeURIComponent(prompt("What would you like to send to " + user + "?"))
    $.get(`/l/notify/${user}/${username}/${message}`, function () {});
    AnimateBadge(elem)
}

function IsNameTaken() {
    var user = document.getElementById("username-input").value

    $.get(`/l/users`, function (data) {
        for (var i = 0; i < data.length; i++) {
            if (data[i].toLowerCase() == user.toLowerCase()) {
                alert("That username is already taken!")
                return
            }
        }
        document.getElementById("login-form").submit()
    });
}

function GetNotifications() {
    $.get(`/l/notifications/${username}`, function (data) {
        if (data.length == 2) {
            if (play_audio) {
                audio_message.pause()
                audio_message.currentTime = 0
                audio_message.play()
            }
            AddLog(data[0] + " says: " + decodeURIComponent(data[1]), "success")
        } else if (data.length == 1) {
            if (play_audio) {
                audio_ping.pause()
                audio_ping.currentTime = 0
                audio_ping.play()
            }
            AddLog(data + " notified you!", "info")
        }
    });
}

function GetUsers() {
    $.get(`/l/users`, function (data) {
        var new_users = data

        if (new_users.length != users.length) {
            window.users = new_users
            var constructed_string = ""

            for (var i = 0; i < new_users.length; i++) {
                if (new_users[i] != username) {
                    constructed_string += `
                        <h2>
                            <span>${new_users[i]}</span>
                            <span class="badge badge-info" onclick="Message(this, '${new_users[i]}')">message</span>
                            <span class="badge badge-info" onclick="Ring(this, '${new_users[i]}')">ring</span>
                        </h2>
                    `
                }
            }

            document.getElementById('users').innerHTML = constructed_string
        }
    });
}

function AddLog(message, color) {
    var current_time = 
        document.getElementById("log").innerHTML = `
    <div class="m-2 alert alert-${color}" role="alert">
    <p class="mb-0">${message}</p>
    <p class="mb-0 text-muted">${currentTime()}</p>
    </div>` + document.getElementById("log").innerHTML
}

function currentTime() {
    var systemTime = new Date();
    return `${ systemTime.getHours() }:${ systemTime.getMinutes() }`;
}

function Logout() {
    $.get(`/l/remove/${username}`, function () {
        window.location.href = "/";
    });
}

if (username != "") {
    setInterval(function () {
        GetNotifications()
        GetUsers()
    }, 500);
}