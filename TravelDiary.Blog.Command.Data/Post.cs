using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelDiaries.Blog.Command.Data
{
    public class Post : IAudit
    {
        /// <summary>
        /// <inheritdoc cref="IAudit.Id"/>
        /// </summary>
        /// 
        public Guid Id { get; set; }
        
        public string Title { get; set; }

        public string HtmlTemplete { get; set; }

        /// <summary>
        /// <inheritdoc cref="IAudit.CreatedOn"/>
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// <inheritdoc cref="IAudit.UpdatedOn"/>
        /// </summary>
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// <inheritdoc cref="IAudit.CreatedBy"/>
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// <inheritdoc cref="IAudit.UpdatedBy"/>
        /// </summary>
        public string? UpdatedBy { get; set; }
    }
}
