var secondsRemaining;

var startCartTimer = function() {
    if ($('#cartTimer').length > 0) {
        secondsRemaining = $('#cartTimer').html();
        updateCartTimer();
    } else {
        return;
    }
};

var convertSecondsToTime = function(seconds) {
    var min = Math.floor(seconds / 60);
    var sec = seconds - (min * 60);
    return min + ":" + (sec > 9 ? sec : "0" + sec);
};

var updateCartTimer = function() {
    var timerDisplayString;

    if (secondsRemaining <= 0) {
        timerDisplayString = "0:00";
    } else {
        timerDisplayString = convertSecondsToTime(secondsRemaining);
    }

    if (secondsRemaining <= 60 && secondsRemaining % 2 === 0) {
        timerDisplayString = "<span style='color:#FF0000;'>" + timerDisplayString + "</span>";
    }

    $('#cartTimer').html(timerDisplayString);

    if (secondsRemaining > 0) {
        setTimeout(updateCartTimer, 1000);
    }

    secondsRemaining--;
};

$('document').ready(startCartTimer);
