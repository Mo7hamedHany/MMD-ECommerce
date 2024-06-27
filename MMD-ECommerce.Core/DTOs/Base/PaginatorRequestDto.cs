namespace MMD_ECommerce.Core.DTOs.Base;

public abstract class PaginatorRequestDto
{
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
    //public int TotalCount { get; set; }

}
