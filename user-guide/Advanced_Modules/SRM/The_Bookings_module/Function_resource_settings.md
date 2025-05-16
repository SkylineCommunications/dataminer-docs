---
uid: Function_resource_settings
---

# Function resource settings

Some advanced settings related to function DVEs linked with a function resource can be configured in the file *Config.xml*, in the folder `C:\Skyline DataMiner\ProtocolFunctionManager`.

This file contains the following tags:

- **ActiveFunctionResourcesThreshold**: This setting is used to configure the number of function DVEs that can be active at the same time. Their deactivation is scheduled after a booking has finished. They only get deactivated if the threshold is reached.

  The threshold will not act as a limit. The function DVEs assigned to ongoing bookings and bookings scheduled within the hysteresis time (see *FunctionHysteresis* below) will not get deactivated automatically.

  Default value: 100.

- **FunctionHysteresis**: This hysteresis is considered when the deactivation of function DVEs gets triggered (see *ActiveFunctionResourcesThreshold* above), to keep them from being disabled if they will be used again soon. This time span will be added to the start time of bookings and used to check whether a function resource is in use, in order to determine whether it should be disabled.

  This setting is also taken into account to activate a function DVE before the booking it is assigned to is started. For example, if the function hysteresis is set to 10 minutes, any deactivated (disabled) function DVE that is required for a booking will be activated 10 minutes before the start of the booking instance.

  Default value: 10 minutes.

- **FunctionActivationTimeout**<!-- RN 39672 -->: Available from DataMiner 10.4.0 [CU4]/10.4.7 onwards. When a booking is scheduled to start immediately, its assigned function DVEs will get activated, because the booking will fail to start if one of those DVEs is not active. This setting determines after how much time a booking will be considered to have failed to start if the function DVEs are still not activated.

  Default value: 1 minute. Prior to DataMiner 10.4.0 [CU4]/10.4.7, this default value is always used.

- **SkipDcfLinks**<!-- RN 39446 -->: Available from DataMiner 10.4.8/10.5.0 onwards. When a booking starts, DCF connections are created between the function DVEs of the assigned resources. They get deleted again when the booking finishes. This setting can be used to disable this start and end action.

  Default value: false.

For example:

```xml
<ProtocolFunctionManagerConfigInfo>
  <ActiveFunctionResourcesThreshold>100</ActiveFunctionResourcesThreshold>
  <FunctionHysteresis>PT1H</FunctionHysteresis>
  <FunctionActivationTimeout>PT1M</FunctionActivationTimeout>
  <SkipDcfLinks>true</SkipDcfLinks>
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
            currentConfig.FunctionHysteresis = TimeSpan.FromHours(1);
            currentConfig.FunctionActivationTimeout = TimeSpan.FromMinutes(2);
            currentConfig.SkipDcfLinks = true;
            protocolFunctionHelper.SetProtocolFunctionConfig(currentConfig);
        }
    }
}
```

> [!NOTE]
> From DataMiner 10.4.6/10.5.0 onwards<!--RN 39362-->, the `GetFunctionDefinitions` method is available for the ProtocolFunctionHelper, which allows you to retrieve multiple function definitions in one go. You can also use the `GetFunctionDefinition` method to retrieve a single function definition by ID. Prior to DataMiner 10.4.6/10.5.0, only the `GetFunctionDefinition` method is available.
