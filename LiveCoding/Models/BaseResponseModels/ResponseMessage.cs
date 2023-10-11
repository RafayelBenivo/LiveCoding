using LiveCoding.Enums;

namespace LiveCoding.Models.BaseResponseModels
{
    public class ResponseMessage
    {
        public MessageTypeEnum Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StackTrace { get; set; }
        public IList<ExtraMessage> Details { get; set; }
        public string MoreInfo { get; set; }
    }
}
