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
    using System;

    public partial class RoleData
    {
        public System.Guid ID { get; set; }
        public Nullable<System.Guid> ParentId { get; set; }
        public System.Guid RoleId { get; set; }
        public int Mode { get; set; }
        public System.Guid ModeId { get; set; }
        public Nullable<int> Permission { get; set; }
        public Nullable<int> Permit { get; set; }
        public Nullable<int> Index { get; set; }
        public Nullable<int> NodeType { get; set; }
        public string Name { get; set; }
    }
}
