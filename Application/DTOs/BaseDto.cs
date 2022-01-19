namespace Application.DTOs
{
    public abstract class BaseDto<TKey>
    {
        public TKey Id { get; set; }
    }
}