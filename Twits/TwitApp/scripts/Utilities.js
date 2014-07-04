var Utilities = {}

Utilities.ValidateLogin = function () {
    var name = document.getElementById('logName').value;
    console.log('logName=' + name + ' typeof logName=' + typeof name);

    var id = document.getElementById('idNumber').value;
    console.log('id=' + id + ' typeof id=' + typeof id);

    if (name && parseInt(id))  {
        document.getElementById('loginButton').disabled = false;
    }

    else {
        document.getElementById('loginButton').disabled = true;
    }
}

//convert the viewmodel object sent through Web API to a native javascript object
Utilities.Tweet = function (tweet) {
    this.Author = tweet.AuthorName;
    this.AuthorId = tweet.AuthorId;
    this.Body = tweet.Body;
    this.Id = tweet.Id;
    this.Timestamp = new Date(tweet.Timestamp);
}

Utilities.GetTweetHTML = function(twitImgUrl,tweet) {
    var html = '';
    var getTimestamp = function () {
        var date = tweet.Timestamp;
        return date.toLocaleTimeString() + (date.getDate() == (new Date()).getDate() ? '' : ' (' + Math.round(((new Date()) - date) / 86400000, 0) + ' days ago)');
    }
    html += '<blockquote class="TweetTile container">';
    html += '<img src="' + twitImgUrl + '">';
    html += '<div class="TweetTileInnerText">';
    html += '<h1>'+tweet.Author+' (ID: '+tweet.AuthorId+') said: </h1>';
    html += '<p>'+tweet.Body+'</p>';
    html += '<p><small>'+getTimestamp()+'</small></p>';
    html += '</div>';
    html += '</blockquote>';

    return html;

    /* Template:

            <blockquote class="TweetTile container">
                <img src="{{twit['ImgUrl']}}">
                <div class="TweetTileInnerText">
                    <h1>{{twit['Name']}} (ID: {{twit['Id']}}) said: </h1>
                    <p>{{tweet['Body']}}</p>
                    <p><small>{{tweet['Timestamp']}} </small></p>
                </div>
            </blockquote>

    Timestamp string:
    date.toLocaleTimeString() + (date.getDate() == (new Date()).getDate() ? '' : ' ('+Math.round(((new Date())-date)/86400000,0) + ' days ago)')


    */
}