﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTamagotchi.Converters.Identity;
using WebTamagotchi.Dto.Identity;
using WebTamagotchi.Identity.Services;

namespace WebTamagotchi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("players")]
    public async Task<IActionResult> GetPlayers()
    {
        var result = await _userService.GetPlayers();

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest($"Getting players failed: {result.Error}");
    }


    [HttpGet("player")]
    public async Task<IActionResult> GetPlayer(string email)
    {
        var result = await _userService.GetPlayer(email);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest($"Getting player failed: {result.Error}");
    }

    [HttpDelete("player")]
    public async Task<IActionResult> DeletePlayer(string email)
    {
        var result = await _userService.DeletePlayer(email);

        return result.IsSuccess
            ? Ok($"Player '{email}' deleted")
            : BadRequest($"Deleting player failed: {result.Error}");
    }
    
    [HttpGet("admins")]
    public async Task<IActionResult> GetAdmins()
    {
        var result = await _userService.GetAdmins();

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest($"Getting players failed: {result.Error}");
    }
    
    [HttpGet("admin")]
    public async Task<IActionResult> GetAdmin(string email)
    {
        var result = await _userService.GetAdmin(email);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest($"Getting admin failed: {result.Error}");
    }
    
    [HttpDelete("admin")]
    public async Task<IActionResult> DeleteAdmin(string email)
    {
        var result = await _userService.DeleteAdmin(email);

        return result.IsSuccess
            ? Ok($"Admin '{email}' deleted")
            : BadRequest($"Deleting player failed: {result.Error}");
    }
    
    [HttpPost("change-role")]
    public async Task<IActionResult> ChangeRole(string email, RoleDto roleDto)
    {
        var role = RoleConverter.ToModel(roleDto);
        var result = await _userService.ChangeRole(email, role);

        return result.IsSuccess
            ? Ok(UserConverter.ToDto(result.Value))
            : BadRequest($"Changing user role failed: {result.Error}");
    }
}