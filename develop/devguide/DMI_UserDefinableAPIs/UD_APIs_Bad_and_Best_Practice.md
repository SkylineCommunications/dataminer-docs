---
uid: UD_APIs_Bad_and_Best_Practices
---

# Bad and best practices

### Bad practice

> [!CAUTION]
> **Bad practice: Script config = Check Set Enabled.**
> With this flow, the API could experience delays and start to queue up incoming events, potentially leading to timeouts.
> This issue arises from locking on the SLProtocol thread due to the execution of a group (running logic in SLScripting). Consequently, sets in automation scripts are put on hold while the SetParam thread remains occupied.
>
> As a result, there is a risk that the ISS and/or the API manager may return a timeout on the API request even while the "run Automation scrip" task remains in the queue. This script is not cancelled or removed, but will eventually be executed, despite the original sender having already received a timeout.

![bad practice](~/develop/images/UserDefinedAPI-Internal_flow1.png)

### Best practice

> [!TIP]
> **Good practice: Script config = Check Set Enabled.**
> Use the main protocol thread for quick (short) actions, like adding the API event to a buffer table.
> Create an extra protocol thread to manage any (long) running logical flows, for example, executing the buffered API event.
>
> **Note: Automation sets remain temporarily blocked while the main protocol thread is busy.**

![best practice](~/develop/images/UserDefinedAPI-Internal_flow2.png)
