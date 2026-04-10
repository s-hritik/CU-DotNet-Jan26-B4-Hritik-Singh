Azure Key Vault is a secure, centralized service in Microsoft Azure used to store and control access to sensitive data and cryptographic assets.

This Key Vault lab demo is a great way to understand how Azure separates Infrastructure Management from Sensitive Data Access.

🏦 Real-Life Usage: SmartBank Application
🔒 Scenario 1: Database Connection String
Problem
Your app needs DB access:
Server=db-prod;User=admin;Password=Super@123
❌ Wrong (very common)
Hardcode in appsettings.json
Commit to GitHub
👉 Anyone with repo access gets DB access

✅ Real-world solution (Secrets)
Store in Key Vault:
Name: DbConnectionString Value: Server=...;Password=...
App retrieves at runtime:
var secret = await secretClient.GetSecretAsync("DbConnectionString");
Use it to connect to DB

Part 1: Create the Key Vault
Sign in to the Azure Portal.
Search for Key Vaults in the top search bar and select it.
Click + Create.
Basics Tab:
Subscription: Select your active subscription.
Resource Group: Create new (e.g., RG-Security-Demo).
Key Vault Name: Must be globally unique (e.g., vault-demo-2026-xyz).
Region: Choose a region close to you.
Pricing Tier: Select Standard.
Access Configuration Tab (Critical):
Select Azure role-based access control (RBAC).
Click Review + create, then Create.

Part 2: The "Permission Gap" Demo

Once deployed, go to the resource.
On the left menu, under Objects, click Secrets.
Click + Generate/Import.
The Result: You will likely see a red banner saying "The operation is not allowed by RBAC" or you will be unable to click create.

"Even though I created this vault, I am currently an Infrastructure Manager (Contributor/Owner), not a Data Manager. I don't have 'Secrets' permission yet."

Part 3: Granting Data Access (The Fix)
On the left menu, click Access Control (IAM).
Click + Add > Add role assignment.
Search for Key Vault Secrets Officer. Select it and click Next.
Click + Select members, find your account, and click Select.
Click Review + assign. Wait about 60 seconds for the change to propagate.

Part 4: Adding and Testing the Secret
Go back to Secrets on the left menu.
Click + Generate/Import.
Upload options: Manual.
Name: AppPassword.
Secret value: P@ssw0rd123!.
Click Create.
Retrieve it: Click on the AppPassword secret > click the current version > click Show Secret Value.

Part 5: Creating a Key (Encryption)
On the left menu, under Objects, click Keys.
Add Role assignment of Key Vault Crypto Officer
Click + Generate/Import.
Options: Generate.
Name: DataEncryptionKey.
Key Type: RSA (2048).
Click Create.
Note: Notice you cannot "see" the private key. You can only download the Public Key. This is the core difference: Secrets are for storage/retrieval; Keys are for cryptographic operations that happen inside the vault.

Lab Cleanup
To avoid costs and clutter:
Go to the Overview page of your Key Vault.
Click Delete at the top.
Important: Key Vaults have "Soft Delete" enabled by default. To fully remove it, you must go to Key Vaults > Manage deleted vaults and Purge it.

To retrieve a secret from Azure Key Vault in a C# application, the industry standard is to use the Azure.Identity and Azure.Security.KeyVault.Secrets libraries.

This approach uses "DefaultAzureCredential," which automatically handles authentication whether you are running locally (using VS Code/Visual Studio login) or in Azure (using Managed Identity).

1. Install Required NuGet Packages
   Run these commands in your terminal or via the NuGet Package Manager:
   PowerShell
   dotnet add package Azure.Identity
   dotnet add package Azure.Security.KeyVault.Secrets

2. The Implementation Code
   Here is a clean, asynchronous implementation. Replace the vaultUri with your actual Key Vault DNS name (found on the Overview page in the portal).
   C#
   using System;
   using System.Threading.Tasks;
   using Azure.Identity;
   using Azure.Security.KeyVault.Secrets;

class Program
{
static async Task Main(string[] args)
{
// 1. Define your Vault URL and the Secret Name
string vaultUri = "https://your-vault-name.vault.azure.net/";
string secretName = "DatabasePassword";

        try
        {
            // 2. Create the SecretClient using DefaultAzureCredential
            // This will pull credentials from Visual Studio, Azure CLI, or Managed Identity
            var client = new SecretClient(new Uri(vaultUri), new DefaultAzureCredential());

            Console.WriteLine($"Retrieving secret '{secretName}' from {vaultUri}...");

            // 3. Get the secret asynchronously
            KeyVaultSecret secret = await client.GetSecretAsync(secretName);

            // 4. Output the secret value
            Console.WriteLine($"Your secret value is: {secret.Value}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving secret: {ex.Message}");
        }
    }

}
🔐 Azure Keys vs Secrets — Core Difference

🏦 Real-Life Scenario: SmartBank Application
You’re building a banking app (similar to what you’ve been discussing).
You have two different security needs:

🔐 Case 1: Protecting Sensitive Data (Use KEYS)
👉 Problem
You store customer data:
Account number
Aadhaar
PAN

✅ Correct approach using Azure Key Vault Keys
Flow:
App sends data → Key Vault
Key Vault encrypts using RSA key
App stores encrypted data in DB

Using an Azure Key
dotnet add package Azure.Security.KeyVault.Keys dotnet add package Azure.Identity
internal class AzureKeyDemo
{
static void Main(string[] args)
{
string keyVaultUrl = "https://sks123kv112.vault.azure.net/";
string keyName = "jwtkey";

        var credential = new DefaultAzureCredential();

        var cryptoClient = new CryptographyClient(
            new Uri($"{keyVaultUrl}keys/{keyName}"),
            credential
        );

        string plainText = "Hello SmartBank!";
        byte[] data = Encoding.UTF8.GetBytes(plainText);

        // Encrypt
        var encryptResult = cryptoClient.Encrypt(
            EncryptionAlgorithm.RsaOaep,
            data
        );

        Console.WriteLine($"Encrypted: {Convert.ToBase64String(encryptResult.Ciphertext)}");

        // Decrypt
        var decryptResult = cryptoClient.Decrypt(
            EncryptionAlgorithm.RsaOaep,
            encryptResult.Ciphertext
        );

        string decryptedText = Encoding.UTF8.GetString(decryptResult.Plaintext);
        Console.WriteLine($"Decrypted: {decryptedText}");

    }

}
