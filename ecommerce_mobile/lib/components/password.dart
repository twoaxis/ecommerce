String error = '';
bool validate_password(String password) {
  error = '';
  if (password.length < 6 &&
      !password.contains(RegExp(r'[A-Z]')) &&
      !password.contains(RegExp(r'[a-z]')) &&
      !password.contains(RegExp(r'[0-9]')) &&
      !password.contains(RegExp(r'[!@#%^&*()..?":{}|<>]'))) {
    error +=
        'Password Must be Larder than 6 charactars and have Uppercase and Lowercase and numbers and Special Characters like @#!%.\n';
  }
  return error.isEmpty;
}
