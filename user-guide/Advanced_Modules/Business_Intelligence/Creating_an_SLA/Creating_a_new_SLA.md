---
uid: Creating_a_new_SLA
---

# Creating a new SLA

If a Service Level Agreement (SLA) exists for a particular service, you can create an SLA element in DataMiner to monitor the SLA parameters. To do so:

1. Right-click in the Surveyor and select *New \> SLA*.

2. Fill in the following fields:

    - *Name*: The name of the new SLA element.

    - *Service*: The service the SLA will monitor.

        > [!NOTE]
        > SLAs cannot monitor replicated services.

    - *Description*: An optional description of the SLA.

    - *DMA*: The DataMiner Agent on which you want to create the SLA element.

    - *Protocol*: The SLA protocol, e.g. Skyline SLA Definition Basic.

    - *Version*: The protocol version.

    - *Alarm template*: The template used for alarm monitoring of the SLA itself.

    - *Trend template*: The template used for trending of SLA parameters.

    > [!NOTE]
    > To a large extent, the SLA creation card is similar to a regular element creation card. Therefore, for more detailed information, refer to [Adding elements](xref:Adding_elements).

3. Click *Next* and select the view where you wish to create the SLA.

4. Optionally, click *Next* and add properties to the SLA.

5. To finish creating the SLA, click *Create*.
