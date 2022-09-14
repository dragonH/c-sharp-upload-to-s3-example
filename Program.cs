// See https://aka.ms/new-console-template for more information
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.Runtime.CredentialManagement;


namespace UploadToS3Example {
    class Program {
        static async Task Main(string[] args) {
            var chain = new CredentialProfileStoreChain();
            // `profile_name` is aws profile name, need to be set up by aws cli first
            if (chain.TryGetAWSCredentials("profile_name", out var credentials)) {
                using (var s3Client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.APNortheast1)) {
                    TransferUtility fileTransferUtility = new TransferUtility(s3Client);
                    await fileTransferUtility.UploadAsync("./test.txt", "bucket_name", "test/test.txt");
                };
                
            }
            
        }
    }
}
