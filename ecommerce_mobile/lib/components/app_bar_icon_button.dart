import 'package:flutter/material.dart';

class AppBarIconButton extends StatelessWidget {
  final Widget navigatedPage;
  final Icon icon ;
  const AppBarIconButton({
    super.key,
    required this.navigatedPage, required this.icon,
  });

  @override
  Widget build(BuildContext context) {
    return IconButton(
      onPressed: () {
        Navigator.push(
          context,
          MaterialPageRoute(
            builder: (context) {
              return navigatedPage;
            },
          ),
        );
      },
      icon: icon,
    );
  }
}
