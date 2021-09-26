window.ShowToastr = (type, message) => {
    if (type === "sukses") {
        toastr.success(message, "Operasi berhasil");
    }
    if (type === "gagal") {
        toastr.error(message, "Operasi gagal");
    }
}

window.ShowSwal = (type, message) => {
    if (type === "sukses") {
        Swal.fire(
            'Notifikasi Sukses',
            message,
            'success'
        )
    }
    if (type === "gagal") {
        Swal.fire(
            'Notifikasi Gagal',
            message,
            'error'
        )
    }
}