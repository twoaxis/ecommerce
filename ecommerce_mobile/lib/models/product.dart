class Product {
  String name;
  String? description;
  int  price;
  String? image;
  int quantity;
  Product(
      {required this.name,
      this.description,
      required this.price,
      this.image,
      required this.quantity});
}
