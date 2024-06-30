class Product {
  String name;
  String? description;
  String price;
  String? image;
  int quantity;
  Product.add(
      {required this.name,
      this.description,
      required this.price,
      this.image,
      required this.quantity});
}
