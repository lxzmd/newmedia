using LogisticsExpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsExpress.Model
{
    public class TopicQuestion: Entity<int>
    {
        /// <summary>
        /// 话题Id
        /// </summary>
        public int TopicId { get; set; }
        /// <summary>
        /// 会员Id
        /// </summary>
        public int MemberId { get; set; }
        /// <summary>
        /// 提问内容
        /// </summary>
        public string AskContent { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow { get; set; }
        /// <summary>
        /// 题主评论Id
        /// </summary>
        public int OwnerCommentId { get; set; }
    }
}
