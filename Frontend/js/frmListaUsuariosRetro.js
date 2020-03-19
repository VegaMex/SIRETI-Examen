window.addEventListener('load', function () {
    var button = document.getElementById('content_btnNuevaContra');
    button.addEventListener('click', function (event) {
        var txtNuevaContra = document.getElementById('content_txtNuevaContra');
        var txtNuevaContraConfirm = document.getElementById('content_txtNuevaContraConfirm');

        try {
            txtNuevaContra.classList.remove('is-valid', 'is-invalid');
            txtNuevaContraConfirm.classList.remove('is-valid', 'is-invalid');

            var contra = txtNuevaContra.value.trim();
            var contraConfirm = txtNuevaContraConfirm.value.trim();

            var v1 = validatePassword(contra) && contra != "" ? true : false;
            var v2 = validatePassword(contraConfirm) && contraConfirm != "" ? true : false;
            var v3 = validateBoth(contra, contraConfirm);

            if (!(v1 && v2 && v3)) {
                if (v1) {
                    txtNuevaContra.classList.add('is-valid');
                } else {
                    txtNuevaContra.classList.add('is-invalid');
                }
                if (v2) {
                    txtNuevaContraConfirm.classList.add('is-valid');
                } else {
                    txtNuevaContraConfirm.classList.add('is-invalid');
                }
                event.preventDefault();
            }
        } catch (e) {
            event.preventDefault();
        }
    });
});