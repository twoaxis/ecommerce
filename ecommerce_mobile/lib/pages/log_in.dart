import 'package:ecommerce_mobile/components/text_field.dart';
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
                Text(
                  "Log in to your account",
                  style: TextStyle(
                    fontFamily: "Roboto",
                    fontSize: 40,
                  ),
                ),
                SizedBox(
                  height: 33.0,
                ),
                Text("E-mail:"),
                CustomTextField.CustomTextField(
                  textInputType: TextInputType.emailAddress,
                  hint_text: 'Enter Your Email',
                  isPassword: false,
                ),
                SizedBox(
                  height: 33.0,
                ),
                Text("Password:"),
                CustomTextField.CustomTextField(
                  textInputType: TextInputType.emailAddress,
                  hint_text: 'Enter Your Password',
                  isPassword: true,
                ),
                SizedBox(
                  height: 33.0,
                ),
                ElevatedButton(
                  onPressed: () {},
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
                SizedBox(
                  height: 33.0,
                ),
                GestureDetector(
                  onTap: () {
                    Navigator.pop(context);
                  },
                  child: Text(
                    'Not a member? Sign up',
                    style: TextStyle(
                      fontFamily: "Roboto",
                      fontSize: 20,
                      color: Colors.black38,
                    ),
                  ),
                )
              ],
            ),
          ),
        ),
      ),
    );
  }
}
