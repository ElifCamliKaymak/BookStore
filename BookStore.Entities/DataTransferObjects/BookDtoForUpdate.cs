namespace BookStore.Entities.DataTransferObjects
{
    //dto readonly olmalıdır, değiştirilmemelidir, linq sorguları yapılabilir, referans tiplidir.
    public record BookDtoForUpdate(int Id, string Title, decimal Price);
}
