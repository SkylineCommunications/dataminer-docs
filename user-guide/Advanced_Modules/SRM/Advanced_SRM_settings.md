---
uid: Advanced_SRM_settings
---

# Advanced SRM settings

From DataMiner 9.5.7 onwards, advanced SRM settings can be configured in the file *Config.xml*, in the folder *C:\\Skyline DataMiner\\ProtocolFunctionManager*. This file contains the following tags:

| Tag | Description |
|--|--|
| ActiveFunctionResourcesThreshold | Used to configure the number of virtual function resources that can be active at the same time before a disabling of virtual function resources is triggered. Set this to an integer representing the maximum number of active virtual function resources. By default: 100. |
| FunctionHysteresis | Can be used to keep virtual function resources from being disabled if they will be used again soon. Set this to the number of seconds in the future that the system has to check whether a virtual function resource is in use, in order to determine whether it should be disabled. By default, up to DataMiner 9.5.12, this is set to *PT0S*, which means no hysteresis is applied. From DataMiner 9.5.13 onwards, the default value is 10 minutes. |

> [!NOTE]
> From DataMiner 9.5.8 onwards, the hysteresis functionality is expanded to also include the preloading of virtual function resources. This means that if, for example, function hysteresis is set to 10 minutes, any disabled virtual function resources that are required for a booking instance will be enabled 10 minutes before the start of the booking instance.

For example:

```xml
<ProtocolFunctionManagerConfigInfo>
  <ActiveFunctionResourcesThreshold>100</ActiveFunctionResourcesThreshold>
  <FunctionHysteresis>PT0S</FunctionHysteresis>
</ProtocolFunctionManagerConfigInfo>
```

To update this file without the need to restart DataMiner, use the protocolFunctionHelper as illustrated in the code snippet below. The configuration change will then be automatically synced in the cluster.

```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Messages;
namespace Script
{
    public class Script
    {
        public void Run(Engine engine)
        {
            var protocolFunctionHelper = new ProtocolFunctionHelper(engine.SendSLNetMessages);
            var currentConfig = protocolFunctionHelper.GetProtocolFunctionConfig();
            currentConfig.ActiveFunctionResourcesThreshold = 123; // Change to desired value
            protocolFunctionHelper.SetProtocolFunctionConfig(currentConfig);
        }
    }
}
```
