---
uid: Service_Orch_creating_LSO_scripts
---

# Creating LSO scripts

To set up Service Orchestration, you will also need a [Life cycle Service Orchestration (LSO) script](xref:srm_scripting#life-cycle-service-orchestration-lso-script) linked to each service definition.

1. Start from the available *SRM_LSOTemplate* script to create a first LSO script.

1. Develop the script to execute the Profile-Load Scripts either sequentially or in parallel.

1. To determine when the script is executed, in the Services module, configure actions for the service definition in the [Actions tab](xref:SRM_Services_definitions#actions-tab).

   - The *Name* column for each action will determine at which stages in the service life cycle the LSO script is executed (e.g. START, STANDBY, PAUSE, STOP).

   - In the *Script* column, specify the name of the LSO script.

You have now set up basic Service Orchestration: the LSO script will be executed at the booking stages you linked it to. This script will call the specified Profile-Load Scripts and start configuring the virtual functions.

> [!TIP]
> To test this setup, create a booking and select the timing, the resources and the profile instances for the virtual functions of the service definition. Check how the LSO script is called and verify that the booking is executed.
