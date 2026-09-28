using System;

namespace ExpenseTracker.Models.DTOs;

public class ExpenseDTO
{
    public string Description {get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public DateTime Date { get; set; }
    
    public string Category { get; set; } = string.Empty;

    public string PaymentMethod { get; set; } = string.Empty;


}