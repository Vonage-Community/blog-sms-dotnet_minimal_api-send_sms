using FluentValidation;
using FluentValidation.Results;
using SmsDotnetMinimalApi;
using Vonage;
using Vonage.Messaging;
using Vonage.Request;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// validation
builder.Services.AddValidatorsFromAssemblyContaining<SmsModel>(ServiceLifetime.Scoped);

builder.Services.AddSingleton<VonageClient>(context =>
{
    var config = context.GetRequiredService<IConfiguration>();
    var key = config.GetValue<string>("Vonage_key");
    var secret = config.GetValue<string>("Vonage_Secret");
    var credentials = Credentials.FromApiKeyAndSecret(key, secret);

    return new VonageClient(credentials);
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/sms", async (VonageClient vonageClient, SmsModel smsModel, IValidator<SmsModel> validator) =>
{
    ValidationResult validationResult =validator.Validate(smsModel);
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    var smsResponse = await vonageClient.SmsClient.SendAnSmsAsync(new SendSmsRequest
    {
        To = smsModel.To,
        From = smsModel.From,
        Text = smsModel.Text
    });

    return Results.Ok();
});

app.UseSwagger();
app.UseSwaggerUI();
app.Run();
