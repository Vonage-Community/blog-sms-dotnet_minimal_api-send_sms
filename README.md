# Send an SMS with Minimal API

This demo app will shouw you how to send an SMS with .Net 6 and Minimal APIs

## Prerequisites

* You'll need a Vonage API account. You can [sign up here](https://dashboard.nexmo.com/sign-up)
* You'll need the latest version of the [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

## Configuration

In the `appsettings.json` file, replace the `Vonage_key` and `Vonage_secret` with your Vonage API Key and Secret.

This can be run in Visual Studio 2022 by hitting `F5`, or it can be run from the .NET CLI with `dotnet run`.

Once started navigate to the swagger page of the website (http://localhost:<port>/swagger), locate the SMS endpoint and click `Try it out` -> `Execute`