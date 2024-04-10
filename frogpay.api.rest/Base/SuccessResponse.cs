namespace frogpay.api.rest.Base
{
    public class SuccessResponse<TEntity> : BaseResponse where TEntity : class
    {
        public TEntity Data { get; set; }
        public SuccessResponse(TEntity data) : base(true)
        {
            Data = data;
        }
    }
}