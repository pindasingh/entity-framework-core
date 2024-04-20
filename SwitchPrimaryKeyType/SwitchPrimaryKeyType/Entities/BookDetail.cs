namespace SwitchPrimaryKeyDataType.Entities
{
    public class BookDetail
    {
        public int Id { get; set; }

        public Guid BookId { get; set; }

        public string Description { get; set; }

        public Book Book { get; set; }
    }
}
