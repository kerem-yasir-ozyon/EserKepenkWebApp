var form = $("#accept-form");

form.unbind();
form.data("validator", null);
$.validator.unobtrusive.parse(form);