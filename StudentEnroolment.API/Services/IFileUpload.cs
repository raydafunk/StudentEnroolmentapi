namespace StudentEnroolment.API.Services
{
    public interface IFileUpload
    {
        string UploadStudentFile(byte[] file,string imageName);
    }
}
