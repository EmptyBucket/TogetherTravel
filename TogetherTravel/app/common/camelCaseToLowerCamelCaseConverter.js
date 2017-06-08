function CamelCaseToLowerCamelCaseConverter() {
    
}

CamelCaseToLowerCamelCaseConverter.convert = function(obj) {
    const keys = Object.keys(obj);
    const result = {};
    for (let key of keys)
        result[key.slice(0, 1).toLowerCase() + key.slice(1)] = typeof obj[key] === "object"
            ? CamelCaseToLowerCamelCaseConverter.convert(obj[key])
            : obj[key];
    return result;
};

export default CamelCaseToLowerCamelCaseConverter;