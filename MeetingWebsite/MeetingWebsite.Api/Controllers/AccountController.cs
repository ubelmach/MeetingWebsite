﻿using System.Threading.Tasks;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MeetingWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        //POST: /api/account/Register
        [HttpPost, Route("Register")]
        public async Task<object> Register(RegisterViewModel model)
        {
            var url = HttpContext.Request.Host.ToString();
            var result = await _accountService.RegisterUser(model, url);
            if (result == null)
                return BadRequest(new { message = "User with this email is already registered" });
            return Ok(result);
        }

        //GET: /api/account/ConfirmEmail?userid=value&code=value
        [HttpGet]
        [Route("ConfirmEmail", Name = "ConfirmEmailRoute")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);
            }
            var user = await _accountService.GetUser(userId);
            if (user == null)
            {
                return BadRequest("Error");
            }
            var result = await _accountService.ConfirmEmail(user, code);
            if (result.Succeeded)
                return Ok();
            return BadRequest(result.Message);
        }

        //POST : /api/account/Login
        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var token = await _accountService.LoginUser(model);
            if (token != null)
                return Ok(new { token });
            return BadRequest(new { message = "Username or password is incorrect or not confirm email." });
        }
    }
}