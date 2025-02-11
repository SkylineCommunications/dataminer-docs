---
uid: Using_a_DMS_Serial_Gateway
---

# Using a DMS Serial Gateway

If you want to add elements to a DMA that are connected via a Serial Gateway, you first have to [prepare the Serial Gateway](#preparing-the-serial-gateway), then [add the elements to the DMS](#adding-the-elements-to-the-dms), and finally [check the communication](#verifying-communication).

## Preparing the Serial Gateway

### Before you start

- Connect the devices to the Serial Gateway using the proper cabling. Write down the ports to which you connect the devices.

- Check the serial communication settings of all connected devices (e.g. baud rate, data bits, stop bits, parity, flow control and bus address).

- Check the IP address assigned to the Serial Gateway.

### Preparing the Serial Gateway

1. Open a command prompt and enter "telnet \[IP Address of Serial Gateway\]".

   A telnet session with the Serial Gateway will be established.

   > [!NOTE]
   >
   > - Only one user at a time can access the Serial Gateway telnet interface.
   > - A telnet session left open on a Serial Gateway will automatically be terminated after a certain time.
   > - Alternatively, on recent versions, you can open a web browser to the IP address of the Serial Gateway instead.
   > - With recent versions, the front panel of the device also has a navigation menu that is very similar to the telnet interface, where you can configure the same settings.

   > [!IMPORTANT]
   > By default, the Telnet interface is deactivated. You can activate it using the *Telnet* tag in [DataMiner.xml](xref:DataMiner_xml).

1. Press *Enter* to confirm the console terminal type as "ansi/vt100".

   You will now get a menu in which you can easily navigate using the arrows keys on your keyboard.

   > [!NOTE]
   > On newer versions, this step is not necessary.

1. Select the operating settings from the main menu and press *Enter*.

1. Make sure the mode of the ports to which you connect the elements is set to *RAW (TCP Server)* or *TCP Server Mode*.

   > [!NOTE]
   >
   > - If this setting is not properly configured, the stream of the associated element will throw a "socket error 10061". This means that the Serial Gateway actively refused the connection.
   > - If at this point a warning appears that you must restart the Serial Gateway, do not do so yet.

1. Press *Esc* to leave the operating settings.

1. Select *Line* from the main menu or *Serial Settings* and the port number, and configure every individual port according to the settings prescribed for the attached device.

1. Press *Esc* to leave the Line menu.

1. Select *Save* and press *Enter*.

   To confirm, press *Enter* again. To cancel, press any other key.

1. In the main menu, select *Restart* to restart the Serial Gateway.

   > [!NOTE]
   > The Serial Gateway must always be restarted when you have changed something. However, if you did not make any changes, a restart is not necessary. In that case, in the main menu, select *Exit* to leave the telnet session.

Your Serial Gateway is now set up to handle all communication between the DMA and the serial devices.

## Adding the elements to the DMS

For every element connected via the Serial Gateway, do the following:

1. Right-click the view where you want to create a new element in the Surveyor, and select *New \> Element*.

1. Enter a name for the element.

1. Choose the protocol for the device connected to the Serial Gateway, and the right protocol version.

1. If necessary, choose an alarm and trend template for the element.

1. Set the *Type of port* to *TCP/IP*.

1. Next to *IP address/host*, fill in the IP address of the Serial Gateway.

1. Next to *IP port*, fill in the IP port associated with the serial port of the Serial Gateway to which the device is connected.

   > [!NOTE]
   > You can find the IP port on the web interface or via telnet. Typically, it is in the 4000 range.

1. Click *Next*, check if the element is created in the right view, and select a different view if necessary.

1. Click *Create* to finish creating the element.

## Verifying communication

After you have added all elements, to make sure that they have been correctly set up and are properly communicating with the DMA, do the following for every element:

1. Locate the new element in the Surveyor in DataMiner Cube.

1. Check the icon in front of the element name. It will give you some information about the current status of the device.

   - If the icon shows an alarm severity color:

     Communication with the DMA has been established, and all is working fine.

   - If the icon does not show an alarm severity color and contains either a "Stopped" symbol (black square) or a "Paused" symbol (two vertical bars):

     The element is currently either stopped or paused. The DMA is not communicating with the device, nor is it trying to.

     Right-click the element in the Surveyor, and choose *Set State \> Active*.

   - If the icon does not show an alarm severity color and contains a "Not Responding" symbol (red x):

     The DMA is trying to communicate with the element, but the element is not responding.

     Among the possible causes for this issue are incorrect elements settings (port, baud rate, bus address, protocol, etc.) or wrong cabling (wiring, wrong port, etc.).

1. If necessary, check communication between the element and the DMA. See [Monitoring real-time communication between a DMA and an element](xref:Monitoring_real-time_communication_between_a_DMA_and_an_element#monitoring-real-time-communication-between-a-dma-and-an-element).

1. Once communication between the DMA and the element is up and running, click the element in the Surveyor to open the element card.
