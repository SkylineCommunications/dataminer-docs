---
uid: D44_Safety_Valid_Fixture
content_type: example
authority: illustrative
---

# D4.4 safety fixture

Use the dropdown menu to select a value.

<!-- documentation-safety: context=conditional -->
For DataMiner versions up to 9.0.1, a legacy controller.Run(dialog) call can be retained.
The current example uses controller.ShowDialog(dialog).

<!-- documentation-safety: context=legacy -->
```csharp
public void Run(Engine engine)
{
    controller.Run(dialog);
}
```

<!-- documentation-safety: context=negative-example; rule=certificate-validation-bypass -->
```csharp
handler.ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true;
```

<!-- documentation-safety: context=user-supplied -->
```powershell
$access_token = ${ACCESS_TOKEN}
```

```text
This unmarked block is reported as a classification gap.
```
