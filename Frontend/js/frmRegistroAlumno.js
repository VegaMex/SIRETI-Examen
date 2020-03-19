window.addEventListener('load', function () {
    var button = document.getElementById('btnRegistrar');
    button.addEventListener('click', function (event) {
        var txtControl = document.getElementById('txtControl');
        var txtNombre = document.getElementById('txtNombre');
        var txtPaterno = document.getElementById('txtPaterno');
        var txtMaterno = document.getElementById('txtMaterno');
        var txtCorreo = document.getElementById('txtCorreo');
        var txtContra = document.getElementById('txtContra');
        var txtContraConfirm = document.getElementById('txtContraConfirm');

        try {
            txtControl.classList.remove('is-valid', 'is-invalid');
            txtNombre.classList.remove('is-valid', 'is-invalid');
            txtPaterno.classList.remove('is-valid', 'is-invalid');
            txtMaterno.classList.remove('is-valid', 'is-invalid');
            txtCorreo.classList.remove('is-valid', 'is-invalid');
            txtContra.classList.remove('is-valid', 'is-invalid');
            txtContraConfirm.classList.remove('is-valid', 'is-invalid');

            var control = txtControl.value.trim();
            var nombre = txtNombre.value.trim();
            var paterno = txtPaterno.value.trim();
            var materno = txtMaterno.value.trim();
            var correo = txtCorreo.value.trim();
            var contra = txtContra.value.trim();
            var contraConfirm = txtContraConfirm.value.trim();

            var v1 = validateControlNumber(control) && control != "" ? true : false;
            var v2 = validateName(nombre) && nombre != "" ? true : false;
            var v3 = validateName(paterno) && paterno != "" ? true : false;
            var v4 = validateEmail(correo) && correo != "" ? true : false;
            var v5 = validatePassword(contra) && contra != "" ? true : false;
            var v6 = validatePassword(contraConfirm) && contraConfirm != "" ? true : false;
            var v7 = validateBoth(contra, contraConfirm);
            var v8 = validateName(materno) || materno == "" ? true : false;

            if (!(v1 && v2 && v3 && v4 && v5 && v6 && v7)) {
                if (v1) {
                    txtControl.classList.add('is-valid');
                } else {
                    txtControl.classList.add('is-invalid');
                }
                if (v2) {
                    txtNombre.classList.add('is-valid');
                } else {
                    txtNombre.classList.add('is-invalid');
                }
                if (v3) {
                    txtPaterno.classList.add('is-valid');
                } else {
                    txtPaterno.classList.add('is-invalid');
                }
                if (v4) {
                    txtCorreo.classList.add('is-valid');
                } else {
                    txtCorreo.classList.add('is-invalid');
                }
                if (v5) {
                    txtContra.classList.add('is-valid');
                } else {
                    txtContra.classList.add('is-invalid');
                }
                if (v6) {
                    txtContraConfirm.classList.add('is-valid');
                } else {
                    txtContraConfirm.classList.add('is-invalid');
                }
                if (v8) {
                    txtMaterno.classList.add('is-valid');
                } else {
                    txtMaterno.classList.add('is-invalid');
                }
                event.preventDefault();
            }
        } catch (e) {
            event.preventDefault();
        }
    });
});