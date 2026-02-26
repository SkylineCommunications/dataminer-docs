---
uid: DMAAutomationScriptOptionClientTimeZone
---

# DMAAutomationScriptOptionClientTimeZone

Available from DataMiner 10.6.4/10.7.0 onwards. <!-- RN 44742 / RN 44788 -->

| Item | Format | Description                                                          |
|------|--------|----------------------------------------------------------------------|
| Type | [DMAAutomationScriptOptionClientTimeZoneType](#dmaautomationscriptoptionclienttimezonetype) | Determines what should be used to provide time zone info. |
| Info | String | Information about the time zone, depending on what is set in *Type*. |

## DMAAutomationScriptOptionClientTimeZoneType

Available from DataMiner 10.6.4/10.7.0 onwards. <!-- RN 44742 / RN 44788 -->

| Option  | Description |
|---------|-------------|
| Iana    | Indicates that the time zone information should be provided based on the IANA time zone identifier set in the *Info* property. (See also: [Time Zone Database](https://www.iana.org/time-zones) at [iana.org](https://www.iana.org/).) |
| Default | Indicates that the [the default time zone client setting](xref:ClientSettings_json#setting-the-default-time-zone-for-dataminer-web-apps) will be provided as time zone info, as returned by [GetClientDefaultTimeZone](xref:GetClientDefaultTimeZone). |
