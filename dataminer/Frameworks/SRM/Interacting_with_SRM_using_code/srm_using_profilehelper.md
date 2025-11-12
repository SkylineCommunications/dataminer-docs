---
uid: srm_using_profilehelper
keywords: ProfileManager, profile definitions, profile instances, profile parameters
---

# Interacting with Profile Manager

The *ProfileHelper* class can be used in code to interact with *Profile Definitions*, *Profile Instances* and *Profile Parameters* objects. To instantiate a *ProfileHelper*, a callback to SLNet needs to be provided:

```csharp
// In an automation script
using Skyline.DataMiner.Net.Profiles;

var helper = new ProfileHelper(engine.SendSLNetMessages);

// In an ad hoc data source
var helper = new ProfileHelper(gqiDms.SendMessages);

// In a connector QAction
var helper = new ProfileHelper(protocol.SLNet.SendMessages);
```

> [!NOTE]
> When an error happens during the handling of profile objects, an exception of type *CrudFailedException* is thrown. This exception contains *TraceData* providing more information about the error, see [possible values](#errors-when-interacting-with-profiles). 
> This applies to all CRUD operations shown in the examples below, though not for Bulk operations, for which partial success is possible. For those *GetTraceDataLastCall* needs to be used to retrieve the trace data of the last call.

## Create profile parameters

```csharp
var symbolRateParameter = new Parameter(Guid.NewGuid())
{
    Name = "Symbol rate",
    Type = Parameter.ParameterType.Number,
    Units = "MS/s",
    DefaultValue = new ParameterValue
    {
        Type = ParameterValue.ValueType.Double,
        DoubleValue = 5,
    },
    Categories = ProfileParameterCategory.Configuration,
};

var modulationTypeParameter = new Parameter(Guid.NewGuid())
{
    Name = "Modulation Type",
    Type = Parameter.ParameterType.Text,
    Discretes = new List<string> { "QPSK", "QAM16", "QAM64", "QAM256" },
    DefaultValue = new ParameterValue
    {
        Type = ParameterValue.ValueType.String,
        StringValue = "QAM256",
    },
    Categories = ProfileParameterCategory.Configuration,
};

symbolRateParameter = helper.ProfileParameters.Create(symbolRateParameter);
modulationTypeParameter = helper.ProfileParameters.Create(modulationTypeParameter);
```

## Retrieve profile parameters
```csharp
var modulationTypeParameter = helper.ProfileParameters.Read(ParameterExposers.Name.Equal("Modulation Type")).FirstOrDefault();
```

## Update profile parameters
```csharp
modulationTypeParameter.DefaultValue.StringValue = "QAM64";
modulationTypeParameter = helper.ProfileParameters.Update(modulationTypeParameter);
```

## Bulk update profile parameters
```csharp
modulationTypeParameter.DefaultValue.StringValue = "QPSK";
symbolRateParameter.DefaultValue.DoubleValue = 7.5;
var updatedParameters = helper.ProfileParameters.AddOrUpdateBulk(modulationTypeParameter, symbolRateParameter);
```
> [!NOTE]
> The *AddOrUpdateBulk* method can be used to create or update multiple profile parameters in one call. If a parameter with the same ID already exists, it is updated; otherwise, a new parameter is created.
> There's also *AddOrUpdateBulk* methods available for *Profile Definitions* and *Profile Instances*.

## Delete profile parameters
```csharp
helper.ProfileParameters.Delete(modulationTypeParameter);
```

## Create profile definitions
```csharp
var profileDefinition = new ProfileDefinition(Guid.NewGuid())
{
    Name = "Decoding Definition",
    Description = "Profile definition for decoding settings",
};
profileDefinition.ParameterIDs.Add(symbolRateParameter.ID);
profileDefinition.ParameterIDs.Add(modulationTypeParameter.ID);

profileDefinition = helper.ProfileDefinitions.Create(profileDefinition);
```

## Read profile definitions
```csharp
var profileDefinition = helper.ProfileDefinitions.Read(ProfileDefinitionExposers.Name.Equal("Decoding Definition")).FirstOrDefault();
```

## Update profile definitions
```csharp
profileDefinition.Description = "Updated description";
profileDefinition = helper.ProfileDefinitions.Update(profileDefinition);
```

## Delete profile definitions
```csharp
helper.ProfileDefinitions.Delete(profileDefinition);
```

## Create profile instances
```csharp
var profileInstance = new ProfileInstance(Guid.NewGuid())
{
    Name = "Decoding Instance",
    Description = "Profile instance for decoding settings",
    AppliesTo = profileDefinition,
    Values = new ProfileParameterEntry[]
    {
        new ProfileParameterEntry
        {
            Parameter = symbolRateParameter,
            Value = new ParameterValue
            {
                Type = ParameterValue.ValueType.Double,
                DoubleValue = 6,
            },
        },
        new ProfileParameterEntry
        {
            Parameter = modulationTypeParameter,
            Value = new ParameterValue
            {
                Type = ParameterValue.ValueType.String,
                StringValue = "QAM16",
            },
        },
    },
};

profileInstance = helper.ProfileInstances.Create(profileInstance);
```

## Read profile instances
```csharp
var profileInstance = helper.ProfileInstances.Read(ProfileInstanceExposers.Name.Equal("Decoding Instance")).FirstOrDefault();
```

## Update profile instances
```csharp
profileInstance.Values[0].Value.DoubleValue = 10;
profileInstance = helper.ProfileInstances.Update(profileInstance);
```

## Delete profile instances
```csharp
helper.ProfileInstances.Delete(profileInstance);
```

## Errors when interacting with profiles

| Error reason   | Description  | Available properties |
|---|---|---|
| ModuleNotInitialized | ProfileManager is not initialized yet. | None |
| InvalidServiceProfileDefinitionLink | The linked service profile definition does not exist or is not valid because of existing service profile instances. | *ProfileDefinition* - The profile definition you attempted to delete or update. <br>*ServiceProfileDefinitionID* - The ID of the service profile definition that did not exist or was invalid. <br>*ProfileInstanceIDs* - The IDs of profile instances that reference a service profile instance no longer compatible with the new service profile definition. |
| InvalidServiceProfileInstanceLink | The linked service profile instance does not exist or is not valid because of the service profile definition of the profile definition. | *ProfileInstance* - The profile instance you attempted to delete or update. <br>*ServiceProfileInstanceID* - The ID of the service profile instance that did not exist or was invalid. <br>*ServiceProfileDefinitionID* - The ID of the service profile definition configured on the profile definition of the profile instance, which caused the service profile instance to be invalid. |
| InvalidMediationSnippetID | When creating or updating a profile parameter, the linked mediation snippet does not exist. | *MediationSnippetIDs* - The IDs of mediation snippets that could not be found. |
| InvalidParameterOnTableDefinition | One of the parameters specified on the table definition does not belong to the profile definition. | *ProfileDefinition* - The profile definition you attempted to create or update. <br>*ProfileParameterID* - The ID of the profile parameter not found in the profile definition. |
| EmptyTableDefinition | One of the table definitions specified on the profile definition did not contain any columns. | *ProfileDefinition* - The profile definition you attempted to create or update. |
| InvalidValueReference | The profile instance references a value that could not be resolved. | *ProfileInstance* - The profile instance with the invalid value reference. <br>*ProfileParameterID* - The ID of the profile parameter containing the invalid value reference. |
| RemovedProfileParameterInUse | The profile definition removes a profile parameter while at least one profile instance exists that is dependent on that profile definition parameter. | *ProfileDefinition* - The profile definition requesting parameter removal. <br>*ProfileInstanceIDs* - The IDs of profile instances affected by the removal of parameters from their associated profile definition. |
| ProfileInstanceChangedType | The IsValueCopy property changed value while editing the profile instance. | *ProfileInstanceID* - The ID of the profile instance. |