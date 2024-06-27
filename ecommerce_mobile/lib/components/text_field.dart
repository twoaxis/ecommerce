import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';

class CustomTextField extends StatelessWidget {
  CustomTextField.CustomTextField(
      {required this.text,
      required this.textInputType,
      required this.hint_text,
      required this.isPassword});
  String text;
  TextInputType textInputType;
  bool isPassword;
  String hint_text;
  @override
  Widget build(BuildContext context) {
    return TextField(
      
      keyboardType: textInputType,
      obscureText: isPassword,
      decoration: InputDecoration(
        labelText: text,
        hintText: hint_text,
        enabledBorder:
            OutlineInputBorder(borderSide: Divider.createBorderSide(context)),
        focusedBorder: OutlineInputBorder(
            borderSide: BorderSide(color: Color.fromARGB(204, 204, 204, 0))),
        filled: true,
        contentPadding: const EdgeInsets.all(8),
      ),
    );
  }
}
