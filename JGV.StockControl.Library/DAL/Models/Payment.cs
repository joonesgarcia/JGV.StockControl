namespace JGV.StockControl.Library.DAL.Models;

public class Payment
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
    public PaymentType PaymentType { get; set; }
    public virtual Debt Debt { get; set; }
    public virtual int DebtId { get; set; }
}
public enum PaymentType
{
    DINHEIRO = 0,
    PIX = 1,
    CHEQUE = 2,
    CARTAO = 3,
    ESCAMBO = 4
}
