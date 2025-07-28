---
uid: Creating_HTTP_simulations
---

# Creating HTTP simulations

Creating an HTTP simulation requires a bit more work.

1. While your HTTP device is being polled, use [Wireshark](xref:Wireshark) to capture all the HTTP traffic.

1. In Wireshark, go to *File* > *Export Packet Dissections* > *As PDML XML* to save your capture as a PDML file.

1. Manually edit the file:

   1. Add *HTTPSimulation* as a root tag around the PDML tags.

   1. Specify an *HTTPAgents* tag with an *HTTPAgent* tag inside it.

      The following attributes are needed:

      - *deviceIP*: The IP address of the HTTP device.

      - *devicePort*: The port of the HTTP device.

      - *simulationIP*: The IP address the simulation will listen on.

      - *simulationPorts*: Either specify a range using a hyphen (“-”), e.g. "50000-50005", or a port number.

      > [!NOTE]
      > The port number must be greater than or equal to 1024.

      The *deviceIP* and *devicePort* are used to be able to extract the appropriate data from the PDML part. The *simulationIP* and *simulationPorts* are used to specify where the simulation needs to run.

      ```xml
      <?xml version="1.0" encoding="utf-8"?>
      <?xml-stylesheet type="text/xsl" href="pdml2html.xsl"?>
      <HTTPSimulation>
         <HTTPAgents>
            <HTTPAgent deviceIP="127.0.0.1" devicePort="8082" simulationIP="127.0.0.1" simulationPorts="8888" />
         </HTTPAgents>
         <pdml version="0" creator="wireshark/3.4.1" time="Thu Apr 22 08:56:12 2021" capture_file="file.pcap">
         ...
         </pdml>
      </HTTPSimulation>
      ```
