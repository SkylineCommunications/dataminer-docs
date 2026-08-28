---
uid: Using_credentials_in_an_automation_script
---

# Using credentials in an automation script

From DataMiner 10.7.0/10.6.10 onwards<!-- RN 44282 --><!-- RN 46229 -->, an automation script can retrieve credentials from the [Credentials Library](xref:Credentials_Library) at runtime. This way, using user names, passwords and access tokens is fully secured.

Credentials of type *Username and password* and *Token* can be used in an automation script.

## Declaring a credential

Before a *C# code* block can retrieve a credential, the credential must be declared as a script variable. In DataMiner Cube, you can do so in the *CREDENTIALS* section of the script. See [Creating a credential](xref:Script_variables#creating-a-credential).

In the script XML, this results in a [Credentials](xref:DMSScript.Credentials) element:

```xml
<Credentials>
    <Credential id="1">
        <Name>MyToken</Name>
        <CredentialId>8d15e7d8-f8f6-41f6-985c-fddbd3ea94ae</CredentialId>
        <Type>Token</Type>
    </Credential>
    <Credential id="2">
        <Name>MyLogin</Name>
        <CredentialId>3f2a9c41-7b6e-4d19-9a0c-1e5d84b2c7f3</CredentialId>
        <Type>UserNamePassword</Type>
    </Credential>
</Credentials>
```

The script only stores a reference to the credential. The actual secrets remain fully secured in the Credentials Library.

## Retrieving a credential

In a *C# code* block, use [engine.GetCredential](xref:Skyline.DataMiner.Automation.Engine.GetCredential*) to retrieve a declared credential, either by name or by ID:

```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Automation.Credentials;

public class Script
{
    public void Run(IEngine engine)
    {
        ScriptCredential tokenCredential = engine.GetCredential("MyToken");
        ScriptCredential loginCredential = engine.GetCredential(2);

        if (tokenCredential == null || loginCredential == null)
        {
            engine.ExitFail("The script credentials are not properly configured.");
            return;
        }

        string token = tokenCredential.GetToken();

        string userName = loginCredential.GetUserName();
        string password = loginCredential.GetPassword();
    }
}
```

The name lookup is case insensitive. If the script does not declare a credential with the specified name or ID, the method returns `null`.

The values are retrieved from the Credentials Library each time the method is called, so a script always works with the current content of the library.

> [!IMPORTANT]
> Never log the retrieved secrets or store them in a script output, memory file, or parameter. Doing so would expose them to users who do not have access to the credentials in question.