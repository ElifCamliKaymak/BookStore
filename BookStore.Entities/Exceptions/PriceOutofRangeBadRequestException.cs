namespace BookStore.Entities.Exceptions
{
    public abstract partial class BadRequestException
    {
        public class PriceOutofRangeBadRequestException : BadRequestException
        {
            public PriceOutofRangeBadRequestException() : base("Maximum price should be less than 100 and greater than 10.")
            {

            }
        }

    }
}
