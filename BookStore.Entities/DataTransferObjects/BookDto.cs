namespace BookStore.Entities.DataTransferObjects
{
    [Serializable]   //serileştirilebilir demek
    public record BookDto(int Id, string Title, decimal Price);
}
