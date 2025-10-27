---
uid: Skyline_DataMiner_Core_InterAppCalls_Range_1.1
---

# Skyline DataMiner Core InterAppCalls Range 1.1

> [!NOTE]
> Range 1.1.x.x is supported as from **DataMiner 10.4.0**.

### 1.1.1.1

#### New feature - Updated custom serializer with the SecureCode NuGet package [ID 43755]

The implementation of the custom serializer in the InterApp class library has been updated to use the *SecureCoding* NuGet package. This further enhances protection against insecure deserialization, mitigating potential security risks when handling InterApp messages.

#### New feature - AnyCPU support [ID 43754]

Using the InterApp class library assembly from GQI is now supported. The build configuration has been updated to target *AnyCPU* instead of *x86*, improving compatibility across different environments.

### 1.1.0.1

#### Refactor - InterApp performance improvement [ID 43493]

Performance of InterApp calls has been enhanced by using the GetElementReference method instead of GetElement (IDms). This results in reduced SLNet calls, improving the performance of InterApp calls.
