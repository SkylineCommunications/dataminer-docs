---
uid: Connector_help_Miteq_RSU_1_N
---

# Miteq RSU 1_N

This connector is designed to monitor and configure a Redundancy Switch Unit (RSU) that monitors the status of up to eight online frequency converters and a standby converter. When a fault is detected, the defective converter is automatically taken offline and replaced by the standby synthesized frequency converter. The RSU is capable of prioritizing converters so that critical communication channels have access to the standby converter on a priority basis. Switchover from a defective online converter to the standby converter is achieved by connecting the converters to a switch matrix located on the rear panel of the RSU.

## About

With this connector, you can configure how the RSU should operate. For instance, you can configure which converters should be prioritized by the priority level. On the **General page**, the status of the RSU in its totality, the status of the standby converter and that of the converters are monitored. In addition, the parameters of the standby converter can be set. On the **Settings 1-4 page**, the redundancy settings of the four first converters can be configured. On the **Settings 5-8 page**, the redundancy settings of the four last converters can be configured.

Note: Settings on the RSU are only possible with this connector if the device is in Remote Mode.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: 9600
  - **Databits**: 7
  - **Stopbits**: 1
  - **Parity**: Odd parity
  - **FlowControl**: Not specified

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: Required.
  - **Bus address**: Required. From 64 to 95. Default value is 64. The bus address can be filled in as a decimal number in the element configuration in DataMiner.

## Usage

### General

This page displays the **Mode and Status of the Redundancy Switch** and **the Status of the standby converter and 8 normal converters**. If a converter is in alarm Mode, a Fail will be mentioned here.

On the right-hand side of the page, the **Frequency**, **Intermediate Frequency (IF),** **Attenuation** and **Mute/UnMute** status of the standby converter can be configured. The range to which the standby converter frequency can be set depends on the type of the standby converter. This is also the case for the attenuation. The IF has possible values of 70 MHz and 140 MHz, but some standby converters only support 70 MHz and do not have this dual IF option. If a setting command is not accepted by the device, the value in the connector will not change. If it is accepted, the new value will be displayed by the connector. The value displayed by the connector therefore always corresponds with the actual value in the standby converter.

Note that these values can also be changed automatically when a converter is in an alarm condition and in need of the standby converter. If possible (see below), the device will accept this switchover and then the settings of that converter are copied to the settings of the standby converter. If the converter then continues to be in standby mode, you can further configure the settings of the standby converter on this page, until another converter with a higher priority goes into standby mode. If this happens, the converter with the higher priority will use the standby converter for bypassing (i.e. a switchover of the standby converter from the signal with the lower priority to the signal with the higher priority) and copy its new settings to the standby converter. The old converter with the lower priority will be switched back online and will not use the standby converter anymore. As a consequence of this behavior, it makes no sense to configure the settings if all converters are online (i.e. no converter is in standby mode) and no signal is switched to the standby converter.

It is also possible to **Mute** or **Unmute** the standby converter with a toggle button and to see the result of this action if it succeeded. If a converter goes into alarm state and a switchover to the standby converter succeeds, the standby converter will automatically be unmuted in case it was muted.

### Settings 1-4 / Settings 5-8

On these two settings pages, you can configure the **Frequency, IF level, Priority Level and Mode of the Converters**. Settings for the first 4 and last 4 converters can be found on two different pages.

Please note that changing the frequency setting of the converter does not actually set the frequency of the converter itself, but only the frequency of the converter that is saved in the memory of the RSU and displayed on the RSU front panel. However, it is very important to set the value of the frequency to the same value as of the converter itself, as the standby converter will use this value to configure its frequency when it takes over from the converter in case of an alarm condition.

This also applies for the attenuation level. This value must be configured in such a way that the attenuation of the standby converter will compensate for the difference in the distance that a signal has to travel when switched from its normal converter to the standby converter. The attenuation level can only be configured in steps of 0.2 dB. The IF level needs to be exactly the same IF as in the actual converter.

It only makes sense to fill in values that can also be set for the standby converter. This is because if a converter is set to standby mode, the standby converter will take over the settings (frequency, intermediate frequency and attenuation) configured on the settings page of that converter. As the standby converter can only have a limited set of possible values for these three parameters, the converter will only go into standby mode if the values of the converter are possible for the standby converter. If a switchover succeeds and a converter goes in standby mode, the standby converter will automatically be unmuted in case it was muted.

The priority level can also be configured and is a value between 1 and 7 (with 1 the lowest and 7 the highest). If a converter goes into alarm (i.e. Fail) mode, the RSU will automatically do a switchover to set that converter to standby mode. If another converter was already in standby mode, it will only do the switchover if the priority level of the converter is higher than the converter that was already in standby mode. If this is the case, the converter that was already in standby mode will be switched back online, as two converters cannot be in standby mode at the same time. If the priority level of the converter is lower than the converter that was already in standby mode, the switchover will not happen. Converters with the same priority level will be treated on a first-come/first-served basis.
