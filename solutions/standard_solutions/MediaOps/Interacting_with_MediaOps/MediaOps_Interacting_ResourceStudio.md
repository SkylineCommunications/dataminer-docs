---
uid: MediaOps_Interacting_ResourceStudio
---

# TBD

Package: Skyline.DataMiner.Utils.MediaOps.Temp.Helpers


```csharp
public class Script
{
    public static void Run(Engine engine)
    {
        var clientMetadata = new ClientMetadata
        {
            ModuleId = "", // The Module ID of the client application.
            Prefix = "", // The prefix that will be used for all objects created by the Resource Studio.
        };

        var helper = new Skyline.DataMiner.Utils.MediaOps.Helpers.ResourceStudio.ResourceStudioHelper(engine, clientMetadata);
    }
}
```
