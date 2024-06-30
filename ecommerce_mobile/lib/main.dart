import 'dart:math';

import 'package:ecommerce_mobile/components/text_field.dart';
import 'package:ecommerce_mobile/pages/cart.dart';
import 'package:ecommerce_mobile/pages/log_in.dart';
import 'package:ecommerce_mobile/pages/sign_up.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(ecommerce());
}

class ecommerce extends StatelessWidget {
  const ecommerce({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      home: Sign_up(),
    );
  }
}
