class StandardException implements Exception {
  final _message;
  StandardException([this._message]);

  String toString() {
    if (_message == null) return "StandardException";
    return _message;
  }
}
