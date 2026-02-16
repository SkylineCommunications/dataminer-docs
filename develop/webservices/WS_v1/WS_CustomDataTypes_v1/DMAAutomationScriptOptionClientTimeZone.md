---
uid: DMAAutomationScriptOptionClientTimeZone
---

# DMAAutomationScriptOptionClientTimeZone

Available from DataMiner 10.6.4 onwards. <!-- RN 44742 / RN 44788 -->

| Item | Format | Description                                                          |
|------|--------|----------------------------------------------------------------------|
| Type | [DMAAutomationScriptOptionClientTimeZoneType](xref:DMAAutomationScriptOptionClientTimeZone#DMAAutomationScriptOptionClientTimeZoneType) | What should be used to provide type time zone info. |
| Info | String | Information about the time zone, depending on what is set in *Type*. |

## DMAAutomationScriptOptionClientTimeZoneType

Available from DataMiner 10.6.4 onwards. <!-- RN 44742 / RN 44788 -->

| Option  | Description |
|---------|-------------|
| Iana    | Try to provide the time zone information based on the [IANA time zone identifier](https://en.wikipedia.org/wiki/List_of_tz_database_time_zones) set in *Info* property. (See also [Time Zone Database](https://www.iana.org/time-zones) at [iana.org](https://www.iana.org/)) |
| Default | If set, the [the default time zone client setting](https://docs.dataminer.services/dataminer/Reference/Skyline_DataMiner_Folder/More_information_on_certain_files_and_folders/ClientSettings_json.html#setting-the-default-time-zone-for-dataminer-web-apps) will be provided as time zone info. As returned by [GetClientDefaultTimeZone](xref:GetClientDefaultTimeZone). |
