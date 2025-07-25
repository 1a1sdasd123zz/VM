﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace VM.Start.Common.Helper
{
    /// <summary>
    /// 热键管理器
    /// </summary>
    public class HotKeyManager
    {
        /// <summary>
        /// 热键消息，在用户键入被RegisterHotKey函数注册的热键时发送
        /// </summary>
        public const int WM_HOTKEY = 0x312;

        public const int SaveTemplate_ID = 100;//保存模板
        public const int OpenTemplate_ID = 101;//打开模板
        public const int OpenDeviceParam_ID = 102;//打开设备参数界面
        public const int ContinueRun_ID = 103;//打开设备参数界面
        public const int ScreenCapture_ID = 104;//全屏截图
        public const int EditTemplate_ID = 105;//编辑模板
        public const int Help_ID = 106;//帮助
        public const int StopProcess_ID = 107;//停止加工
        public const int StepRun_ID = 108;//单步运行

        /// <summary>
        /// 注册热键。要得到扩展错误信息，调用GetLastError。.NET方法：Marshal.GetLastWin32Error()
        /// </summary>
        /// <param name="hWnd">要定义热键的窗口的句柄</param>
        /// <param name="id">定义热键ID（不能与其他ID重复）</param>
        /// <param name="fsModifiers">标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效</param>
        /// <param name="vk">标识热键的内容，WinForm中可以使用Keys枚举转换，WPF中Key枚举是不正确的，应该使用system.Windows.Froms.Keys枚举，或者自定义正确的枚举或int常量</param>
        /// <returns>是否成功</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, ModifierKeys fsModifiers, int vk);

        /// <summary>
        /// 注销热键。
        /// </summary>
        /// <param name="hWnd">要取消热键的窗口的句柄</param>
        /// <param name="id">要取消热键的ID</param>
        /// <returns>是否成功</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// 向全局原子表添加一个字符串，并返回这个字符串的唯一标识符
        /// </summary>
        /// <param name="lpString">字符串，这个字符串的长度最大为255字节</param>
        /// <returns>成功：返回原子；失败：返回值为0</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern short GlobalAddAtom(string lpString);

        /// <summary>
        /// 在表中搜索全局原子
        /// </summary>
        /// <param name="lpString">字符串，这个字符串的长度最大为255字节</param>
        /// <returns>成功：返回原子；失败：返回值为0</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern short GlobalFindAtom(string lpString);

        /// <summary>
        /// 在表中删除全局原子
        /// </summary>
        /// <param name="nAtom">全局原子</param>
        /// <returns>成功：返回原子；失败：返回值为0</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern short GlobalDeleteAtom(short nAtom);
    }
}
