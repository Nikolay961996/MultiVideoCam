namespace MultiVideoCam.Data.Modals
{
    public class BaseViewModal<T>
    {
        public T Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
