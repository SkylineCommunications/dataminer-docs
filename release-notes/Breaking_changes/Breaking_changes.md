---
uid: Breaking_changes
---

# Breaking changes

The following breaking changes have been introduced in recent DataMiner releases, or are planned for upcoming releases.

| Release note ID | Release version(s) | Description |
|--|--|--|
| [25216](xref:General_Feature_Release_10.0.5#dashboards-app-cpe-feed-component-now-uses-element-data-feed-id_25216) | DataMiner 10.1.0/10.0.5 | Dashboards: CPE component now has to be configured with a feed instead of through the component settings. |
| [26006](xref:General_Feature_Release_10.0.9#web-services-api-v1---new-and-updated-methods-to-manage-job-data-id_26006) | DataMiner 10.1.0/10.0.9 | Web Services API v1: Job management methods have been modified. |
| [28392](xref:General_Feature_Release_10.1.2#dataminer-object-model-id_28096id_28392id_28460) | DataMiner 10.2.0/10.1.2 | DefaultJobSectionDefinition extensions have been changed so they do not apply to an ISectionContainer but only to a Job. This is backwards compatible on a syntax level, but the code using these extensions will have to be recompiled using the updated SLNetTypes.dll. |
| [28912](xref:SRM_1.2.11#bookings-that-failed-to-start-now-set-to-failed-id_28912) | SRM 1.2.11 | Custom SRM scripts need to be updated in accordance with SRM_BookingStartFailureTemplate script. |
| [29095](xref:SRM_1.2.11#quarantining-a-contributing-booking-now-affects-the-main-booking-id_29095) | SRM 1.2.11 | Assigning a quarantined contributing resource to a booking is no longer possible. |
| [29306](xref:General_Feature_Release_10.1.5#enhanced-performance-by-implementing-iserializable-on-the-reservationinstance-class-using-protocol-buffer-serialization-id_29306) | DataMiner 10.2.0/10.1.5 | SRM changes:<br>- The Children and Parent property of a ReservationInstance will no longer be serialized between client and server. When the ResourceManagerHelper is used, backwards compatibility is implemented. However, if you use the messages yourself and receive ResourceManagerEventMessages via subscriptions (which is NOT recommended), you will need to call the GetStitched method on the ReservationInstance class. Saving ReservationInstances with a parent or child instance using messages may also cause issues.<br>- When the SetReservationInstances method is called on the ResourceManagerHelper, a random ID will now be assigned before the instances are saved to the server. This could be an issue if scripts expect the ID to be empty and try to reuse the object. |
| [29453](xref:General_Feature_Release_10.1.6#breaking-change-web-services-api-v0-is-now-disabled-by-default-id_29453) | DataMiner 10.2.0/10.1.6 | The Web Services v0 interface is now considered obsolete and is disabled by default. An option is available to enable the interface again if necessary. However, if a DMA is connected to the cloud, the v0 interface cannot be used. |
| [29545](xref:SRM_1.2.12#logging-of-srm-manager-displayed-for-other-bookings-id_29545) | SRM 1.2.12 | In SRM scripts, instead of initializing a new Logger instance, you should now use SrmLogHandler.Create (in Skyline.DataMiner.Library.Solutions.SRM.Logging). |
| [28684](xref:General_Feature_Release_10.1.10#improved-average-trending-id_28684) | DataMiner 10.2.0/10.1.10 | Average trending is now calculated differently. For more information, see Average trending calculation. |
| [30399](xref:General_Feature_Release_10.1.10#getting-and-setting-the-value-of-a-table-column-parameter-id_30399) | DataMiner 10.2.0/10.1.10 | Mobile Gateway: Setting or getting parameter values via text message is no longer possible with parameter names containing pipe characters. |
| [30913](xref:General_Feature_Release_10.1.11#breaking-change-dataminer-installer-will-only-enable-icmp-and-http-ports-80--8004-id_30913) | DataMiner 10.1.0 [CU8]/10.1.11 | DataMiner installer will now only enable ICMP and HTTP ports 80 & 8004. Other ports must be enabled manually if necessary. See Configuring the IP network ports. |
| [31534](xref:SRM_1.2.20#breaking-change-profile-instance-now-mandatory-if-profile-definition-has-parameters-to-configure-id_31534) | SRM 1.2.20 | The Booking Wizard no longer allows booking creation if the used function profile definition has parameters to configure while there are no profile instances in the system for the function. |
| [31675](xref:General_Feature_Release_10.2.2#breaking-change-end-of-internet-explorer-support-for-dataminer-web-apps-id_31675) | DataMiner 10.2.0/10.2.2 | DataMiner web apps can no longer be used with Internet Explorer. See End of Internet Explorer support for DataMiner web apps. |
| [33294](xref:General_Feature_Release_10.2.6#problem-when-filtering-a-table-with-a-foreign-key-relation-to-a-remote-table-using-a-filter-that-contained-a-value-from-the-remote-table-id_33294) | DataMiner 10.1.0 [CU15]/10.2.0 [CU3]/10.2.6 | When you filter a table on the value of a remote column and the remote table is empty, the table value filtering will now return an empty result set. Previously, all rows of the local table were returned, and actual filtering only happened as soon as the remote table had at least one row. |

The following breaking changes were introduced to features that were still in soft launch at the time:

| Release note ID | Release version(s) | Description |
|--|--|--|
| 26152 | 10.1.0/10.0.9 | Dashboards: Generic Query Interface queries can no longer contain a ColumnInfo object. Instead these now contain the name of the column. |
