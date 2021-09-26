window.ShowToastr = (type, message) => {
    if (type === "sukses") {
        toastr.success(message, "Operasi berhasil");
    }
    if (type === "gagal") {
        toastr.error(message, "Operasi gagal");
    }
}