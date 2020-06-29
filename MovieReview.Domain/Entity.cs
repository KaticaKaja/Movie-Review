using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        //nalabilno (moze null) - DateTime?
        //jer je DateTime struct a to je vrednosni tip i nece biti null po defaultu
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
