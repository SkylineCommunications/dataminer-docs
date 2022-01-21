---
uid: Engine_properties
---

## Engine properties

- [IsInteractive](#isinteractive)

- [ProfileManager](#profilemanager)

- [TicketingGateway](#ticketinggateway)

- [Timeout](#timeout)

- [UserCookie](#usercookie)

- [UserDisplayName](#userdisplayname)

- [UserLoginName](#userloginname)

#### IsInteractive

Gets a value indicating whether an interactive client is available for the script.

```txt
bool IsInteractive
```

Example:

```txt
bool isInteractive = engine.IsInteractive;
```

#### ProfileManager

Gets the Profile Manager.

```txt
SLProfileManager ProfileManager
```

Example:

```txt
var profileManager = engine.ProfileManager;
```

#### TicketingGateway

Gets the Ticketing Gateway.

```txt
SLTicketingGateway TicketingGateway
```

Example:

```txt
var ticketingGateway = engine.TicketingGateway;
```

#### Timeout

Sets or gets the timeout delay for the current C# code block.

```txt
TimeSpan Timeout
```

Example:

```txt
var timeout = engine.Timeout;
```

> [!NOTE]
> From DataMiner 10.2.0/10.1.2 onwards, this property can also be used to determine when an interactive Automation script times out.

#### UserCookie

Gets the user cookie. Available from DataMiner 10.0.5 onwards.

```txt
string UserCookie
```

#### UserDisplayName

Gets the displayed name of the user who is executing the script.

```txt
string UserDisplayName
```

Example:

```txt
engine.Log(engine.UserDisplayName);
```

#### UserLoginName

Gets the login name of the user who is executing the script.

```txt
string UserLoginName
```

Example:

```txt
engine.Log(engine.UserLoginName);
```
