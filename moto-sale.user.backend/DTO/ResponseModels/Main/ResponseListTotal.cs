using motosale.user.backend.DTO.HelperModels;

namespace motosale.user.backend.DTO.ResponseModels.Main
{
    public class ResponseListTotal<T>
    {
        public StatusModel Status { get; set; }
        public ResponseTotal<T> Response { get; set; }
        public string TraceID { get; set; }
    }
}
