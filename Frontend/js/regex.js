function validateControlNumber(control) {
    var expreg = new RegExp(/[AaBbCcDdEeGgIiMmSsTt][0-9]{2}(120)[0-9]{3}$/g);
    return expreg.test(control);
}

function validatePassword(password) {
    var expreg = new RegExp(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*])[0-9a-zA-Z!@#$%^&*]{8,}$/g);
    return expreg.test(password);
}

/* Esto no sirve del todo */
function validateName(name) {
    var expreg = new RegExp(/^[ÁÉÍÓÚÑA-Z][a-záéíóúñ]+(\s+[ÁÉÍÓÚÑA-Z]?[a-záéíóúñ]+)*$/g);
    return expreg.test(name);
}

function validateEmail(email) {
    var expreg = new RegExp(/[A-Z0-9._%+-]+@[A-Z0-9.-]+.[A-Z]{2,4}/gi);
    return expreg.test(email);
}

function validateBoth(pass1, pass2) {
    return pass1 == pass2 ? true : false;
}