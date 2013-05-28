var http = require('http')
var port = 8088;
var body = "<html><body>Hello world!</body></html>";
http.createServer(function (req, res) {
    //res.writeHead(200);
    res.writeHead(200, [
     ["Content-Type", "text/plain"],
     ["Content-Length", body.length]
    ]);
    res.end(body);
}).listen(port);