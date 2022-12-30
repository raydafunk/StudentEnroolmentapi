namespace StudentEnrollment.data
{
    public abstract class BaseEnitiy
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public string? Createdby { get; set; }

        public DateTime ModificationDate { get; set; }

        public string? Modifiedby { get; set; }

    }
}