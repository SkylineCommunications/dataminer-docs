---
uid: DMAPP_tab
---

# DMAPP tab

The *DMAPP* tab allows you to configure and build the DMAPP package, in the format introduced in DataMiner 10.0.11.

The following components are available:

- **Name**: Required field. The name of the application package solution you want to create. This name will be used as the suggested default file name when you build the package.

- **DisplayName**: Required field. The name of the application as it should be displayed to the user. By default, the value will be the same as of *Name*. The value can differ between versions if the name remains the same.

- **Version**: Required field. The version number you want to provide to the application package solution you want to create. Expected format is A.B.C or A.B.C-CUx where A, B, C , D and x are numerical values.

- **Min DMA Version**: Required field. The version number of the minimum required DataMiner version on which the package can be installed.

    Supported formats are "DataMiner Version Number - Build number" , e.g. 9.6.9.0 - 8478, or A.B.C or A.B.C-CUx , where A, B and C are the first 3 numbers of the full version number.

- **Allow Multiple Installed Versions**: Indicates if multiple versions of the package can be installed on a DataMiner System.

- **Installation Script**: Required field. The Automation script that defines the installation routine of the included content.

- **Uninstallation Script**: The Automation script that defines the routine to uninstall the package.

- **Configuration Script**: The Automation script that defines the configuration routine of the package. This allows you to e.g. configure parameters on an element.

- **Configuration Script Input Parameters**: Accessible via the *Config* button. Allows you to define the input for the configuration script.

    - **Entry ID**: Unique string identifier.

    - **Entry Name**: Displayed string value that will be shown to the user as a prompt.

    You can close the Config pop-up box by pressing Esc, by pressing the *Config* button again, or by clicking the close button.

- **Installation Script Dependencies**: The referenced dynamic linked libraries (DLL) required by the installation script. Multiple files can be selected.

- **Configuration Script Dependencies**: The referenced dynamic linked libraries (DLL) required by the configuration script.

- **Description**: A description of the purpose and contents of the package.

- **Files**: This button opens a pop-up box where you can configure the *Files to delete* and *Files to Leave*, i.e. the files that should be removed or kept, respectively. You can close the pop-up box by pressing Esc or clicking the *Files* button again.

- **DmProtocol Packages**: Allows you to include a collection of .dmprotocol packages that need to be installed.

    > [!NOTE]
    > Selected protocol-related content in the *Content* tab will be included in a generated .dmprotocol package, but a protocol will not be signed or encrypted. The protocol needs to be signed or encrypted on the DMA.
    >
    > The *DmProtocol Packages* item allows you to include a .dmprotocol created by the Protocol Builder, which is able to sign and encrypt files.

- **Build DMAPP**: Click this button to build the DMAPP using the selected content and settings.
