import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';

class CostomTextField extends StatelessWidget {
  CostomTextField(
      {required this.text,
      required this.textInputTypee,
      required this.hint_text,
      required this.isPassword});
  String text;
  TextInputType textInputTypee;
  bool isPassword;
  String hint_text;
  @override
  Widget build(BuildContext context) {
    return TextField(
      keyboardType: textInputTypee,
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
