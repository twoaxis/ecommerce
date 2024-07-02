import 'package:ecommerce_mobile/models/product.dart';
import 'package:ecommerce_mobile/style.dart';
import 'package:flutter/material.dart';

class CartPage extends StatefulWidget {
  const CartPage({super.key});

  @override
  State<CartPage> createState() => _CartPageState();
}

class _CartPageState extends State<CartPage> {
  List<Product> products = [Product(name: "Product 1", price: 2, quantity: 1)];
  void incrementalQuantity(int index) {
    setState(() {
      products[index].quantity++;
    });
  }

  void decrementQuantity(int index) {
    setState(() {
      if (products[index].quantity < 1) {
        products[index].quantity = 0;
      } else {
        products[index].quantity--;
      }
    });
  }

  double GetTotal() {
    double total = 0.0;
    for (int i = 0; i < products.length; i++) {
      total += products[i].quantity * products[i].price;
    }
    return total;
  }

  void showCheckoutDialog() {
    showDialog(
        context: context,
        builder: (context) {
          return AlertDialog(
            title: Text('Checkout'),
            content: Text('Hurray! You have purchased the products'),
            actions: [
              TextButton(
                  onPressed: () {
                    Navigator.of(context).pop();
                  },
                  child: Text('Ok'))
            ],
          );
        });
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        backgroundColor: Colors.white,
        body: Padding(
          padding: EdgeInsets.all(12),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                "CART",
                style: TextStyle(
                    fontFamily: 'Roboto',
                    fontSize: 26,
                    fontWeight: FontWeight.bold),
              ),
              Expanded(
                child: ListView.builder(
                  itemCount: products.length,
                  itemBuilder: (context, index) {
                    return Dismissible(
                      key: Key(products[index].name),
                      direction: DismissDirection.endToStart,
                      onDismissed: (direction) => {
                        setState(() {
                          products.removeAt(index);
                        })
                      },
                      background: Container(
                        color: primaryColor,
                        child: Icon(
                          Icons.cancel,
                          color: Colors.white,
                        ),
                        alignment: Alignment.centerRight,
                        padding: EdgeInsets.only(right: 16.0),
                      ),
                      child: Container(
                        margin: EdgeInsets.all(10.0),
                        padding: EdgeInsets.only(right: 16.0),
                        decoration: BoxDecoration(
                            color: Colors.white,
                            borderRadius: BorderRadius.circular(8)),
                        child: Row(
                          children: [
                            Image.asset(
                              'asset/image/place_holder.png',
                              height: 50,
                              width: 50,
                            ),
                            SizedBox(
                              width: 15,
                            ),
                            Column(
                              children: [
                                Text(
                                  products[index].name,
                                  style: TextStyle(
                                      fontFamily: 'Roboto', fontSize: 18.0),
                                ),
                                Text(
                                  '\$${products[index].price}',
                                  style: TextStyle(
                                      fontFamily: 'Roboto',
                                      fontSize: 16.0,
                                      color: Colors.grey),
                                )
                              ],
                            ),
                            Spacer(),
                            Row(
                              children: [
                                IconButton(
                                    onPressed: () {
                                      decrementQuantity(index);
                                    },
                                    icon: Icon(Icons.remove)),
                                Text(
                                  products[index].quantity.toString(),
                                  style: TextStyle(
                                    fontSize: 18,
                                  ),
                                ),
                                IconButton(
                                  onPressed: () {
                                    incrementalQuantity(index);
                                  },
                                  icon: Icon(Icons.add),
                                )
                              ],
                            )
                          ],
                        ),
                      ),
                    );
                  },
                ),
              ),
              Divider(),
              Padding(
                padding: EdgeInsets.all(10.0),
                child: Row(
                  children: [
                    Text(
                      'Cart Total: ',
                      style: TextStyle(fontFamily: 'Roboto', fontSize: 18.0),
                    ),
                    SizedBox(
                      width: 50.0,
                    ),
                    Text(
                      '\$${GetTotal().toStringAsFixed(2)}',
                      style: TextStyle(
                          fontSize: 24.0,
                          fontFamily: 'Roboto',
                          fontWeight: FontWeight.bold),
                    )
                  ],
                ),
              ),
              Divider(),
              Padding(
                padding: EdgeInsets.all(8.0),
                child: Row(
                  children: [
                    Expanded(
                      child: ElevatedButton(
                        style: ElevatedButton.styleFrom(
                            backgroundColor: primaryColor),
                        onPressed: () {
                          showCheckoutDialog();
                        },
                        child: Text(
                          'Proceed to Checkout',
                          style: TextStyle(color: Colors.white),
                        ),
                      ),
                    )
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
