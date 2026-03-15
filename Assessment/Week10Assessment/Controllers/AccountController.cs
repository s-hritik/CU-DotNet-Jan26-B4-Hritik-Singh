using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week10Assessment.Data;
using Week10Assessment.Models;

namespace Week10Assessment.Controllers;

public class AccountController : Controller
{
    private readonly AccountContext _context;

    public AccountController(AccountContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var accounts = await _context.Accounts.ToListAsync();
        return View(accounts);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Account account)
    {
        if (ModelState.IsValid)
        {
            _context.Add(account);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Account successfully created!";
            return RedirectToAction(nameof(Index));
        }
        return View(account);
    }

    public IActionResult CreateTransaction() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateTransaction(Transaction transaction)
    {
        if (ModelState.IsValid)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Transaction recorded!";
            return RedirectToAction(nameof(Index));
        }
        return View(transaction);
    }
}