import 'package:flutter/material.dart';

class CustomTextField extends StatelessWidget {
  CustomTextField.CustomTextField(
      {required this.textInputType,
      required this.hint_text,
      required this.isPassword,
      required this.controller});

  TextInputType textInputType;
  bool isPassword;
  String hint_text;
  TextEditingController controller;
  @override
  Widget build(BuildContext context) {
    return TextField(
      controller: controller,
      keyboardType: textInputType,
      obscureText: isPassword,
      decoration: InputDecoration(
        hintText: hint_text,
        enabledBorder:
            OutlineInputBorder(borderSide: Divider.createBorderSide(context)),
        focusedBorder: OutlineInputBorder(
          borderSide: BorderSide(),
        ),
        filled: true,
        contentPadding: const EdgeInsets.all(8),
      ),
    );
  }
}
