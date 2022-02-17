$(document).ready(() => {
    $.ajaxSetup({
        error: function (jqXHR, exception) {
            let msg = jqXHR.responseText.substr(0, jqXHR.responseText.indexOf('\r\n')).trim();
            if (jqXHR.status === 0) {
                alert('Not connect. Verify Network.');
            } else if (jqXHR.status == 404) {
                alert('Requested page not found (404).');
            } else if (jqXHR.status == 500) {
                alert(`Internal Server Error (500): ${msg}`);
            } else if (exception === 'parsererror') {
                alert('Requested JSON parse failed.');
            } else if (exception === 'timeout') {
                alert('Time out error.');
            } else if (exception === 'abort') {
                alert('Ajax request aborted.');
            } else {
                alert('Uncaught Error. ' + msg);
            }
        }
    });
});
