---
uid: Skyline_DataMiner_Core_InterAppCalls_Range_1.0
---

# Skyline DataMiner Core InterAppCalls Range 1.0

> [!NOTE]
> Range 1.0.x.x is supported as from **DataMiner 10.1.0**. This is based on the now obsolete [Class Library](xref:ClassLibrary_Range_1.2).

### 1.0.1.1

#### Breaking change - Replying to an InterApp message

Previously, it was possible to reply to an InterApp call in several ways that involved setting parameter 9000001 (or a similar PID) in some way. Now only a *.Reply* call on the incoming message is allowed. This change allows the library to dynamically select a more efficient underlying communication protocol if a high enough DataMiner version is used or to continue using SLNet subscriptions as a fallback.

> [!NOTE]
> The DIS Validator should help report possible invalid code when you update to the new InterApp branch.

#### Breaking change - isLegacyDestination removed

The *isLegacyDestination* argument is now no longer available for the *Send* method. This argument was intended to briefly assist in the move from the obsolete *SLC.Lib.* NuGet to the current library. This change occurred several years ago, and as such, this argument has been dropped to improve library code maintainability.

#### New feature - Enhanced efficiency on InterApp reply calls

The scalability and performance of InterApp calls have been drastically improved through the use of high-speed and modern message broker technology in the background.

The latest benchmark tests, at the time of release, demonstrate that the roundtrip time of an InterApp call with a response is over 100 times faster (600 ms to 6 ms), and the load on the SLNet process has been significantly reduced.

> [!NOTE]
>
> - For this improvement to be active, DataMiner version 10.3.12 or higher must be installed. Lower DataMiner versions will dynamically fall back to using SLNet subscriptions.
> - It is possible to forcibly disable the use of the new broker technology by either adding *LegacyInterAppSubscriptions* to the `C:\Skyline DataMiner\SoftLaunchOptions.xml` file or adjusting the source code to send a call with *allowBroker* set to *false*.
> - As of DataMiner 10.4.6, the default maximum message size with the new message broker is set to 30 MB.

#### New feature - Enhanced security: Remote code execution exploit prevention

Several classes are now checked and blocked from getting deserialized when InterApp calls are used. This will prevent bad actors from abusing these calls and remove their ability to maliciously run software as part of JSON deserialization (i.e., remote code execution exploits).

If such a potentially risky class is detected, a *SecurityException* will indicate that a potential RCE exploitation was found.

### 1.0.0.3

#### Refactor - DataMinerSystem library upgraded

The DataMinerSystem dependency has been upgraded to the latest version.

#### Fix - Reply message

It could occur that the reply method sent an incorrect message back. This has been fixed.

### 1.0.0.2

#### New feature - Support for Legacy namespaces

When sending a message, you can now set *isLegacyDestination* to true when the destination uses the legacy class library (SLC.Lib.\*) with namespace *Skyline.DataMiner.Library.Common*.

### 1.0.0.1

#### New feature - Migration from Class Library

InterApp classes and functionality have been extracted into a publicly available NuGet library. This has been extracted from Class Library range 1.2.0.x.
