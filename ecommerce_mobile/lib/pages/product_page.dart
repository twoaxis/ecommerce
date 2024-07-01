import 'package:ecommerce_mobile/components/custom_button.dart';
import 'package:ecommerce_mobile/components/stars.dart';
import 'package:ecommerce_mobile/models/product.dart';
import 'package:flutter/material.dart';

class ProductPage extends StatelessWidget {
  final Product product;
  const ProductPage({
    super.key,
    required this.product,
  });

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        centerTitle: true,
        title: Image.asset(
          height: 60,
          'asset/image/logo.png',
        ),
      ),
      body: Padding(
        padding: const EdgeInsets.only(left: 16.0, right: 16.0, top: 16.0),
        child: ListView(
          children: [
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Center(
                  child: ClipRRect(
                    clipBehavior: Clip.antiAlias,
                    borderRadius: BorderRadius.circular(10),
                    child: Image.asset(
                      product.image ?? "asset/image/place_holder.png",
                      width: MediaQuery.of(context).size.width -
                          MediaQuery.of(context).size.width * .25,
                      fit: BoxFit.cover,
                    ),
                  ),
                ),
                SizedBox(
                  height: 20,
                ),
                Text(
                  product.name,
                  style: TextStyle(
                    fontFamily: "Roboto",
                    fontSize: 40.0,
                    fontWeight: FontWeight.bold,
                  ),
                ),
                Stars(stars: 4),
                SizedBox(height: 20),
                CustomButton(
                  child: Text(
                    '${product.price} \$',
                    style: TextStyle(
                      fontFamily: "Roboto",
                      fontSize: 20.0,
                      fontWeight: FontWeight.bold,
                      color: Colors.white,
                    ),
                  ),
                  onPressed: () {},
                ),
                SizedBox(height: 10),
                Divider(),
                Text(
                  product.description??'No description',
                  style: TextStyle(
                    fontFamily: "Roboto",
                    fontSize: 20.0,
                  ),
                ),
                SizedBox(height: 20),
                CustomButton(
                  child: Row(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      Icon(
                        Icons.shopping_cart_rounded,
                        color: Colors.white,
                      ),
                      SizedBox(width: 10),
                      Text(
                        'Add to cart',
                        style: TextStyle(
                          fontFamily: "Roboto",
                          fontSize: 20.0,
                          color: Colors.white,
                        ),
                      ),
                    ],
                  ),
                  onPressed: () {},
                ),
              ],
            )
          ],
        ),
      ),
    );
  }
}
