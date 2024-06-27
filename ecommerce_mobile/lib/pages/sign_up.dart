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
            mainAxisSize: MainAxisSize.min,
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
              CustomTextField.CustomTextField(
                text: "E-mail",
                textInputType: TextInputType.emailAddress,
                hint_text: 'Enter Your Email',
                isPassword: false,
              ),
              SizedBox(
                height: 33.0,
              ),
              CustomTextField.CustomTextField(
                text: "Password",
                textInputType: TextInputType.emailAddress,
                hint_text: 'Enter Your Password',
                isPassword: true,
              ),
              SizedBox(
                height: 33.0,
              ),
              CustomTextField.CustomTextField(
                text: "Confirm Password",
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
            ],
          ),
        ),
      ),
    );
  }
}
