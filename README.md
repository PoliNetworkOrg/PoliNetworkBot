
# PoliNetworkBot
[![codecov](https://codecov.io/github/PoliNetworkOrg/PoliNetworkBot/branch/main/graph/badge.svg?token=VOA14BM161)](https://codecov.io/github/PoliNetworkOrg/PoliNetworkBot)
# PoliNetworkBot
Repository for the new revision of https://github.com/PoliNetworkOrg/PoliNetworkBot_CSharp

### Lib

We are using this library https://github.com/PoliNetworkOrg/Lib_CSharp

# PoliNetwork Telegram Bot
Codebase sperimentale per il refactoring del PoliNetwork Telegram Bot.

## Da implementare
1. **Helper**: restituisce la lista dei possibili comandi con la relativa descrzione
Utilizzare un file JSON per inserire la descrizione e la stringa per chiamare il comando. All'interno dell'intera applicazione, accedere alle variabile attraverso il file JSON per ridurre l'hardcoding e non dover riscrivere le variabili in altri progetti o linguaggi di programmazione. Vedi [ConfigurationBuilder](https://learn.microsoft.com/it-it/dotnet/api/microsoft.extensions.configuration.configurationbuilder?view=dotnet-plat-ext-7.0#remarks)
2. **SendMessageInGroup**: inoltrare un dato messaggio in un dato gruppo
3. Le altre funzionalità presenti nel bot...
4. Handler delle funzionalità.
5. Policy per il controllo delle forbidden words: algoritmo per il confronto (rimuovere spazi, convertire cifre con lettere simili etc.)

## Logistica ricezione messaggi:
1. Il messaggio viene inoltrato dall'utente.
2. Il messaggio viene letto dal bot.
3. Il messaggio viene esaminato.
4. In caso di spam, linguaggio scurrile e contenuti che violano le regole della comunity, il messaggio viene eliminato.
5. In caso di possibile messaggio duplicato, il bot inoltra un messaggio in chat privata all'utente soggetto.
6. In caso di comando, viene eseguito il comando richiesto.

### Testing
Creare il file `appsettings.json` all'interno della root directory e specifiare il token del vostro bot come segue
```json
{
  "Secrets": {
    "BotToken": "{YOUR_BOT_TOKEN}"
  }
}
```

Vedi come creare un bot e ottenere il relativo token: https://core.telegram.org/bots/tutorial#obtain-your-bot-token


