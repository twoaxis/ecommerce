import 'package:flutter/material.dart';

class ErrorWidget extends StatelessWidget {
  ErrorWidget({required this.content});

  String content;
  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        SizedBox(
          height: 15,
        ),
        Container(
          padding: EdgeInsets.symmetric(vertical: 10, horizontal: 20),
          decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(8.0),
              color: Color.fromARGB(30, 255, 0, 0),
              border: Border.all(width: 2.0, color: Colors.red)),
          child: Text(
            content,
            style: TextStyle(
              fontSize: 20,
              color: Colors.red,
            ),
          ),
        )
      ],
    );
  }
}
