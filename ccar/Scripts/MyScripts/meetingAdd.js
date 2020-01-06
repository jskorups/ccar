function SubmitForm(form) {
    //$.validator.unobtrusive.parse(form);
    //if ($(form).valid()) {
        $.ajax({
            type: "POST",
            url: form.action,
            data: $(form).serialize(),
            success: function (data) {
                //if (data.success) {
                Popup.dialog('close');
                dataTable.ajax.reload();

                $.notify(data.message, {
                    globalPosition: "top center",
                    className: "success"

                });

                //}
            }
        });
    //}
    return false;
}