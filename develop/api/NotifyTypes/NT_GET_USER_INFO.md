---
uid: NT_GET_USER_INFO
---

# NT_GET_USER_INFO (120)

Retrieves user information.

```csharp
string userName = "Administrator";

object[] userInformation = (object[]) protocol.NotifyDataMiner(120 /*NT_GET_USER_INFO*/, userName, null);

foreach (object item in userInformation)
{
    string[] details = (string[])item;
    string uID = details[0];
    string fullName = details[1];
    string email = details[2];
    string telephoneNumber = details[3];
    string pager = details[4];

    for (int i = 5; i < details.Length; i++)
    {
        string group = details[i];
    }
}
```

## Parameters

- userName (string): Name of the user for which the information needs to be obtained.

## Return Value

- userInformation (object[]): Array of string arrays. Each string array contains the following information:
  - details[0]: User ID
  - details[1]: Full name
  - details[2]: email
  - details[3]: telephone number
  - details[4]: pager
  - details[5…n]: group to which this user belongs to.
