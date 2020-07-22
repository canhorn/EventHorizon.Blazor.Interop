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

window["FuncCallbackClass"] = function () {
    const callbackActions = [];

    this.register = (callbackAction) => {
        if (typeof callbackAction === "function") {
            callbackActions.push(callbackAction);
        }
    };
    this.trigger = (times) => {
        for (var i = 0; i < times; i++) {
            callbackActions.forEach(
                action => action()
            );
        }
    }
};

// Primitive 
window["getPrimitive"] = {
    result: 999,
    numberResult: 999.99,
};

window["getArray"] = {
    result: ["string1", "string2"],
};

window["getObject"] = {
    obj: {
        X: "hello",
    }
};
window["getArrayClass"] = {
    obj: [{
        X: "hello",
    }, {
        X: "world",
    }]
};