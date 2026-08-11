# TelegramSender
ASP.NET Core MVC app that sends Telegram messages via Bot API.
## Setup (Visual Studio)
1. Open `TelegramSender.sln`
2. Create a bot with [@BotFather](https://t.me/BotFather) and copy the token
3. Send `/start` to your bot
4. Get your `chat_id`:
5. Add settings to `appsettings.Development.json`:
`"Telegram": {
  "BotToken": "YOUR_TOKEN",
  "ChatId": "YOUR_CHAT_ID"
}`

6. Press F5
7.Open /Telegram, send a message, check Telegram
