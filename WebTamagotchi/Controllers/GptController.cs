using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace WebTamagotchi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class GptController: ControllerBase
{
    private readonly OpenAIAPI _chatGpt;
    
    public GptController(OpenAIAPI chatGpt)
    {
        _chatGpt = chatGpt;
    }

    [HttpGet]
    public async Task<IActionResult> GetResponseFromChatGpt(string text)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(text);

        var response = string.Empty;

        var completionRequest = new CompletionRequest
        {
            Prompt = text,
            Model = Model.DefaultModel,
            MaxTokens = 200,
        };

        var result = await _chatGpt.Completions.CreateCompletionAsync(completionRequest);

        if (result.Completions.Any())
            response = result.Completions.First().Text;

        return Ok(response);
    }
}