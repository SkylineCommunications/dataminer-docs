---
uid: BPA_Https_Configuration
---

# Https Configuration

## Best Practice

Hosting applications on HTTP leaves the applications vulnerable to Man-In-The-Middle attacks and is considered insecure.
It is recommended to host DataMiner over HTTPS only. Enabling HTTPS will make sure all data is TLS encrypted while transmitted over the network.
This BPA will verify if DataMiner and IIS are correctly configured to server Cube over HTTPS only.

From DataMiner 10.4.0.0 onwards, DataMiner will support gRPC instead of the deprecated .NET Remoting technology.
By enabling gRPC all communication with DataMiner will be TLS encrypted.

This BPA will also verify if it is possible to enable gRPC and recommend to do so.
It will also verify the correct firewall ports are closed/open based on the supported technologies (.NET Remoting or gRPC).

## Metadata

- Name: Https Configuration
- Description: Verifies HTTPS is correctly configured on the DataMiner Agent and Web Server.
- Author: Skyline Communications
- Default Schedule: Daily

## Results

### Success

DataMiner is using HTTPS and HTTP is disabled (remotely).

### Warning

There are several problems this BPA could detect:
- The DataMiner allows unencrypted HTTP traffic remotely.
- HTTPS is enabled but the *MaintenanceSettings.xml* is not configured correctly.
- DataMiner has not been restarted since enabling HTTPS.
- This DataMiner version supports gRPC but DataMiner still uses the deprecated .NET Remoting.
- The Name configured in the *MaintenanceSettings.xml* does not match the certificate or IIS binding.
- The Windows Firewall is completely disabled.

### Error

This BPA does not create errors.

## Mitigation

Enable HTTPS in DataMiner and disable .NET Remoting.
For more information, please refer to [Setting up HTTPS in DataMiner](https://docs.dataminer.services/user-guide/Advanced_Functionality/DataMiner_Agents/Configuring_a_DMA/General_DMA_configuration/Setting_up_HTTPS_on_a_DMA.html).
