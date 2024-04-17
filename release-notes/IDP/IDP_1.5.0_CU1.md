---
uid: IDP_1.5.0_CU1
---

# IDP 1.5.0 CU1

## Enhancements

### Rack Usage Per Location dashboard now shows location names [ID_39273]

The "Rack Usage Per Location" dashboard will now show the location names in the graph legend, making it easier to quickly identify which locations have the highest rack utilization.

### IDP protocol visual overviews now delivered as protocol default [ID_39429]

The visual overviews used by the IDP protocols will now be delivered as protocol default Visio files instead of custom Visio files. This affects the Visio files for the following protocols:

- Skyline Infrastructure Discovery And Provisioning
- Skyline IDP Discovery
- Skyline Generic Provisioning
- Skyline Configuration Manager
- Generic Rack Layout Manager

When you upgrade to this IDP version, the existing custom Visio files will stay in the system, but IDP will now use the protocol default Visio files instead. If the custom Visio files have any custom changes, you can go back to using them by [making them the active Visio file](xref:Managing_Visio_files_linked_to_protocols#switching-between-different-visio-files). If you no longer need the custom Visio files, you can [delete them](xref:Managing_Visio_files_linked_to_protocols#removing-a-microsoft-visio-file-assigned-to-a-protocol).
