using OpenAI_API;


public static class OpenAIChatGptSettings
{
    public static WebApplicationBuilder AddOpenAIChatGPT(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        var chatGptKey = configuration["OpenAIChatGpt:Key"];

        var chat = new OpenAIAPI(chatGptKey);

        builder.Services.AddSingleton(chat);

        return builder;
    }
}
