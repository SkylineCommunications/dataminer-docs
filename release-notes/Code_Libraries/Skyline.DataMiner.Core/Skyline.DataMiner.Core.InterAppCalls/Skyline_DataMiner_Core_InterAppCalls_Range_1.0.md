---
uid: Skyline_DataMiner_Core_InterAppCalls_Range_1.0
---

# Skyline DataMiner Core InterAppCalls Range 1.0

> [!NOTE]
> Range 1.0.x.x is supported as from **DataMiner 10.1.0**. This is a continuation and split from the now obsolete [Class Library](xref:ClassLibrary_Range_1.2).

### 1.0.1.1

#### Breaking change - Replying to an InterApp message

Where before you were allowed to reply to an InterApp call in several ways that involved setting parameter 9000001 (or a similar PID) in some way, this has now changed to only allow a *.Reply* call on the incoming message.

This change allows our library to dynamically select a more efficient underlying communication protocol if you have a high enough DataMiner version, or to continue using SLNet Subscriptions as a fallback.

>[!NOTE]
> The DIS Validator should help report possible invalid code when updating to the new InterApp branch.

#### New feature - Enhanced efficiency on InterApp reply calls

The scalability and performance of InterApp calls have been drastically improved through the use of high-speed and modern message broker technology in the background.

The latest benchmark tests, at the time of release, demonstrate that the roundtrip time of an InterApp call with a response is over 100 times faster (600ms to 6ms) and significantly reduces the utilization of the SLNet process.

>[!NOTE]
> For this improvement to be active, you require DataMiner version 10.3.12 or higher. Lower DataMiner versions will dynamically fall back to using SLNet Subscriptions.

>[!NOTE]
> It is possible to forcibly disable the use of the new broker technology by either adding *LegacyInterAppSubscriptions* to the *C:\Skyline DataMiner\SoftLaunchOptions.xml* file or by adjusting your source code to send a call with *allowBroker* set to *false*.

#### New feature - Enhanced security: Remote code execution exploit prevention

Several classes are now checked and blocked from getting deserialized when using InterApp calls. This is to avoid bad actors abusing these calls and their ability to maliciously run software as part of JSON deserialization, something called remote code execution exploits.

If such a potentially risky class is detected, you will receive a *SecurityException* indicating a potential RCE exploitation was found.

### 1.0.0.1

#### New feature - Migration from Class Library

InterApp classes and functionality have been extracted into a publicly available NuGet library. This was extracted from Class Library range 1.2.0.x.