namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int Id { get; set; }

        [StringLength(1000)]
        public string Message { get; set; }

        public DateTime? Date { get; set; }

        public int IdUser { get; set; }

        public int IdMDiary { get; set; }

        public virtual MessDiary MessDiary { get; set; }

        public virtual User User { get; set; }
    }
}
