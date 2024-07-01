import 'package:flutter/material.dart';

class Stars extends StatelessWidget {
  final int stars;
  const Stars({super.key, required this.stars});
  colorStars(int stars) {
    List<Icon> starsIcons = [];
    for (int i = 0; i < stars; i++) {
      starsIcons.add(
        Icon(
          Icons.star_rate_rounded,
          color: Colors.yellow[700],
          size: 40,
        ),
      );
    }
    for (int i = 0; i < 5 - stars; i++) {
      starsIcons.add(
        Icon(
          Icons.star_rate_rounded,
          color: Colors.grey[600],
          size: 40,
        ),
      );
    }
    return starsIcons;
  }

  @override
  Widget build(BuildContext context) {
    return Row(
      children: colorStars(stars),
    );
  }
}
