using motosale.user.backend.DTO.HelperModels;
using motosale.user.backend.DTO.ResponseModels.Inner;

namespace motosale.user.backend.DTO.ResponseModels.Main
{
    public class ResponseList<T>
    {
        public StatusModel Status { get; set; }
        public List<T> Data { get; set; }
        public string TraceID { get; set; }
        public StaticVM Response { get; internal set; }
    }
}
