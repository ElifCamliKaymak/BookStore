using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities.DataTransferObjects
{
    //dto readonly olmalıdır, değiştirilmemelidir, linq sorguları yapılabilir, referans tiplidir.
    public record BookDtoForUpdate : BookDtoManipulation
    {
        [Required]
        public int Id { get; init; }
    }
}
