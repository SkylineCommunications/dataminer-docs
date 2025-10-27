---
uid: Configuring_a_serial_cell_phone_modem
---

# Configuring a serial cell phone modem

To configure a cell phone modem that is physically connected to one of your DataMiner Agents via a serial connection:

1. Insert the SIM card in the device.

1. Connect the antenna to the device.

1. Connect the device to the DataMiner Agent using a serial cable.

1. Connect the device to a power source.

1. In the `C:\Skyline DataMiner\Mobile Gateway` folder of the DataMiner Agent to which you have physically connected the modem, make sure that there is a *Config.xml* file similar to the one in the example below.

   > [!NOTE]
   > If the modem is connected to a DataMiner Agent through a serial gateway, then you need to configure a virtual COM port on the DataMiner Agent, and map it to the port on the serial gateway to which the modem is connected.
   >
   > See [Configuring a virtual COM port on a DataMiner Agent](#configuring-a-virtual-com-port-on-a-dataminer-agent)

1. After you have saved the *Config.xml* file, restart the DataMiner Agent.

1. In DataMiner Cube, go to *Apps* > *System Center.*

1. Select the *Mobile Gateway* tab and configure the necessary settings. For more information, see [Configuring Mobile Gateway in DataMiner Cube](xref:Configuring_Mobile_Gateway_in_DataMiner_Cube).

## Example of a Config.xml for a serial modem

```xml
<GSMConfig xmlns="http://www.skyline.be/config/config">
  <Device>Tango55</Device>
  <DMALostAfter>1</DMALostAfter>
  <FailedSMSRetry>100</FailedSMSRetry>
  <Files>
    <EncryptedConfig>C:\Skyline DataMiner\Mobile Gateway\MobileGateway.cfg</EncryptedConfig>
    <Macros>C:\Skyline DataMiner\Mobile Gateway\Macros.xml</Macros>
    <Messages>C:\Skyline DataMiner\Mobile Gateway\Messages.xml</Messages>
    <Logging></Logging>
  </Files>
  <GSM>
    <ServiceCenter>0475161616</ServiceCenter>
  </GSM>
  <CountryCode>32</CountryCode>
  <Port>
    <Nr>1</Nr>
    <Baudrate>9600</Baudrate>
    <Parity>no</Parity>
    <DataBits>8</DataBits>
    <StopBits>1</StopBits>
    <FlowCtrl>no</FlowCtrl>
  </Port>
  <SendErrorMessages>true</SendErrorMessages>
  <SplitTimer>50</SplitTimer>
  <TimeOutTime>10000</TimeOutTime>
</GSMConfig>
```

## Configuring a virtual COM port on a DataMiner Agent

If a Mobile Gateway is connected to a DataMiner Agent through a serial gateway, then you need to configure a virtual COM port on the DataMiner Agent, and map it to the port on the serial gateway to which the Mobile Gateway is connected.

The following procedure explains how to configure a virtual COM port when using a Moxa NPort device.

1. On the DataMiner Agent, install the latest Moxa NPort Administration Suite, and launch it.

1. Configure the NPort device.

   1. In the menu bar, click *Search IP*, enter the IP address of the NPort device, and click *OK*.

      If you do not know the IP address of the device, you can also click *Search* to search for any NPort devices on the network. In some network configurations, however, this may not work.

   1. In the left-hand *Function* pane, right-click *COM Mapping*, and click *Add Target*.

   1. In the *Add NPort* window, select the NPort device to which you would like to map COM ports, and click *OK*.

   1. In the *COM Mapping* list, right-click the port of the NPort device on which the Mobile Gateway is connected, and click *COM Settings*.

      > [!NOTE]
      > If necessary, you can disable the ports which do not need to be mapped or which are used by other applications.

   1. In the *Basic Settings* tab of the *COM Port Settings* window, open the *COM Number* selection box, and select the virtual COM port.

   1. In the *Serial Parameters* tab of the *COM Port Settings* window, specify the settings of the virtual COM port, and click *OK*.

      > [!NOTE]
      > How you configure the COM port will depend on the settings allowed by the Mobile Gateway device. Legacy data over voice gateways, for example, will normally allow a baud rate of 9600, while GPRS/EDGE/3G/4G gateways will allow a higher baud rate.

   1. In the *COM Mapping* list, right-click, and click *Apply Change*.

1. Set the operating mode of the selected COM port.

   1. In the left-hand *Function* pane, click *Configuration*. Then, on the right, right-click the NPort device, and click *Configure*.

   1. Click the *Operating Mode* tab, and select the *Modify* checkbox.

   1. In the list, select the COM port you selected in step 2.5, click *Settings*, set *Operating Mode* to “Real COM Mode”, and click *OK*.

   1. Back in the *Configuration* window, click *OK*, and exit the Moxa NPort Administration Suite.

   > [!NOTE]
   > You can also set the operating mode of a COM port using the Moxa web interface. To open this interface, open a web browser, and enter the IP address of the NPort device.

1. Set the COM port in the Mobile Gateway configuration file.

   1. Open the file *Config.xml* in the folder `C:\Skyline DataMiner\Mobile Gateway\`.

   1. In the *\<Port>* tag, specify the virtual COM port you selected in step 2.5 in the *\<Nr>* tag, and if the port settings differ from the default port settings, also specify those settings.

      ```xml
      <Port>
        <Nr>6</Nr>
        <Baudrate>9600</Baudrate>
        <Parity>no</Parity>
        <DataBits>8</DataBits>
        <StopBits>1</StopBits>
        <FlowCtrl>no</FlowCtrl>
      <Port>
      ```

   1. Save the XML file.
