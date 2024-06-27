import 'package:ecommerce_mobile/components/text_field.dart';
import 'package:flutter/material.dart';

class Sign_up extends StatelessWidget {
  const Sign_up({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color.fromARGB(255, 194, 189, 189),
      body: Center(
        child: Padding(
          padding: const EdgeInsets.all(33.0),
          child: Column(
            children: [
              Image.asset("asset/image/logo.png"),
              Text(
                "Create an Account",
                style: TextStyle(fontFamily: "Roboto"),
              ),
              SizedBox(
                height: 33.0,
              ),
              CostomTextField(
                text: "E-mail",
                textInputTypee: TextInputType.emailAddress,
                hint_text: 'Enter Your Email',
                isPassword: false,
              ),
            ],
          ),
        ),
      ),
    );
  }
}
