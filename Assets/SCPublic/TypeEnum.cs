namespace SCPublic
{
    public enum SendType
    {
        Text = 0x00,    // 文本内容
        Object = 0x01,    // 对象内容
        File = 0x02,    // 文件内容
        Reply = 0x03,   // 请求返回数据
    }
}
