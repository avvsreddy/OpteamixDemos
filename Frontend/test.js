function callApi(url, callback) {
    const xhr = new XMLHttpRequest();
    xhr.open('GET', url, true);
    xhr.onreadystatechange = function() {
        if (xhr.readyState === XMLHttpRequest.DONE) {
            if (xhr.status >= 200 && xhr.status < 300) {
                callback(null, xhr.responseText);
            } else {
                callback(new Error('Request failed with status ' + xhr.status));
            }
        }
    };
    xhr.send();
}

// Example usage:
const apiUrl = 'https://jsonplaceholder.typicode.com/posts/1';
callApi(apiUrl, function(error, response) {
    if (error) {
        console.error('API call failed:', error);
    } else {
        console.log('API response:', response);
    }
});
