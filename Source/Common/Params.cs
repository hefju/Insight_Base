﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Insight.Base.Common.Entity;
using Insight.Utils.Redis;

namespace Insight.Base.Common
{
    public static class Params
    {
        private static List<LogRule> _Rules;

        // 日志进程同步基元
        public static readonly Mutex Mutex = new Mutex();

        // 访问管理器
        public static CallManage callManage { get; } = new CallManage();

        /// <summary>
        /// 规则缓存
        /// </summary>
        public static List<LogRule> Rules
        {
            get
            {
                if (_Rules != null) return _Rules;

                using (var context = new Entities())
                {
                    _Rules = context.logRules.ToList();
                }

                return _Rules;
            }
        }

        /// <summary>
        /// 用于生成短信验证码的随机数发生器
        /// </summary>
        public static readonly Random Random = new Random(Environment.TickCount);

        /// <summary>
        /// 日志接口URL
        /// </summary>
        public static string LogUrl;
    }
}