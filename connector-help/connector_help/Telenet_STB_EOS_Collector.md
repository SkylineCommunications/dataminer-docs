---
uid: Connector_help_Telenet_STB_EOS_Collector
---

# Telenet STB EOS Collector

The **Telenet STB EOS Collector** is part of the CPE setup, and works together with the **Telenet CPE Manager**, **Telenet eMTA Collector** and **Telenet CM Collector** connector. This connector is responsible for the polling of the STB data through an Apache Kafka Queue. The version of the **Telenet CPE Manager** needs to be at least in the 6.0.2.x version range.

## About

This connector does constant multi-threaded polling of the Apache Kafka Queue Brokers through a serial connection to retrieve the data of the STBs for a particular CMTS.

The data will be offloaded into CSV files and will be aggregated by the CPE Manager element. The CPE Manager element will provision the STB EOS Collector with the STBs for which data needs to be retrieved.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                               |
|------------------|-----------------------------------------------------------|
| 1.0.0.x          | Apache Kafka API v1, which is supported since Kafka 0.9.0 |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: Will be filled in by the element at runtime. Specify *127.0.0.1* as the value during element creation.
  - **IP port**: Will be filled in by the element at runtime. Keep the default value *8098* during element creation.

### Configuration of the broker parameters

The STB EOS Collector's data display pages are not intended to be opened. Instead, the configuration should be performed either through a multiple set or in Visual Overview.

Fill in the IP address and port of the broker to be contacted to request the metadata info. This can be filled in with the **Default STB Broker IP** and **Default STB Broker Port** parameters. The IP can be an IPv4 or IPv6 address.

Fill in the **CMTS Name** parameter so the element knows in which topic of the Kafka queue the STB data can be found.

### Configuration of the offload parameters

The parameter **Data Offload Folder** contains the location of the tuner offload files. The parameter **RCCV Data Offload Folder** contains the location of the IVR files.

### Configuration of the threshold parameters

The threshold parameters are used during aggregation. If the parameter in the CPE manager is %STB With DS SNR \< T, then the DS SNR parameter is compared with the DS SNR Low Threshold. If the SNR is below the value in the configuration parameter, the STB is taken into account.

The following parameters can be configured: **STB DS BER High Threshold**, **STB DS SNR Low Threshold**, **STB Level High Threshold** and **STB Level Low Threshold**.

### Configuration of the minimum variation parameters

To avoid having a constant offload of data because of value changes with 0.01, the minimum variation parameters can be configured. This means that the polled value needs to have a difference with the currently displayed value larger than the configured minimum variation parameter before this value will be taken into account.

The following variation parameters can be configured: **Minimum Variation Level**, **Minimum Variation SNR** and **Minimum Variation BER**.

## Usage

As described above, the STB EOS Collector is not intended to be used separately. The resulting data should be consulted with the CPE Manager interface of the CPE Manager elements.

## Generated CSV files

The STB EOS Collector will generate tab-separated CSV files. For more information on the location of these files, refer to the "Configuration" section above.

### Fast tuner offload structure

1. Device ID
1. SAP ID
1. Another Operator
1. Node
1. Timestamp
1. Tuner Number
1. Lock Status
1. Frequency
1. Level
1. SNR
1. BER
1. Error Packets

### IVR offload structure

1. Device ID
1. State
1. Timestamp
1. SAP ID
1. Another Operator
