window.bridge = {
    send: (event) => {
        console.log("send: ", { event });
    },
    jsonParse: (json) => {
        const obj = JSON.parse(json);
        console.log({ obj })
    },
    jsonParseRaw: (args) => {
        var json = Blazor.platform.readStringField(args);
        const obj = JSON.parse(json);
        console.log({ obj })
    }
};

var Vector3 = function (x, y, z) {
    this.x = x;
    this.y = y;
    this.z = z;
};
Vector3.prototype.addInPlaceFromFloats = function (x, y, z) {
    this.x += x;
    this.y += y;
    this.z += z;
};