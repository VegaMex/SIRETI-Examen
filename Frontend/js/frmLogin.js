window.addEventListener('load', function () {
    var button = document.getElementById('btnIniciarSesion');
    button.addEventListener('click', function (event) {
        var txtCorreo = document.getElementById('txtCorreo');
        var txtContra = document.getElementById('txtContra');

        try {
            txtCorreo.classList.remove('is-valid', 'is-invalid');
            txtContra.classList.remove('is-valid', 'is-invalid');

            var correo = txtCorreo.value.trim();
            var contra = txtContra.value.trim();

            var v1 = validateEmail(correo) && correo != "" ? true : false;
            var v2 = validatePassword(contra) && contra != "" ? true : false;

            if (!(v1 && v2)) {
                if (v1) {
                    txtCorreo.classList.add('is-valid');
                } else {
                    txtCorreo.classList.add('is-invalid');
                }
                if (v2) {
                    txtContra.classList.add('is-valid');
                } else {
                    txtContra.classList.add('is-invalid');
                }
                event.preventDefault();
            }

        } catch (e) {
            event.preventDefault();
        }
    });
});