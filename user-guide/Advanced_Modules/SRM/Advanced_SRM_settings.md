---
uid: Advanced_SRM_settings
---

# Function resources

From DataMiner 9.5.7 onwards, some advanced settings related to function DVEs linked with a function resource, can be configured in the file *Config.xml*, in the folder *C:\\Skyline DataMiner\\ProtocolFunctionManager*. This file contains the following tags:

| Tag | Description |
|--|--|
| ActiveFunctionResourcesThreshold | Used to configure the number of function DVEs that can be active at the same time. Their deactivation is scheduled after a booking has finished. They only get deactivated if the threshold is reached. The default threshold is 100. <br/> The threshold will not act as a limit, since it is not considered during the activation of function DVEs. |
| FunctionHysteresis | This hysteresis is considered when the deactivation of function DVEs gets triggered (see 'ActiveFunctionResourcesThreshold'), to keep them from being disabled if they will be used again soon. This time span will be added to the start time of bookings and used to check whether a function resource is in use, in order to determine whether it should be disabled. <br/> From DataMiner 9.5.8 onwards it is also considered to activate a function DVE before the booking it is assigned to, is started. For example, if the function hysteresis is set to 10 minutes, any deactivated (disabled) function DVE that is required for a booking will be activated (enabled) 10 minutes before the start of the booking instance. <br/> By default, up to DataMiner 9.5.12, this is set to *PT0S*, which means no hysteresis is applied. From DataMiner 9.5.13 onwards, the default value is 10 minutes.  |
| FunctionActivationTimeout | When a booking is scheduled to start immediately its assigned function DVEs will get activated, since the start will fail if one of those DVEs is not active. From DataMiner 10.4.7 onwards, this setting is available to define the timeout after which a booking will fail to start. The default value is 1 minute, which was the fixed value previously. |

For example:

```xml
<ProtocolFunctionManagerConfigInfo>
  <ActiveFunctionResourcesThreshold>100</ActiveFunctionResourcesThreshold>
  <FunctionHysteresis>PT0S</FunctionHysteresis>
  <FunctionActivationTimeout>PT1M</FunctionActivationTimeout>
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
            // Change to the desired values
            currentConfig.ActiveFunctionResourcesThreshold = 123;
            currentConfig.FunctionHysteresis = TimeSpan.Zero;
            currentConfig.FunctionActivationTimeout = TimeSpan.FromMinutes(2);
            protocolFunctionHelper.SetProtocolFunctionConfig(currentConfig);
        }
    }
}
```

> [!NOTE]
> From DataMiner 10.4.6/10.5.0 onwards<!--RN 39362-->, the `GetFunctionDefinitions` method is available for the ProtocolFunctionHelper, which allows you to retrieve multiple function definitions in one go. You can also use the `GetFunctionDefinition` method to retrieve a single function definition by ID. Prior to DataMiner 10.4.6/10.5.0, only the `GetFunctionDefinition` method is available.
