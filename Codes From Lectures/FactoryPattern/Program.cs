ProductFactory productFactory = new ProductFactory();
IProduct prod1 = productFactory.GetProduct(1);
IProduct prod2 = productFactory.GetProduct(2);
IProduct prod3 = productFactory.GetProduct(3);

prod1.GetData();
prod2.GetData();
prod3.GetData();

Apple apple = new Apple();
Micro micro = new Micro();
Google google = new Google();

apple.GetData();
micro.GetData();
google.GetData();