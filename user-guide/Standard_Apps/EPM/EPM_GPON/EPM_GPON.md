---
uid: EPM_GPON
---

# DataMiner EPM GPON

The GPON branch of the DataMiner EPM Solution is designed to manage Gigabit Passive Optical Network (GPON) deployments.

- [EPM GPON architecture](xref:GPON_architecture)
- [EPM GPON components](xref:GPON_components)
- [Supported technologies for GPON](xref:GPON_supported_technologies)
- [EPM GPON deployment](xref:GPON_deployment)
- [Available parameters in GPON](xref:GPON_KPI)

## Typical GPON physical deployment

In a typical GPON deployment, there are 4 main components:

- **Optical Line Termination (OLT)**: it is the main traffic concentrator and control device for the network below it. It's main function is to control the traffic flow in both directions (Upstream and Downstream - TX and RX in GPON).
- **Optical Fiber**: it is the transmission media for GPON. Its size (in number of fiber strands) depends on each implementation.
- **Optical Splitter**: In basic terms it is a prism, a single strand of fiber enters it and its signal can be divided up to 4 times at each stage.
- **Optical Network Terminal (ONT)**: It is the terminal device located at the subscriber premises, it is the last physical connection between the subscriber and the OLT in the network.

![EPM_GPON_deploy.png](~/user-guide/images/EPM_GPON_deploy.png)

You can find other implementations, those are focused on distance (less splits and longer fiber) or in speed (less subscribers by port), but in general this one presents the best balance between coverage, speed and number of subscribers.
