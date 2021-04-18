using System;

namespace Project.Entities.Object {
    public class ObjectBase {
        public int Id { get; }
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
