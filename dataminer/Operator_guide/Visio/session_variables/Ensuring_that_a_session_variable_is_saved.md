---
uid: Ensuring_that_a_session_variable_is_saved
---

# Ensuring that a session variable is saved

To have a session variable saved across sessions, place the following prefix before the session variable name:

```txt
__saved_
```

The session variable is then saved in a separate .dat file located in the following folder on the client machine: `C:\Users\{Username}\AppData\Roaming\Skyline\DataMiner`. When a session variable is saved, if a user reopens a card with that session variable, the session variable will be set to the last saved value.

> [!NOTE]
> Using the variable name without the "\_\_saved\_" prefix will always result in a new session variable. As such, all components that use a saved session variable should always use the "\_\_saved\_" prefix.

> [!TIP]
> See also: [Ensuring that a card or page variable is saved](xref:Ensuring_that_a_card_or_page_variable_is_saved)
