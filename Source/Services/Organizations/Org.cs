﻿using System;
using System.Collections.Generic;
using System.Linq;
using Insight.Base.Common;
using Insight.Base.Common.Entity;
using Insight.Utils.Entity;

namespace Insight.Base.Services
{
    public class Org
    {
        public Result Result = new Result();

        private readonly SYS_Organization _Org;
        private List<SYS_OrgMember> _Members;

        /// <summary>
        /// 组织机构是否已存在(按全称)
        /// </summary>
        public bool Existed
        {
            get
            {
                using (var context = new BaseEntities())
                {
                    var org = context.SYS_Organization.SingleOrDefault(u => u.FullName == _Org.FullName);
                    var existed = org != null && org.ID != _Org.ID;
                    if (existed) Result.DataAlreadyExists();

                    return existed;
                }
            }
        }

        /// <summary>
        /// 组织机构唯一ID
        /// </summary>
        public Guid ID
        {
            get { return _Org.ID; }
            set { _Org.ID = value; }
        }

        /// <summary>
        /// 父节点ID
        /// </summary>
        public Guid? ParentId
        {
            get { return _Org.ParentId; }
            set { _Org.ParentId = value; }
        }

        /// <summary>
        /// 节点类型
        /// </summary>
        public int NodeType
        {
            get { return _Org.NodeType; }
            set { _Org.NodeType = value; }
        }

        /// <summary>
        /// 节点排序索引
        /// </summary>
        public int Index
        {
            get { return _Org.Index; }
            set { _Org.Index = value; }
        }

        /// <summary>
        /// 组织机构名称
        /// </summary>
        public string Name
        {
            get { return _Org.Name; }
            set { _Org.Name = value; }
        }

        /// <summary>
        /// 组织机构全称
        /// </summary>
        public string FullName
        {
            get { return _Org.FullName; }
            set { _Org.FullName = value; }
        }

        /// <summary>
        /// 组织机构别名
        /// </summary>
        public string Alias
        {
            get { return _Org.Alias; }
            set { _Org.Alias = value; }
        }

        /// <summary>
        /// 组织机构编码
        /// </summary>
        public string Code
        {
            get { return _Org.Code; }
            set { _Org.Code = value; }
        }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public Guid CreatorUserId
        {
            get { return _Org.CreatorUserId; }
            set { _Org.CreatorUserId = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return _Org.CreateTime; }
            set { _Org.CreateTime = value; }
        }

        /// <summary>
        /// 职位成员
        /// </summary>
        public List<MemberUser> Members
        {
            get { return GetMember(); }
            set { SetMember(value ?? new List<MemberUser>()); }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Org()
        {
            _Org = new SYS_Organization();
            Result.Success();
        }

        /// <summary>
        /// 构造函数，根据ID读取组织机构实体
        /// </summary>
        /// <param name="id">组织机构ID</param>
        public Org(Guid id)
        {
            using (var context = new BaseEntities())
            {
                _Org = context.SYS_Organization.SingleOrDefault(i => i.ID == id);
                if (_Org == null)
                {
                    _Org = new SYS_Organization();
                    Result.NotFound();
                }
                else
                {
                    Result.Success();
                }
            }
        }
        /// <summary>
        /// 新增组织机构节点
        /// </summary>
        /// <returns>bool 是否成功</returns>
        public bool Add()
        {
            var result = DbHelper.Insert(_Org);
            if (result)
                Result.Created();
            else
                Result.DataBaseError();

            return result;
        }

        /// <summary>
        /// 删除组织机构节点
        /// </summary>
        /// <returns>bool 是否成功</returns>
        public bool Delete()
        {
            var result = DbHelper.Delete(_Org);
            if (!result) Result.DataBaseError();

            return result;
        }

        /// <summary>
        /// 更新组织机构节点
        /// </summary>
        /// <returns>bool 是否成功</returns>
        public bool Update()
        {
            var result = DbHelper.Update(_Org);
            if (!result) Result.DataBaseError();

            return result;
        }

        /// <summary>
        /// 新增职位成员
        /// </summary>
        /// <returns>bool 是否成功</returns>
        public bool AddMember()
        {
            if (DbHelper.Insert(_Members)) return true;

            Result.DataBaseError();
            return false;
        }

        /// <summary>
        /// 设置职位成员创建人ID
        /// </summary>
        /// <param name="id">创建人ID</param>
        public void SetCreatorUserId(Guid id)
        {
            _Members.ForEach(i => i.CreatorUserId = id);
        }

        /// <summary>
        /// 获取职位成员
        /// </summary>
        /// <returns></returns>
        private List<MemberUser> GetMember()
        {
            if (_Org.NodeType < 3) return null;

            using (var context = new BaseEntities())
            {
                var list = from m in context.SYS_OrgMember
                           join u in context.SYS_User on m.UserId equals u.ID
                           where m.OrgId == _Org.ID
                           orderby u.SN
                           select new MemberUser
                           {
                               ID = m.ID,
                               Name = u.Name,
                               LoginName = u.LoginName,
                               Description = u.Description,
                               Validity = u.Validity
                           };
                return list.ToList();
            }
        }

        /// <summary>
        /// 转换职位成员为成员关系数据
        /// </summary>
        /// <param name="members"></param>
        private void SetMember(IEnumerable<MemberUser> members)
        {
            if (_Org.NodeType < 3) return;

            var list = from m in members
                       select new SYS_OrgMember
                       {
                           ID = m.ID,
                           OrgId = _Org.ID,
                           UserId = m.UserId,
                           CreatorUserId = m.CreatorUserId,
                           CreateTime = DateTime.Now
                       };
            _Members = list.ToList();
        }
    }
}