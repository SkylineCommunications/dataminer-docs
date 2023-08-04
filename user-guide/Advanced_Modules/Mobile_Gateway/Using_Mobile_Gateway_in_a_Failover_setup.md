---
uid: Using_Mobile_Gateway_in_a_Failover_setup
---

# Using Mobile Gateway in a Failover setup

To use Mobile Gateway based on one or multiple serial cell phone modems in a Failover setup, we recommend that you install your cell phone modem(s) in one of the ways detailed below.

> [!NOTE]
> This does not apply to IP-based cell phone modems. After you [configure an IP-based cell phone modem](xref:Configuring_an_IP-based_cell_phone_modem) for both DataMiner Agents, the device is available to the active DMA in the Failover pair.

1. One serial cell phone modem, connected to both the primary DMA and the backup DMA by means of a Mobile Gateway server.

    ![](~/user-guide/images/mobile_gateway_failover_1.jpg)

    > [!NOTE]
    > In this scenario:
    > - The two Failover DMAs have identical Mobile Gateway configuration files.
    > - The IP ports of the serial gateway should be mapped to serial ports on the Failover DMAs.
    > - In DataMiner Cube, *Cellphone location* has to be set to the IP address of the Failover pair.
    > - The DMA that is offline will close the connection, and the DMA that is online will open the connection.

2. Two serial cell phone modems, one connected to the primary DMA and the other connected to the backup DMA.

    ![](~/user-guide/images/mobile_gateway_failover_2.jpg)

    > [!NOTE]
    > In this scenario:
    > - The two Failover DMAs each have their own Mobile Gateway configuration file.
    > - In DataMiner Cube, *Cellphone location* has to be set to the IP address of the Failover pair.
    > - The DMA that is offline will close the connection, and the DMA that is online will open the connection.
    > - Users cannot send text messages to the Mobile Gateway as there is no way to find out which of the two telephone numbers has to be dialed.

3. One serial cell phone modem, connected to another DMA in the DMS cluster.

    ![](~/user-guide/images/mobile_gateway_failover_3.jpg)
