---
uid: TOODriverPassportPlatform
---

# Skyline Driver Passport Platform

> [!IMPORTANT]
> This section might include some information that is only applicable to Skyline employees and/or links that are only accessible to Skyline employees.

The Skyline Driver Passport Platform allows you to schedule remote installations of a DMAPP and will measure the performance impact. You can define and create any test; the only requirement is that the test should be included in a DMAPP or DMT and the intent should be to obtain performance KPIs from that test.

The primary goal of the platform is to obtain performance scaling results of a DMS protocol and performance indications from a DMS Solution in an automated flow. This information can for example be used to get an estimate of how many elements of a certain protocol can run on a DMA or what the performance impact of a protocol is. It allows you to detect anomalies and take action if needed to improve a protocol.

You can configure and schedule remote installations of a DataMiner package on the platform (with and without simulation) and results will automatically be stored in Test Management Platform TestLink.

The Driver Passport Platform protocol uses:

- A Microsoft Platform and SL_SystemHealthCheck element to obtain CPU and memory values, and to detect leaks on the remote DMA.

- The Skyline Device Simulator to simulate behavior of real devices.

> [!NOTE]
>
> -  For more information on how to create DMAPP and DMT packages, see [DataMiner Application Package Builder](xref:TOODataMinerPackageBuilder#dataminer-application-package-builder).
> -  For more information on the Skyline device simulator, see [Skyline Device Simulator](xref:TOOQASNMPSimulator).

- [Platform location](xref:Platform_location)

- [Platform capabilities](xref:Platform_capabilities)

- [Using the Driver Passport Platform](xref:Using_the_Driver_Passport_Platform)

- [Notifications](xref:Notifications)

- [Viewing test results](xref:Viewing_test_results)
