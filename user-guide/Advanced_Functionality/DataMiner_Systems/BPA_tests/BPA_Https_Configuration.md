---
uid: BPA_Https_Configuration
---

# HTTPS Configuration

Hosting applications on HTTP leaves those applications vulnerable to man-in-the-middle attacks and is considered insecure. It is recommended to host DataMiner over HTTPS only. Enabling HTTPS will make sure that all data is TLS-encrypted while it is transmitted over the network.

This BPA will verify if DataMiner and IIS are correctly configured to server Cube over HTTPS only.

From DataMiner 10.3.0 onwards, DataMiner supports gRPC instead of the deprecated .NET Remoting technology. When gRPC is enabled, all communication with DataMiner is TLS-encrypted. This BPA test will also verify if it is possible to enable gRPC and recommend to do so. It will also verify whether the correct firewall ports are closed or open based on the supported technologies (.NET Remoting or gRPC).

> [!NOTE]
> This BPA is available from DataMiner version 10.2.12 and 10.3.0 onwards.

## Metadata

- Name: Https Configuration
- Description: Verifies that HTTPS is correctly configured on the DataMiner Agent and web server
- Author: Skyline Communications
- Default Schedule: Daily

## Results

### Success

DataMiner is using HTTPS, and HTTP is disabled (remotely).

### Warning

There are several problems this BPA could detect:

- The DataMiner allows unencrypted HTTP traffic remotely.
- HTTPS is enabled but *MaintenanceSettings.xml* is not configured correctly.
- DataMiner has not been restarted since HTTPS was enabled.
- This DataMiner version supports gRPC but DataMiner still uses the deprecated .NET Remoting.
- The name configured in *MaintenanceSettings.xml* does not match the certificate or IIS binding.
- The Windows firewall is completely disabled.

### Error

This BPA does not create errors.

## Mitigation

Enable HTTPS in DataMiner and disable .NET Remoting.

For more information, see [Setting up HTTPS in DataMiner](https://docs.dataminer.services/user-guide/Advanced_Functionality/DataMiner_Agents/Configuring_a_DMA/Setting_up_HTTPS_on_a_DMA.html).
