import 'package:ecommerce_mobile/components/custom_scaffold.dart';
import 'package:ecommerce_mobile/components/text_field.dart';
import 'package:ecommerce_mobile/components/field_label.dart';
import 'package:ecommerce_mobile/pages/sign_up.dart';
import 'package:ecommerce_mobile/style.dart';
import 'package:flutter/material.dart';
import 'package:ecommerce_mobile/components/error.dart' as ErrorComponent;

class LogIn extends StatefulWidget {
  LogIn({super.key});

  @override
  State<LogIn> createState() => _LogInState();
}

class _LogInState extends State<LogIn> {
  TextEditingController emailController = TextEditingController();
  TextEditingController passwordController = TextEditingController();

  String error = "";

  @override
  Widget build(BuildContext context) {
    return CustomScaffold(
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
                error.length > 0
                    ? ErrorComponent.ErrorWidget(content: error)
                    : SizedBox(height: 0),
                SizedBox(
                  height: 33.0,
                ),
                FieldLabel(text: "E-mail:"),
                CustomTextField.CustomTextField(
                  controller: emailController,
                  textInputType: TextInputType.emailAddress,
                  hint_text: 'johnsmith@twoaxis.xyz',
                  isPassword: false,
                ),
                SizedBox(
                  height: 28.0,
                ),
                FieldLabel(text: 'Password:'),
                CustomTextField.CustomTextField(
                  controller: passwordController,
                  textInputType: TextInputType.emailAddress,
                  hint_text: '••••••••••••••',
                  isPassword: true,
                ),
                SizedBox(
                  height: 33.0,
                ),
                ElevatedButton(
                  onPressed: () {
                    setState(
                      () {
                        error = "";
                      },
                    );
                    if (emailController.text.isEmpty ||
                        passwordController.text.isEmpty) {
                      setState(
                        () {
                          error = "Please fill in all fields";
                        },
                      );
                    }
                  },
                  child: Text(
                    "Log in",
                    style: TextStyle(
                      fontFamily: "Roboto",
                      fontSize: 20,
                      color: Colors.white,
                    ),
                  ),
                  style: ElevatedButton.styleFrom(
                    backgroundColor: primaryColor,
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
