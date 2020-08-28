namespace Domain.ViewModel
{
    public class Cart
    {
        /// <summary>
        /// ای دی محصول
        /// </summary>
        /// <value></value>
        public short Id { get; set; }
        /// <summary>
        /// نام محصول
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// تعداد محصول
        /// </summary>
        /// <value></value>
        public int Count { get; set; }
        /// <summary>
        /// قیمت تکی محصول
        /// </summary>
        /// <value></value>
        public long Price { get; set; }
    }
}