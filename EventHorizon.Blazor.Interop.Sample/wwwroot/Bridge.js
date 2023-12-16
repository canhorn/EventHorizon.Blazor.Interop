window.bridge = {
    send: (event) => {
        console.log("send: ", { event });
    },
    jsonParse: (json) => {
        const obj = JSON.parse(json);
        console.log({ obj });
    },
    jsonParseRaw: (args) => {
        var json = args;
        const obj = JSON.parse(json);
        console.log({ obj });
    }
};

var TestClass = function () {
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

const literalCallbackActions = [];
window["LiteralCallback"] = {
    register: (options /* { actionHandler: () => void; } */) => {
        literalCallbackActions.push(options.actionHandler);
    },
    trigger: (times) => {
        for (var i = 0; i < times; i++) {
            literalCallbackActions.forEach(
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
window["setPrimitive"] = {
    setInt: 999,
    setString: "string",
    setBool: true,
    setNumber: 999.99,
};

window["getArray"] = {
    result: ["string1", "string2"],
};

// Class
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

window["funcClass"] = {
    func: () => ({
        X: "X",
        Y: "Y",
        Z: "Z",
    }),
};

window["funcArray"] = {
    func: () => [
        "X1",
        "Y1",
        "Z1",
    ],
};

window["funcArrayClass"] = {
    func: () => [{
        X: "X1",
        Y: "Y1",
        Z: "Z1",
    }, {
        X: "X2",
        Y: "Y2",
        Z: "Z2",
    }],
};