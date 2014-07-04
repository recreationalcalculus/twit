var htmlWrapper = {};

htmlWrapper.PersonTile = function (person) {
    html = '';
    name = "Bob";
    imgUrl = "http://www.lorempixel.com/300/300;";
    body = "Lorem ipsum sit amet. Troca upso mita tol!";
    timestamp = Date.now;
    html += '<div class="PersonTile btn btn-default">';
    html += '<img src="' + imgUrl + '" />';
    html += name + ' said:';
    html += '<p>' + body + '</p>';
    html += '<small>-timestamp</small>';
    html += '</div>';
    return html;
}