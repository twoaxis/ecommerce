import 'package:ecommerce_mobile/components/app_bar_icon_button.dart';
import 'package:ecommerce_mobile/pages/account_page.dart';
import 'package:ecommerce_mobile/pages/cart_page.dart';
import 'package:ecommerce_mobile/pages/settings_page.dart';
import 'package:flutter/material.dart';

class CustomScaffold extends StatelessWidget {
  final Widget? body;
  const CustomScaffold({super.key, this.body});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        toolbarHeight: 80,
        title: SearchBar(
          leading: Icon(Icons.search_rounded),
          hintText: 'search here',
        ),
        actions: [
          AppBarIconButton(
            navigatedPage: AccountPage(),
            icon: Icon(Icons.account_circle_rounded, size: 32),
          ),
          AppBarIconButton(
            navigatedPage: SettingsPage(),
            icon: Icon(
              Icons.settings,
              size: 32,
            ),
          ),
          AppBarIconButton(
            navigatedPage: CartPage(),
            icon: Icon(
              Icons.shopping_cart_rounded,
              size: 32,
            ),
          ),
        ],
      ),
      body: body,
    );
  }
}
