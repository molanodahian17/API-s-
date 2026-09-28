using System;
using ExpenseTracker.Models;
using ExpenseTracker.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers;

[Route("api/[controller]")]
[ApiController]


public class ExpensesController : ControllerBase

{
    private static readonly List<Expense> _expenses = [];

    [HttpPost]
    public IActionResult RegisterExpense([FromBody] ExpenseDTO expense)
    {
        Expense newExpense = new Expense
        {
            Id = Guid.NewGuid(),
            Description = expense.Description,
            Amount = expense.Amount,
            Date = expense.Date,
            Category = expense.Category,
            PaymentMethod = expense.PaymentMethod,
        };

        _expenses.Add(newExpense);

        return CreatedAtAction(nameof(RegisterExpense), new { id = newExpense.Id }, newExpense);
    }

    [HttpGet]
    public IActionResult ListExpense(
    string? description,
    string? category,
    string? paymentMethod)
    {
        var expenses = _expenses.AsEnumerable();

        if (!string.IsNullOrEmpty(description))
        {
            expenses = expenses.Where(e =>
                e.Description.Contains(description, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(category))
        {
            expenses = expenses.Where(e =>
                e.Category == category);
        }

        if (!string.IsNullOrEmpty(paymentMethod))
        {
            expenses = expenses.Where(e =>
                e.PaymentMethod == paymentMethod);
        }

        return Ok(expenses);
    }


    [HttpPut("{id}")]
    public IActionResult UpdateExpense(Guid id, Expense updatedExpense)
    {
        var ExistentExpense = _expenses.FirstOrDefault(e => e.Id == id);

        if (ExistentExpense == null)
        {
            return NotFound($"Not Found This Expense by ID: {id}");
        }


        ExistentExpense.Description = updatedExpense.Description;
        ExistentExpense.Amount = updatedExpense.Amount;
        ExistentExpense.Date = updatedExpense.Date; 
        ExistentExpense.Category = updatedExpense.Category;
        ExistentExpense.PaymentMethod = updatedExpense.PaymentMethod;

        return NoContent();

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteExpense(Guid id)
    {
        var ExistentExpense = _expenses.FirstOrDefault(e => e.Id == id);


        if (ExistentExpense == null)
        {
            return NotFound($"Not Found This Expense by ID: {id}");
        }

        _expenses.Remove(ExistentExpense);

        return NoContent();

    }

}