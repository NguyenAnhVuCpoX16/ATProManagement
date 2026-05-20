window.swalService = {

    success: async function (title, message) {

        await Swal.fire({
            icon: 'success',
            title: title,
            text: message,
            confirmButtonColor: '#ff9800'
        });

    },

    error: async function (title, message) {

        await Swal.fire({
            icon: 'error',
            title: title,
            text: message,
            confirmButtonColor: '#ef4444'
        });

    },

    warning: async function (title, message) {

        await Swal.fire({
            icon: 'warning',
            title: title,
            text: message,
            confirmButtonColor: '#f59e0b'
        });

    },

    loading: function (title) {
        Swal.fire({
            title: title,
            allowOutsideClick: false,
            showConfirmButton: false,

            didOpen: () => {
                Swal.showLoading();
            }
        });

    },

    close: function () {
        Swal.close();
    },

    confirm: async function (title, message) {

        const result = await Swal.fire({
            title: title,
            text: message,
            icon: 'question',
            showCancelButton: true,
            confirmButtonColor: '#ff9800',
            cancelButtonColor: '#9ca3af',
            confirmButtonText: 'Confirm',
            cancelButtonText: 'Cancel'
        });

        return result.isConfirmed;
    },

    toast: async function (message) {

        await Swal.fire({
            toast: true,
            position: 'top-end',
            icon: 'success',
            title: message,
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true
        });

    }

};