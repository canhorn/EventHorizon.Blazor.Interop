(function () {
    const argumentCache = new Map();
    const methodCache = new Map();
    const CHARS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".split("");
    const guid = () => {
        var chars = CHARS,
            uuid = new Array(36),
            rnd = 0,
            r;
        for (var i = 0; i < 36; i++) {
            if (i === 8 || i === 13 || i === 18 || i === 23) {
                uuid[i] = "-";
            } else if (i === 14) {
                uuid[i] = "4";
            } else {
                if (rnd <= 0x02) { rnd = (0x2000000 + Math.random() * 0x1000000) | 0; }
                r = rnd & 0xf;
                rnd = rnd >> 4;
                uuid[i] = chars[i === 19 ? (r & 0x3) | 0x8 : r];
            }
        }
        return uuid.join("");
    }
    const cacheKey = "___guid";
    window["blazorInterop"] = {
        /**
         * This will call a function on a cached object.
         * args = Tuple<string, string>
         *  Tuble[0] = Root - Property Name from window or Cached Entity GUID
         *  Tuble[1] = Identitifer - Property to get from Root
         **/
        get: function (args) {
            try {
                var root = Blazor.platform.readStringField(args);
                var identifier = Blazor.platform.readStringField(args, 4);
                identifier = identifier.split(".");
                let value = window[root];
                if (argumentCache.has(root)) {
                    value = argumentCache.get(root);
                }
                for (var i = 0; i < identifier.length; i++) {
                    value = value[identifier[i]];
                }

                if (typeof (value) === "number") {
                    return value;
                }
                return BINDING.js_to_mono_obj(value);
            } catch (ex) {
                console.log("error", ex);
            }
        },
        /**
         * This will call a function on a cached object.
         * arguments[0] = Cached Entity
         * arguments[1] = Property Key
         * arguments[2] = Property Value
         **/
        set: function () {
            try {
                var cachedObj = arguments[0];
                var prop = arguments[1];
                var propValue = arguments[2];

                if (argumentCache.has(cachedObj[cacheKey])) {
                    var cachedObj = argumentCache.get(cachedObj[cacheKey]);
                    if (cachedObj[prop]) {
                        if (propValue[cacheKey] && argumentCache.has(propValue[cacheKey])) {
                            propValue = argumentCache.get(propValue[cacheKey]);
                        } else {
                            console.log("not_found", ex);
                        }
                        cachedObj[prop] = propValue;
                    } else {
                        console.log("not_found", ex);
                    }
                } else {
                    console.log("not_found", ex);
                }
            } catch (ex) {
                console.log("error", ex);
            }
        },
        /**
         * This will call a function on a cached object.
         * arguments[0] = Cached Entity
         * arguments[1] = property key
         * arguments[2...n] = as args to property key
         **/
        call: function () {
            try {
                var cachedObj = arguments[0];
                var prop = arguments[1];
                var args = [];
                for (var i = 2; i < arguments.length; i++) {
                    var arg = arguments[i];
                    if (arg[cacheKey] && argumentCache.has(arg[cacheKey])) {
                        args.push(argumentCache.get(arg[cacheKey]));
                    } else {
                        args.push(arg);
                    }
                }

                if (argumentCache.has(cachedObj[cacheKey])) {
                    var cachedObj = argumentCache.get(cachedObj[cacheKey]);
                    if (cachedObj[prop]) {
                        cachedObj[prop](...args);
                    }
                }
            } catch (ex) {
                console.log("error", ex);
                throw { message: "invalid_call", code: "invalid_call" };
            }
        },
        /**
         * This will "new" the passed in identifier.
         * arguments[0] = Identifier
         * arguments[1...n] = Contructor Arguments
         **/
        new: function () {
            try {
                var identifier = arguments[0];
                var args = [];
                var createNew = window[identifier[0]];
                for (var i = 1; i < arguments.length; i++) {
                    var arg = arguments[i];
                    if (arg[cacheKey] && argumentCache.has(arg[cacheKey])) {
                        args.push(argumentCache.get(arg[cacheKey]));
                    } else {
                        args.push(arg);
                    }
                }
                for (var i = 1; i < identifier.length; i++) {
                    createNew = createNew[identifier[i]];
                }
                var newObject = new createNew(...args);
                newObject[cacheKey] = guid();
                argumentCache.set(newObject[cacheKey], newObject);
                return {
                    [cacheKey]: newObject[cacheKey]
                };
            } catch (ex) {
                console.log("error", ex);
            }
            throw { code: "invalid_call" };
        },
        /**
         * This will call a through an identifier's a function from window as the root.
         * arguments[0] = Identifier
         * arguments[1...n] = Function Arguments
         **/
        func: function () {
            try {
                var identifier = arguments[0];
                var args = [];
                var createNew = window[identifier[0]];
                for (var i = 1; i < arguments.length; i++) {
                    var arg = arguments[i];
                    if (arg[cacheKey] && argumentCache.has(arg[cacheKey])) {
                        args.push(argumentCache.get(arg[cacheKey]));
                    } else {
                        args.push(arg);
                    }
                }
                var context = window;
                for (var i = 1; i < identifier.length; i++) {
                    context = createNew;
                    createNew = createNew[identifier[i]];
                }
                var newObject = createNew.call(context, ...args);
                if (newObject) {
                    newObject[cacheKey] = guid();
                    argumentCache.set(newObject[cacheKey], newObject);
                    return {
                        [cacheKey]: newObject[cacheKey]
                    };
                }
            } catch (ex) {
                console.log("error", ex);
            }
            return {};
        },
        /**
         * This will create a new function scoped string with arguments and services passed to it.
         **/
        runScript: (methodRunner) => {
            let script = methodCache.get(methodRunner.methodName);
            if (!script) {
                script = new Function(
                    "$services",
                    "$args",
                    methodRunner.script
                );
                methodCache.set(
                    methodRunner.methodName,
                    script
                );
            }
            script({
                argumentCache,
            }, methodRunner.args);
        },
    };
})();