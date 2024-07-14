import 'dart:convert';
import 'package:ecommerce_mobile/components/password.dart';
import 'package:ecommerce_mobile/components/text_field.dart';
import 'package:ecommerce_mobile/components/field_label.dart';
import 'package:ecommerce_mobile/exceptions/StandardException.dart';
import 'package:ecommerce_mobile/pages/log_in.dart';
import 'package:ecommerce_mobile/components/error.dart' as ErrorComponent;
import 'package:ecommerce_mobile/style.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

Future<void> Signup(emailController, passwordController, nameController,
    phoneController) async {
  final response = await http.post(
    Uri.http("10.0.2.2:5000", "/api/Account/register"),
    headers: <String, String>{'Content-Type': 'application/json'},
    body: jsonEncode(<String, dynamic>{
      'email': emailController.text,
      'password': passwordController.text,
      'displayName': nameController.text,
      'phoneNumber': phoneController.text
    }),
  );

  final responseData = jsonDecode(response.body);
  if (response.statusCode != 200) {
    throw StandardException(responseData["errors"][0]);
  }
}

class Sign_up extends StatefulWidget {
  const Sign_up({super.key});

  @override
  State<Sign_up> createState() => _Sign_upState();
}

class _Sign_upState extends State<Sign_up> {
  TextEditingController emailController = TextEditingController();
  TextEditingController passwordController = TextEditingController();
  TextEditingController repeatPasswordController = TextEditingController();
  TextEditingController nameController = TextEditingController();
  TextEditingController phoneController = TextEditingController();

  String error = "";
  bool IsPasswordShown = false;

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
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
                  error.length > 0
                      ? ErrorComponent.ErrorWidget(content: error)
                      : SizedBox(height: 0),
                  SizedBox(
                    height: 28.0,
                  ),
                  FieldLabel(text: 'Display Name:'),
                  SizedBox(
                    height: 6.0,
                  ),
                  CustomTextField.CustomTextField(
                      textInputType: TextInputType.name,
                      hint_text: 'Salint Aldahtory',
                      isPassword: false,
                      controller: nameController),
                  SizedBox(
                    height: 20.0,
                  ),
                  FieldLabel(text: 'Phone Number:'),
                  SizedBox(
                    height: 6.0,
                  ),
                  CustomTextField.CustomTextField(
                      textInputType: TextInputType.phone,
                      hint_text: '01110796304',
                      isPassword: false,
                      controller: phoneController),
                  SizedBox(
                    height: 15.0,
                  ),
                  FieldLabel(text: "E-mail:"),
                  SizedBox(
                    height: 6.0,
                  ),
                  CustomTextField.CustomTextField(
                    controller: emailController,
                    textInputType: TextInputType.emailAddress,
                    hint_text: 'johnsmith@twoaxis.xyz',
                    isPassword: false,
                  ),
                  SizedBox(
                    height: 20.0,
                  ),
                  FieldLabel(text: 'Password:'),
                  CustomTextField.CustomTextField(
                      controller: passwordController,
                      textInputType: TextInputType.emailAddress,
                      hint_text: '••••••••••••••',
                      isPassword: !IsPasswordShown,
                      icon: IconButton(
                          onPressed: () {
                            setState(() {
                              IsPasswordShown = !IsPasswordShown;
                            });
                          },
                          icon: Icon(IsPasswordShown
                              ? Icons.visibility
                              : Icons.visibility_off))),
                  SizedBox(
                    height: 20.0,
                  ),
                  FieldLabel(text: 'Repeat Password:'),
                  CustomTextField.CustomTextField(
                      controller: repeatPasswordController,
                      textInputType: TextInputType.emailAddress,
                      hint_text: '••••••••••••••',
                      isPassword: !IsPasswordShown,
                      icon: IconButton(
                          onPressed: () {
                            setState(() {
                              IsPasswordShown = !IsPasswordShown;
                            });
                          },
                          icon: Icon(IsPasswordShown
                              ? Icons.visibility
                              : Icons.visibility_off))),
                  SizedBox(
                    height: 33.0,
                  ),
                  ElevatedButton(
                    onPressed: () async {
                      setState(
                        () {
                          error = "";
                        },
                      );
                      if (emailController.text.isEmpty ||
                          passwordController.text.isEmpty ||
                          repeatPasswordController.text.isEmpty ||
                          nameController.text.isEmpty ||
                          passwordController.text.isEmpty) {
                        setState(
                          () {
                            error = "Please fill in all fields";
                          },
                        );
                      } else if (passwordController.text !=
                          repeatPasswordController.text) {
                        setState(
                          () {
                            error = "Passwords do not match";
                          },
                        );
                      } else {
                        try {
                          await Signup(emailController, passwordController,
                              nameController, phoneController);
                          print("Success");
                        } catch (err) {
                          setState(() {
                            error = err.toString();
                          });
                        }
                      }
                    },
                    child: Text("Sign Up",
                        style: TextStyle(
                          fontFamily: "Roboto",
                          fontSize: 20,
                          color: Colors.white,
                        )),
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
                          builder: (context) => LogIn(),
                        ),
                      );
                    },
                    child: Text(
                      "Log in",
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
      ),
    );
  }
}
