namespace MauiInteligente2022.AppBase.Helpers; 
public class MediaHelper {
    public async static Task<byte[]> TakePhotoAsync() {
        byte[] photoBytes = null;

        PermissionStatus writeStatus = await Permissions.RequestAsync<Permissions.StorageWrite>();
        PermissionStatus cameraStatus = await Permissions.RequestAsync<Permissions.Camera>();

        if (MediaPicker.IsCaptureSupported) {
            var photo = await MediaPicker.CapturePhotoAsync();
            if(photo is not null) {
                using var stream = await photo.OpenReadAsync();
                using var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                photoBytes = memoryStream.ToArray();
            }
        }

        return photoBytes;
    }
}