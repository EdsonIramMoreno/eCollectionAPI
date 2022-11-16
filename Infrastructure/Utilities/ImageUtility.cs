using Firebase.Auth;
using Firebase.Storage;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Net.Sockets;
using System.Text;

namespace Core.Utilities
{
    public static class ImageUtility
    {
        public static async Task<string> uploadImage(string apiKey, string bucket, string user, string pass, string path, string imageStr)
        {
            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
                var a = await auth.SignInWithEmailAndPasswordAsync(user, pass);

                var cancellation = new CancellationTokenSource();
                var str = await FixBase64ForImage(imageStr);
                Byte[] bitmapData = Convert.FromBase64String(str);
                System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);

                var task = new FirebaseStorage(
                bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child(path)
                .PutAsync(streamBitmap, cancellation.Token);

                var downloadURL = await task;

                return downloadURL;

            }
            catch (Exception ex)
            {

                return null;
            }

            return null;
        }

        public static async Task<string> FixBase64ForImage(string Image)
        {
            System.Text.StringBuilder sbText = new System.Text.StringBuilder(Image, Image.Length);
            sbText.Replace("\r\n", String.Empty); sbText.Replace(" ", String.Empty);
            return sbText.ToString();
        }
        public static async Task<bool> deleteImage(string apiKey, string bucket, string user, string pass, string path)
        {
            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
                var a = await auth.SignInWithEmailAndPasswordAsync(user, pass);

                var cancellation = new CancellationTokenSource();

                var ab = new FirebaseStorage(
                bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child(path);

                ab.DeleteAsync();

                return true;

            }
            catch (Exception ex)
            {

                return false;
            }

            return false;
        }
    }
}
