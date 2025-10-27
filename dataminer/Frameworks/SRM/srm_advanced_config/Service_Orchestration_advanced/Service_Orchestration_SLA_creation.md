---
uid: Service_Orchestration_SLA_creation
---

# Service Orchestration: configuring SLA creation

When the DataMiner service associated with a booking is available, an [SLA](xref:sla) can automatically be created to monitor the service.

At the start time of the booking, a predefined SLA configuration will be applied, based on what the user has selected when creating the booking.

To configure this:

1. In the Booking Manager app, go to *Config* > *Services and SLA*, and enable the *SLA* option.

1. Create a view for the SLA element in the Surveyor.

1. On the same Booking Manager tab as before, specify the name of the view you have created in the *SLA View* parameter.

1. Make sure there is at least one SLA configuration defined in the system. To do so:

   1. Open an existing SLA, go to the *SLA Configuration* page and click *Save/Load Config*.

   1. In the pop-up window, enter the file name in the *Configuration Name* box and click the green check mark.

   1. Click the *Save* button.

1. In the Booking Manager app, configure the *SLA Tracking Mode* parameter and the associated "Tracking" parameters to define when tracking should be enabled. See [SLA settings](xref:Booking_Manager_Config_tab#sla-settings).

1. When you create a booking, in the first step of the Booking Wizard:

   1. Make sure *Create SLA* is selected.

   1. In the drop-down box next to *Create SLA*, select the SLA configuration you want to use.
