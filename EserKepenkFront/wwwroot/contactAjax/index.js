//$("#success-message").hide();

function clearMessage() {
    $("#success-message").html("");
}

function SaveContactForm() {

    var ad = $("#Name").val();
    var soyad = $("#Surname").val();
    var email = $("#Email").val();
    var phone = $("#Phone").val();
    var description = $("#Description").val();

    var dataObj = { Name: ad, Surname: soyad, Email: email, Phone: phone, Description: description };


    $.ajax({
        url: "/Home/Contact",
        method: "POST",
        data: dataObj,
        success: function (result) {
            console.log(result);

            if (result.isSuccess) {
                console.log("test");
                $("#result").html("<p>Kayıt başarıyla oluşturuldu. Kayıt No : " + result.record.id + "</p>");
            }
        },
        error: function (error, xhr) {

        },
        complete: function () {
            setTimeout(clearMessage, 2500);
        }
    })
}

