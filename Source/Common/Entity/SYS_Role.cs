//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insight.Base.Common.Entity
{
    using System.Collections.Generic;

    public partial class SYS_Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_Role()
        {
            this.SYS_Role_Member = new HashSet<SYS_Role_Member>();
            this.SYS_Role_Action = new HashSet<SYS_Role_Action>();
            this.SYS_Role_Data = new HashSet<SYS_Role_Data>();
        }
    
        public System.Guid ID { get; set; }
        public long SN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool BuiltIn { get; set; }
        public bool Validity { get; set; }
        public System.Guid CreatorUserId { get; set; }
        public System.DateTime CreateTime { get; set; }
    
        public virtual SYS_User SYS_User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_Role_Member> SYS_Role_Member { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_Role_Action> SYS_Role_Action { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_Role_Data> SYS_Role_Data { get; set; }
    }
}
