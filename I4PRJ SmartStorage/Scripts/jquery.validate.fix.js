$.validator.methods.range = function (value, element, param) {
  var globalizedValue = value.replace(",", ".");
  return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
}

$.validator.methods.number = function (value, element) {
  return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
}

$.validator.setDefaults({
  errorClass: "has-error",
  validClass: "has-success",
  highlight: function (element) {
    jQuery(element).closest('.form-group').addClass('has-error').removeClass('has-success');
  },
  unhighlight: function (element) {
    jQuery(element).closest('.form-group').removeClass('has-error').addClass('has-success');
  }
});