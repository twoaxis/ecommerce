import 'package:ecommerce_mobile/components/text_field.dart';
import 'package:ecommerce_mobile/pages/field_label.dart';
import 'package:ecommerce_mobile/pages/sign_up.dart';
import 'package:flutter/material.dart';

class LogIn extends StatelessWidget {
  const LogIn({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: Center(
        child: Padding(
          padding: const EdgeInsets.all(33.0),
          child: SingleChildScrollView(
            child: Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                Image.asset(
                  "asset/image/logo.png",
                  width: MediaQuery.of(context).size.width -
                      MediaQuery.of(context).size.width * .25,
                ),
                SizedBox(
                  height: 20,
                ),
                Text(
                  "Log in to your account",
                  style: TextStyle(
                    fontFamily: "Roboto",
                    fontSize: 30,
                  ),
                ),
                SizedBox(
                  height: 33.0,
                ),
                FieldLabel(text: "E-mail:"),
                CustomTextField.CustomTextField(
                  textInputType: TextInputType.emailAddress,
                  hint_text: 'johnsmith@twoaxis.xyz',
                  isPassword: false,
                ),
                SizedBox(
                  height: 28.0,
                ),
                FieldLabel(text: 'Password:'),
                CustomTextField.CustomTextField(
                  textInputType: TextInputType.emailAddress,
                  hint_text: '••••••••••••••',
                  isPassword: true,
                ),
                SizedBox(
                  height: 33.0,
                ),
                ElevatedButton(
                  onPressed: () {},
                  child: Text(
                    "Log in",
                    style: TextStyle(
                      fontFamily: "Roboto",
                      fontSize: 20,
                      color: Colors.white,
                    ),
                  ),
                  style: ElevatedButton.styleFrom(
                    backgroundColor: Color(0xFFa71f1f),
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(16),
                    ),
                    fixedSize: Size(double.maxFinite, 50),
                  ),
                ),
                SizedBox(
                  height: 11.0,
                ),
                ElevatedButton(
                  onPressed: () {
                    Navigator.pushReplacement(
                      context,
                      MaterialPageRoute(
                        builder: (context) => Sign_up(),
                      ),
                    );
                  },
                  child: Text(
                    "Sign up",
                    style: TextStyle(
                      fontFamily: "Roboto",
                      fontSize: 20,
                      color: Colors.black,
                    ),
                  ),
                  style: ElevatedButton.styleFrom(
                    backgroundColor: Colors.white,
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(16),
                      side: BorderSide(color: Colors.black),
                    ),
                    fixedSize: Size(double.maxFinite, 50),
                  ),
                ),
                SizedBox(
                  height: 33.0,
                ),
                Text(
                  'By logging in, you agree to our terms of conditions and privacy policy',
                  style: TextStyle(
                    fontFamily: "Roboto",
                    fontSize: 20,
                    color: Colors.black38,
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
