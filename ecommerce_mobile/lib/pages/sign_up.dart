import 'package:ecommerce_mobile/components/text_field.dart';
import 'package:ecommerce_mobile/pages/field_label.dart';
import 'package:ecommerce_mobile/pages/log_in.dart';
import 'package:flutter/material.dart';

class Sign_up extends StatelessWidget {
  const Sign_up({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: Center(
        child: Padding(
          padding: const EdgeInsets.all(33.0),
          child: SingleChildScrollView(
            child: Column(
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
                  "Create an Account",
                  style: TextStyle(
                    fontFamily: "Roboto",
                    fontSize: 30,
                  ),
                ),
                SizedBox(
                  height: 28.0,
                ),
                FieldLabel(text: "E-mail:"),
                SizedBox(
                  height: 6.0,
                ),
                CustomTextField.CustomTextField(
                  textInputType: TextInputType.emailAddress,
                  hint_text: 'johnsmith@twoaxis.com',
                  isPassword: false,
                ),
                SizedBox(
                  height: 20.0,
                ),
                FieldLabel(text: 'Password:'),
                CustomTextField.CustomTextField(
                  textInputType: TextInputType.emailAddress,
                  hint_text: 'Enter Your Password',
                  isPassword: true,
                ),
                SizedBox(
                  height: 20.0,
                ),
                FieldLabel(text: 'Repeat Password:'),
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
                  child: Text("Sign Up",
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
                        MaterialPageRoute(builder: (context) => LogIn()));
                  },
                  child: Text("Log in",
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
                  'By signing up, you agree to our terms of conditions and privacy policy',
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
