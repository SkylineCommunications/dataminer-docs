---
uid: UD_APIs_Bad_and_Best_Practice
---

# User-Defined APIs: Bad and best practices

### Bad practice

> [!CAUTION]
> **Bad practice: Script config = Check Set Enabled.**
> With this flow, the API could experience delays and start to queue up incoming events, which may lead to timing out.
> The cause of this issue is the locking on the SLProtocol thread due to the execution of a group (running logic in SLScripting). This keeps the SetParam thread busy and renders the sets in Automation scripts on hold.
>
> As a result, ISS and/or the API manager can return a timeout on the API request, while the "run Automation scrip" to-do is still in the queue. This script is not cancelled or removed, but will eventually get executed, even though the original sender has already received a timeout.

![bad practice](~/user-guide/images/UserDefinedAPI-Internal_flow1.png)

### Best practice

> [!TIP]
> **Good practice: Script config = Check Set Enabled.**
> Use the main protocol thread for quick (short) actions such as adding the API event on a buffer table.
> Create an extra protocol thread that will handle any (long) running logical flows. This could, for example, execute the buffered API event.
>
> **Note: the automation sets are still blocked, but only while the main protocol thread is busy.**

![best practice](~/user-guide/images/UserDefinedAPI-Internal_flow2.png)
