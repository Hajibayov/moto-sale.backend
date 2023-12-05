using motosale.user.backend.DTO.HelperModels;

namespace motosale.user.backend.DTO.ResponseModels.Main
{
    public class ResponseObject<T>
    {
        public StatusModel Status { get; set; }
        public T Response { get; set; }
        public string TraceID { get; set; }
    }
}
