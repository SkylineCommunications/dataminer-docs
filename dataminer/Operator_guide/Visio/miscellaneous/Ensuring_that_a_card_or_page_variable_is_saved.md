---
uid: Ensuring_that_a_card_or_page_variable_is_saved
---

# Ensuring that a card or page variable is saved

From DataMiner 10.2.0/10.1.2 onwards, it is possible to have a card or page variable saved across sessions.

To do so, place the following prefix before the variable name:

```txt
__saved_
```

The variable is then saved in a separate .dat file located in the following folder on the client machine: `C:\Users\{Username}\AppData\Roaming\Skyline\DataMiner`. When a variable is saved, if a user reopens a card with that variable, the variable will be set to the last saved value.

> [!TIP]
> See also:
> [Ensuring that a session variable is saved](xref:Ensuring_that_a_session_variable_is_saved)
