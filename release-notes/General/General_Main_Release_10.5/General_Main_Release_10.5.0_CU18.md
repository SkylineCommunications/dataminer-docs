---
uid: General_Main_Release_10.5.0_CU18
---

# General Main Release 10.5.0 CU18 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> Before you upgrade to this DataMiner version:
>
> - Make sure the Microsoft **.NET 10** hosting bundle is installed (download the latest Hosting Bundle under ASP.NET Core Runtime from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)). See also: [DataMiner upgrade: New prerequisite will check whether .NET 10 is installed](xref:General_Main_Release_10.5.0_CU10#dataminer-upgrade-new-prerequisite-will-check-whether-net-10-is-installed-id-44121).
> - Make sure **version 14.44.35211.0** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation. The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
>   - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
>   - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU18](xref:Cube_Main_Release_10.5.0_CU18).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU18](xref:Web_apps_Main_Release_10.5.0_CU18).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataAPI: Enhanced handling of element creations failing because another element with the same name already exists [ID 45643]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

When the DataAPI fails to create an element because another element with the same name already exists, from now on, it will check whether that element has already been synchronized among the Agents in the DataMiner System. If not, the element creation will be allowed to continue.

#### ConfigureIIS.bat script will now ensure a dedicated Application Pool for the API application [ID 45842]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

The *ConfigureIIS.bat* script will now ensure a dedicated Application Pool for the API application. This will avoid needless restarts of the API when files running under the same DefaultAppPool would change inside WebPages.

This new application pool is called *DataMiner WebAPI AppPool*. it is solely intended to serve as pool for the web API, and will not recycle periodically.

### Fixes

#### Problem when using the 'Get parameter table by alias' data source against a STaaS database [ID 45766]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

The *Get parameter table by alias* data source retrieves a parameter table from the indexing database using the specified alias.

Up to now, this data source would only check whether the DataMiner System included an indexing database. It would not check the type of the database. As it currently only supports Elasticsearch and OpenSearch, up to now, exceptions would be thrown when it was used to retrieve data from a STaaS database.

From now on, the *Get parameter table by alias* data source will only be available when the DataMiner System includes an indexing database of type Elasticsearch or OpenSearch.
