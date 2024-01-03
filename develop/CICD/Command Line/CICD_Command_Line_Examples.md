---
uid: CICD_Command_Line_Examples
---

# Command line CI/CD examples

## Basic deployment example

This is a basic script for uploading to the catalog and/or deployment to DMAs connected to dataminer.services.

We recommend combining this with quality control beforehand, such as executing static code analysis and running tests.

> [!NOTE]
> Our tools support both Windows and Linux. Below, you will find one example in PowerShell that you can use on a Windows machine, and another example using the terminal for Ubuntu users.

### Creating a dataminer.services key

A dataminer.services key is scoped to the specific DMS for which it was created and can only be used for deployments to that DMS.

For more information on how to create a dataminer.services key, refer to [Managing dataminer.services keys](xref:Managing_DCP_keys).

### Windows PowerShell

```powershell

dotnet tool install -g Skyline.DataMiner.CICD.Tools.Packager
dotnet tool install -g Skyline.DataMiner.CICD.Tools.CatalogUpload
dotnet tool install -g Skyline.DataMiner.CICD.Tools.DataMinerDeploy

dataminer-package-create dmapp "C:\PathToDirectoryOfSolution" --name HelloFromPowershell --output "C:\CreatedPackages" --type automation
$id = dataminer-catalog-upload --path-to-artifact "C:\CreatedPackages\HelloFromPowershell.dmapp" --dm-catalog-token 1234567
dataminer-package-deploy from-catalog --artifact-id "$id" --dm-catalog-token 1234567

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

Below you can find the actual code for creation and deployment, assuming you have a solution cloned here: *AS-JANS-ExampleDeployment*.

```bash
dataminer-package-create dmapp AS-JANS-ExampleDeployment --name HelloFromUbuntu --output AS-JANS-ExampleDeployment --type automation
id=$(dataminer-catalog-upload --path-to-artifact "AS-JANS-ExampleDeployment/HelloFromUbuntu.dmapp" --dm-catalog-token 12345)
dataminer-package-deploy from-catalog --artifact-id "$id" --dm-catalog-token 12345
```
