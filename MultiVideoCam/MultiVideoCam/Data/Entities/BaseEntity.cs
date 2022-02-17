namespace MultiVideoCam.Data.Entities
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
