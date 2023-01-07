namespace TravelDiaries.Blog.Command.Data
{
    /// <summary>
    /// Audit interface.
    /// </summary>
    public interface IAudit
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or Sets Created On
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or Sets Updated on
        /// </summary>
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// Gets or Sets Created By
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets Updated By
        /// </summary>
        public string? UpdatedBy { get; set; }
    }
}
