using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace CustomerDatabaseAPI.Server.Utilities
{
    public static class AzureConfigurationManager
    {
        public static string GetConnectionString(string VaultName, string SecretName)
        {
            string 
                VaultURI = String.Format("https://{0}.vault.azure.net/", VaultName),
                SecretID = String.Format("{0}secrets/{1}", VaultURI, SecretName);

            var SecretClient = new SecretClient(new Uri(VaultURI), new DefaultAzureCredential());
            KeyVaultSecret KeyVaultSecret = SecretClient.GetSecret(SecretID);

            return KeyVaultSecret.Value;
        }
    }
}