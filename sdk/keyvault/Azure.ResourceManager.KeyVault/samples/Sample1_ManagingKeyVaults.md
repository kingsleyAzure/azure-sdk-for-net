# Example: Managing the Key vaults

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:

```C# Snippet:Manage_KeyVaults_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.KeyVault.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
```

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `DefaultSubscription` property that returns the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via container objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupContainer
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
// With the container, we can create a new resource group with an specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroup resourceGroup = await rgContainer.CreateOrUpdate(rgName, new ResourceGroupData(location)).WaitForCompletionAsync();
```

Now that we have the resource group created, we can manage the Key vault inside this resource group.

***Create a vault***

```C# Snippet:Managing_KeyVaults_CreateAVault
VaultContainer vaultContainer = resourceGroup.GetVaults();

string vaultName = "myVault";
Guid tenantIdGuid = new Guid("Your tenantId");
string objectId = "Your Object Id";
Permissions permissions = new Permissions
{
    Keys = { new KeyPermissions("all") },
    Secrets = { new SecretPermissions("all") },
    Certificates = { new CertificatePermissions("all") },
    Storage = { new StoragePermissions("all") },
};
AccessPolicyEntry AccessPolicy = new AccessPolicyEntry(tenantIdGuid, objectId, permissions);

VaultProperties VaultProperties = new VaultProperties(tenantIdGuid, new Sku(SkuFamily.A, SkuName.Standard));
VaultProperties.EnabledForDeployment = true;
VaultProperties.EnabledForDiskEncryption = true;
VaultProperties.EnabledForTemplateDeployment = true;
VaultProperties.EnableSoftDelete = true;
VaultProperties.VaultUri = "";
VaultProperties.NetworkAcls = new NetworkRuleSet()
{
    Bypass = "AzureServices",
    DefaultAction = "Allow",
    IpRules =
    {
        new IPRule("1.2.3.4/32"),
        new IPRule("1.0.0.0/25")
    }
};
VaultProperties.AccessPolicies.Add(AccessPolicy);

VaultCreateOrUpdateParameters parameters = new VaultCreateOrUpdateParameters(Location.WestUS, VaultProperties);

var rawVault = await vaultContainer.CreateOrUpdateAsync(vaultName, parameters).ConfigureAwait(false);
Vault vault = await rawVault.WaitForCompletionAsync();
```

***List all vaults***

```C# Snippet:Managing_KeyVaults_ListAllVaults
VaultContainer vaultContainer = resourceGroup.GetVaults();

AsyncPageable<Vault> response = vaultContainer.GetAllAsync();
await foreach (Vault vault in response)
{
    Console.WriteLine(vault.Data.Name);
}
```

***Get a vault***

```C# Snippet:Managing_KeyVaults_GetAVault
VaultContainer vaultContainer = resourceGroup.GetVaults();

Vault vault = await vaultContainer.GetAsync("myVault");
Console.WriteLine(vault.Data.Name);
```

***Try to get a vault if it exists***

```C# Snippet:Managing_KeyVaults_GetAVaultIfExists
VaultContainer vaultContainer = resourceGroup.GetVaults();

Vault vault = await vaultContainer.GetIfExistsAsync("foo");
if (vault != null)
{
    Console.WriteLine(vault.Data.Name);
}

if (await vaultContainer.CheckIfExistsAsync("bar"))
{
    Console.WriteLine("KeyVault 'bar' exists.");
}
```

***Delete a vault***

```C# Snippet:Managing_KeyVaults_DeleteAVault
VaultContainer vaultContainer = resourceGroup.GetVaults();

Vault vault = await vaultContainer.GetAsync("myVault");
await vault.DeleteAsync();
```
