---
uid: srm_using_profilehelper
keywords: ProfileHelper
---

# Interacting with Profile Helper

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