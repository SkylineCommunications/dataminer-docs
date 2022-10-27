---
uid: creating_profile_load_scripts
---

# Creating Profile-Load Scripts

A [Profile-Load Script (PLS)](xref:srm_scripting#profile-load-script-pls) is responsible for the orchestration of a specific virtual function. It is typically created for a specific virtual function exposed by a specific connector.

You will need to make sure a Profile-Load Script is available for each virtual function in the system.

## Creating a Profile-Load Script

Below you can fin the basic steps to create a Profile-Load Scripts. For more detailed information on [script input arguments](#input-arguments-of-a-profile-load-script) and [content](#content-of-a-profile-load-script), as well as on [how to test the script](#testing-profile-load-scripts), refer to the sections below this.

1. Start from the example script *SRM_ProfileLoadScriptTemplate*, which is included in the SRM framework.

1. Add a script dummy named *FunctionDVE*, and link it to the protocol function DVE.

   A protocol function DVE is dynamically generated when a function definition is uploaded. Its name consists of the main protocol name and the name of the function.

1. Configure the script to set the configuration parameters on the virtual function of a connector.

1. To make sure the PLS is executed when a specific virtual function is orchestrated, when you have created the script, assign it to a profile definition:

   1. In the Profiles module, select the profile definition in the *definitions* tab.

   1. In the *Scripts* section, click *Add* to add the script. See [Configuring profile definitions](xref:Configuring_profile_definitions).

   > [!NOTE]
   > If the same virtual function is exposed by multiple connectors, different Profile-Load Scripts can be listed for the same profile definition.

## Input arguments of a Profile-Load Script

A PLS can take the following input arguments:

- Script dummy: *FunctionDve*, based on the virtual function definition.

  Specify the following two strings, separated by a period:

  - The name of the protocol (or "connector") associated with the main element generating the virtual function instance.

  - The name of the virtual function.

  > [!NOTE]
  > If you implement a PLS based on the example script in the framework, you will have to add this input argument.

- Script parameter: *Info*

- Script parameter: *ProfileInstance*

Input arguments will automatically be filled in by the SRM Framework when a profile needs to be applied to a function DVE.

> [!CAUTION]
> The content and syntax of the script parameters is subject to change. You should therefore never manipulate this yourself when you create or edit a PLS script.

## Content of a Profile-Load Script

### Helpers

The PLS example script contains helper classes and methods that you must use when you start implementing the script:

```csharp
var configurationInfo = LoadResourceConfigurationInfo(engine);
var nodeProfileConfiguration = LoadNodeProfileConfiguration(engine);
var helper = new ProfileParameterEntryHelper(engine, configurationInfo?.OrchestrationLogger);
```

### Retrieving profile parameter values

You can use the following method from the helper to retrieve the profile parameter values:

```csharp
var parametersConfiguration = helper.GetNodeSrmParametersConfiguration(configurationInfo, nodeProfileConfiguration).ToList();
```

The example below shows how to access the parameter values:

```csharp
foreach (var config in parametersConfiguration)
   {
       string value = config.Value.Type == ParameterValue.ValueType.Double ? Convert.ToString(config.Value.DoubleValue) : config.Value.StringValue;
       engine.GenerateInformation($"Parameter configuration {config.ProfileParameterName} with table key {config.ResourceKey}, parameter Id {config.ProtocolParameterId} and value {value}.");
   }
```

> [!NOTE]
> in case a mediation snippet is defined on profile parameter level, the mediated value will be returned. <!-- RN 32713 -->

### Function DVE configuration

Using the script dummy ("FunctionDve"), you can start configuring parameters on the function DVE (i.e. the virtual function resource):

```csharp
var dummyDve = engine.GetDummy(“FunctionDve”);
dummyDve.SetParameter(dummyDVE.GetWriteParameterIDFromRead(config.ProtocolParameterId), config.Value.GetValue());
```

### Logging

From within a Profile-Load Script, custom records can be added to the action logs, together with a severity indication: <!-- RN 30488 -->

```csharp
helper.LogFailure("An issue occurred"); 
   // generate a log record with ‘Normal’ severity

helper.LogSuccess("Configuration was successful");
   // generate a log record with ‘Critical severity

helper.Log("Report a warning", LogEntryType.Warning);
   // generate a log record with a custom severity
   // Namespace Skyline.DataMiner.Library.Solutions.SRM.Logging.Orchestration is needed
```

### Returning data

When [Service Orchestration](xref:srm_service_orchestration) is used, a Profile-Load Script can return data that can then be used within an [LSO script](xref:srm_scripting#life-cycle-service-orchestration-lso-script). This is done by means of a `<string,string>` dictionary that can be built using the following method: <!-- RN 30862 -->

```csharp
ProfileParameterEntryHelper.AddOrUpdateResult(string key, string value)
```

### Script result

If a Profile-Load Script fails to configure the function DVE, an exception must be thrown so that the framework can capture it and use it to set the booking to the "Failed" service state.

## Testing Profile-Load Scripts

To validate Profile-Load Scripts individually without the need to create a booking, you can create a PLS Tester element, which can be used manually, semi-manually, or automatically.

![PLS Tester](~/user-guide/images/PLS_Tester.png)

### PLS Tester setup

1. Make sure a Booking Manager app has been created in the DMS.

1. Create an element using the [Skyline Profile Load Script Tester](https://catalog.dataminer.services/result/driver/7537) protocol.

1. On the *General* page of the new element, in the *Booking Application* box, select the Booking Manager app you want to use for the testing.

### Manual usage of the PLS Tester



### Semi-manual usage of the PLS Tester

### Automatic usage of the PLS Tester
