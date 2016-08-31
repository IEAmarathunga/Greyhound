using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Forum
{
    public class ForumDiscussion
    {
        public int Discus_Id { get; set; }
        public string Discus_TopicId { get; set; }
        public string Discus_Subject { get; set; }
        public string Discus_Message { get; set; }
        public int Discus_StarterId { get; set; }
        public int? Discus_Replies { get; set; }
        public int? Discus_Views { get; set; }
        public DateTime? Discus_LastActionDate { get; set; }
        public string Discus_LastPost { get; set; }
        public bool Discus_SendEmailUpdate { get; set; }
    }
}
