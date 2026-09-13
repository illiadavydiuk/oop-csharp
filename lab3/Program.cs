using lab3;

PaymentProcessor processor = new PaymentProcessor();

processor.ProcessPayment(new BankAccount(), 100);
processor.ProcessPayment(new PayoneerAccount(), 200);
processor.ProcessPayment(new WiseAccount(), 300);