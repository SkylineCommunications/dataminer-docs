---
uid: D44_Safety_Invalid_Fixture
content_type: example
authority: illustrative
---

# D4.4 unsafe fixture

Use the dropdown here.

```csharp
public void Run(Engine engine)
{
    controller.Run(dialog);
    controller.ShowDialog(dialog);
    handler.ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true;
    engine.ExitFail(ex.ToString());
    password = "admin";
}
```
