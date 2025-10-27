---
uid: CICD_Command_Line_Examples
---

# Command line CI/CD examples

These are basic pipeline examples for uploading to the Catalog and/or deploying to DMAs connected to dataminer.services.

We recommend combining these with quality control beforehand, such as executing static code analysis and running tests.

> [!NOTE]
> Our tools support both Windows and Linux. Below, you will find examples in PowerShell that you can use on a Windows machine and examples using the terminal for Ubuntu users.

## Basic upload of non-connector items

This is a basic example for uploading non-connector items to the Catalog. Eventually, you will also be able to deploy such items to DMAs connected to dataminer.services via command line, but this is not yet supported at the moment.

For this example, you need a Visual Studio solution containing projects that are using [Skyline.DataMiner.SDK](xref:skyline_dataminer_sdk).

You will also need to configure your DataMiner organization key, which you can find on the organization's *Keys* page in the [Admin app](xref:About_the_Admin_app). For more information, see [Organization keys](xref:Managing_dataminer_services_keys#organization-keys).

> [!NOTE]
> The examples below use explicit parameter names (e.g. `-p:CatalogPublishKeyName="DATAMINER_TOKEN"`), which allows you to use any environment variable name. When you omit these parameters, the SDK uses the default key name configured in your project's .csproj file.

### Windows PowerShell

```powershell
$env:DATAMINER_TOKEN = "MyOrgKey"
dotnet publish -p:Version="0.0.1" -p:VersionComment="This is just a pre-release version." -p:CatalogPublishKeyName="DATAMINER_TOKEN" -p:CatalogDefaultDownloadKeyName="DATAMINER_TOKEN"
```

### Ubuntu terminal

Prerequisites on Ubuntu/Linux: you need dotnet-sdk-6.0.

```bash
# Get Ubuntu version
declare repo_version=$(if command -v lsb_release &> /dev/null; then lsb_release -r -s; else grep -oP '(?<=^VERSION_ID=).+' /etc/os-release | tr -d '"'; fi)

# Download Microsoft signing key and repository
wget https://packages.microsoft.com/config/ubuntu/$repo_version/packages-microsoft-prod.deb -O packages-microsoft-prod.deb

# Install Microsoft signing key and repository
sudo dpkg -i packages-microsoft-prod.deb

# Clean up
rm packages-microsoft-prod.deb

# Update packages
sudo apt update

sudo apt install dotnet-sdk-6.0
```

You will need to restart your session or log out and back in before the next part.

Below, you can find the actual code for creation and deployment, assuming you have a Visual Studio solution with projects using Skyline.DataMiner.SDK.

```bash
export DATAMINER_TOKEN="MyOrgKey"
dotnet publish -p:Version="0.0.1" -p:VersionComment="This is just a pre-release version." -p:CatalogPublishKeyName="DATAMINER_TOKEN" -p:CatalogDefaultDownloadKeyName="DATAMINER_TOKEN"
```

## Uploading and deploying connectors

For this example, you will need a dataminer.services **key for the specific DMS** to which you want to deploy the connectors. For more information on how to create a dataminer.services key, refer to [Managing dataminer.services keys](xref:Managing_dataminer_services_keys).

### Windows PowerShell

```powershell

dotnet tool install -g Skyline.DataMiner.CICD.Tools.Packager
dotnet tool install -g Skyline.DataMiner.CICD.Tools.CatalogUpload
dotnet tool install -g Skyline.DataMiner.CICD.Tools.DataMinerDeploy

dataminer-package-create dmapp "C:\PathToDirectoryOfSolution" --name HelloFromPowershell --output "C:\CreatedPackages" --type automation
$id = dataminer-catalog-upload --path-to-artifact "C:\CreatedPackages\HelloFromPowershell.dmapp" --dm-catalog-token 1234567
dataminer-package-deploy from-volatile --artifact-id "$id" --dm-system-token 1234567

```

### Ubuntu terminal

Prerequisites on Ubuntu/Linux: you need dotnet-sdk-8.0.

```bash
# Get Ubuntu version
declare repo_version=$(if command -v lsb_release &> /dev/null; then lsb_release -r -s; else grep -oP '(?<=^VERSION_ID=).+' /etc/os-release | tr -d '"'; fi)

# Download Microsoft signing key and repository
wget https://packages.microsoft.com/config/ubuntu/$repo_version/packages-microsoft-prod.deb -O packages-microsoft-prod.deb

# Install Microsoft signing key and repository
sudo dpkg -i packages-microsoft-prod.deb

# Clean up
rm packages-microsoft-prod.deb

# Update packages
sudo apt update

sudo apt install dotnet-sdk-8.0
```

You will need to restart your session or log out and back in before the next part.

Below you can find the actual code for creation and deployment, assuming you have a solution cloned here: *AS-JANS-ExampleDeployment*.

```bash
dataminer-package-create dmapp AS-JANS-ExampleDeployment --name HelloFromUbuntu --output AS-JANS-ExampleDeployment --type automation
id=$(dataminer-catalog-upload --path-to-artifact "AS-JANS-ExampleDeployment/HelloFromUbuntu.dmapp" --dm-catalog-token 12345)
dataminer-package-deploy from-volatile --artifact-id "$id" --dm-system-token 12345
```
