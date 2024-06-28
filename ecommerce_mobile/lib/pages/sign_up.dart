import 'package:ecommerce_mobile/components/text_field.dart';
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
                Text(
                  "Create an Account",
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
                  hint_text: 'johnsmith@twoaxis.com',
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
                Text("Repeat Password:"),
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
                SizedBox(
                  height: 33.0,
                ),
                GestureDetector(
                  onTap: () {
                    Navigator.push(context,
                        MaterialPageRoute(builder: (context) {
                      return LogIn();
                    }));
                  },
                  child: Text(
                    'Already have an account? Log In',
                    style: TextStyle(
                      fontFamily: "Roboto",
                      fontSize: 20,
                      color: Colors.black38,
                    ),
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
