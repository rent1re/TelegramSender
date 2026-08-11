using Microsoft.AspNetCore.Mvc;
using TelegramSender.Services;

namespace TelegramSender.Controllers;

public class TelegramController : Controller
{
    private readonly TelegramSenderService _telegram;

    public TelegramController(TelegramSenderService telegram)
    {
        _telegram = telegram;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Send(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            text = "Hello from TelegramSender";
        }

        try
        {
            var result = await _telegram.SendMessageAsync(text);
            ViewBag.Ok = true;
            ViewBag.Result = result;
        }
        catch (Exception ex)
        {
            ViewBag.Ok = false;
            ViewBag.Result = ex.Message;
        }

        return View("Index");
    }
}