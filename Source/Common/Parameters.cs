﻿using System;
using System.Collections.Generic;
using System.Threading;
using Insight.Base.Common.Entity;

namespace Insight.Base.Common
{
    public static class Parameters
    {
        /// <summary>
        /// 进程同步基元
        /// </summary>
        public static readonly Mutex Mutex = new Mutex();

        /// <summary>
        /// 规则缓存
        /// </summary>
        public static List<SYS_Logs_Rules> Rules;

        /// <summary>
        /// 短信验证码的缓存列表
        /// </summary>
        public static readonly List<VerifyRecord> SmsCodes = new List<VerifyRecord>();

        /// <summary>
        /// 用于生成短信验证码的随机数发生器
        /// </summary>
        public static readonly Random Random = new Random(Environment.TickCount);

        /// <summary>
        /// 是否验证用户设备ID
        /// </summary>
        public static bool CheckStamp;

        /// <summary>
        /// Token是否自动延期
        /// </summary>
        public static bool AutoExten;

        /// <summary>
        /// Session失效时间（小时）
        /// </summary>
        public static int Expired;
    }
}
