import 'package:flutter/material.dart';

class FieldLabel extends StatelessWidget {
  FieldLabel({required this.text});

  String text;
  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Text(
          text,
          style: TextStyle(fontFamily: 'Roboto', fontSize: 16.0),
        ),
      ],
    );
  }
}
