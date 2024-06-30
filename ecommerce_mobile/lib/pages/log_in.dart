import 'package:ecommerce_mobile/components/text_field.dart';
import 'package:ecommerce_mobile/pages/field_label.dart';
import 'package:ecommerce_mobile/pages/sign_up.dart';
import 'package:flutter/material.dart';

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
                error.length > 0
                    ? Column(
                        children: [
                          SizedBox(
                            height: 15,
                          ),
                          Container(
                            padding: EdgeInsets.symmetric(
                                vertical: 10, horizontal: 20),
                            decoration: BoxDecoration(
                                borderRadius: BorderRadius.circular(8.0),
                                color: Color.fromARGB(30, 255, 0, 0),
                                border:
                                    Border.all(width: 2.0, color: Colors.red)),
                            child: Text(
                              error,
                              style: TextStyle(
                                fontSize: 20,
                                color: Colors.red,
                              ),
                            ),
                          )
                        ],
                      )
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
                    if (emailController.text.isEmpty ||
                        passwordController.text.isEmpty) {
                      setState(() {
                        error = "Please fill in all fields";
                      });
                    } else {
                      // TODO: Authentication Request
                    }
                  },
                  child: Text("Log in",
                      style: TextStyle(
                        fontFamily: "Roboto",
                        fontSize: 20,
                        color: Colors.white,
                      )),
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
                    Navigator.pushReplacement(context,
                        MaterialPageRoute(builder: (context) => Sign_up()));
                  },
                  child: Text("Sign up",
                      style: TextStyle(
                        fontFamily: "Roboto",
                        fontSize: 20,
                        color: Colors.black,
                      )),
                  style: ElevatedButton.styleFrom(
                    backgroundColor: Colors.white,
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(16),
                        side: BorderSide(color: Colors.black)),
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
