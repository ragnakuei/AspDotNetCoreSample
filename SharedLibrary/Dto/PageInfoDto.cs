namespace SharedLibrary.Dto
{
    /// <summary>
    /// BootGrid 傳入的分頁資訊
    /// </summary>
    public class PageInfoDto
    {
        public int Current { get; set; } = 1;
        public int RowCount { get; set; } = 10;
    }
}