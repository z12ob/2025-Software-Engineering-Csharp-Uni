public interface IPayment 
{ 
    void Pay(); 
} 
 
public class CardPayment : IPayment 
{ 
    public void Pay() 
    { 
        Console.WriteLine("Card payment"); 
    } 
} 
 
public class PaypalPayment : IPayment 
{ 
    public void Pay() 
    { 
        Console.WriteLine("Paypal payment"); 
    } 
} 
 
public class PaymentProcessor 
{ 
    public void Process(IPayment payment) 
    { 
        payment.Pay(); 
    } 
} 
// გამოყენება:
// PaymentProcessor processor = new PaymentProcessor();
// processor.Process(new CardPayment());
// processor.Process(new PaypalPayment());
